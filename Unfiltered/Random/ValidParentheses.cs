namespace LeetCode
{
    public class ValidParenthesesTest
    {
        public ValidParenthesesTest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Valid Parentheses Test");
            Console.WriteLine("----------------------------------------------------------");
        }

        public bool IsValid(string s)
        {
            bool returnValue = false;

            //***
            //*** If string is empty, return true
            //***
            if (string.IsNullOrEmpty(s))
            {
                returnValue = true;
            }
            //***
            //*** if length is odd, return false
            //***
            else if (s.Length % 2 == 0)
            {
                var tempText = s;
                for (int i = 0; i < s.Length / 2; i++)
                {
                    //***
                    //*** Replace basic pairs
                    //***
                    tempText = tempText.Replace("{}", string.Empty)
                        .Replace("[]", string.Empty)
                        .Replace("()", string.Empty);
                    //***
                    //*** break the loop if text is empty
                    //***
                    if (string.IsNullOrEmpty(tempText))
                    {
                        returnValue = true;
                        break;
                    }
                }
            }

            return returnValue;
        }
    }
}
