namespace LeetCode
{
    public class RomanToInteger
    {
        public RomanToInteger()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Roman To Integer");
            Console.WriteLine("----------------------------------------------------------");
        }

        IDictionary<Char, int> keys = new Dictionary<Char, int> { { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },

        };

        public int RomanToInt(string s)
        {
            var returnValue = 0;

            for (var i = s.Length - 1; i >= 0; i--)
            {
                var charAt = s.ElementAt(i);
                //***
                //*** Compare current char with the next char
                //***
                if (s.ElementAtOrDefault(i + 1) != 0 && keys[charAt] < keys[s.ElementAt(i + 1)])
                {
                    returnValue += (-keys[charAt]);
                }
                else
                {
                    returnValue += keys[charAt];
                }
            }

            return returnValue;
        }
    }
}
