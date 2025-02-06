namespace LeetCode
{
    public class LongestCommonPrefixTest
    {
        public LongestCommonPrefixTest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Longest Common Prefix Test");
            Console.WriteLine("----------------------------------------------------------");
        }

        public string LongestCommonPrefix(string[] strs)
        {
            //***
            //*** check if array is null or empty
            //***
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            //***
            //*** If array length is 1, return the same text
            //***
            else if (strs.Length == 1)
            {
                return strs[0];
            }
            else
            {
                var frstStr = strs[0];
                int totalStrs = strs.Length;
                string returnValue = "";
                //***
                //*** Loop through all text of the first word
                //***
                for (var i = frstStr.Length; i >= 0; i--)
                {
                    var text = frstStr.Substring(0, i);
                    //***
                    //*** check if all items in array starts with the text
                    //***
                    if (strs.Any(x => !x.StartsWith(text)))
                    {

                    }
                    else
                    {
                        returnValue = text;
                        break;
                    }
                }

                return returnValue;
            }

        }
    }
}
