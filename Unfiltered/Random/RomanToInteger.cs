namespace LeetCode
{
    public class RomanToInteger
    {
        private IDictionary<Char, int> _keys = new Dictionary<Char, int> { { 'I', 1 },
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

            for (int i = 0; i < s.Length -1; i++)
            {
                if (_keys[s[i]] >= _keys[s[i + 1]])
                {
                    returnValue += _keys[s[i]];
                }
                else
                {
                    returnValue -= _keys[s[i]];
                }
            }
            
            returnValue += _keys[s[s.Length -1]];
            return returnValue;
        }
        
        [Test(Description = "https://leetcode.com/problems/roman-to-integer/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Roman to Integer")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, string Input) item)
        {
            var response = RomanToInt(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, string Input)> Input =>
            new List<(int Output, string Input)>()
            {

                (58, ("LVIII")),
            };
    }
}
