namespace LeetCode
{
    public class LengthOfLastWordTest
    {
        public LengthOfLastWordTest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Length Of Last Word");
            Console.WriteLine("----------------------------------------------------------");
        }
        
        public int LengthOfLastWord(string s)
        {
            int returnValue = 0;
            string txt = s?.Trim();
            
            if (!string.IsNullOrEmpty(txt))
            {
                if (!txt.Contains(" "))
                {
                    returnValue = txt.Length;
                }
                else
                {
                    for (int i = txt.Length - 1; i >= 0; i--)
                    {
                        if (txt[i] == ' ')
                        {
                            returnValue = txt.Length - 1 - i;
                            break;
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}