using System.Text;

namespace LeetCode.August
{
    public class Goat_Latin
    {
        public string ToGoatLatin(string S)
        {
            HashSet<char> vowels = new HashSet<char>()
            {
                'A','E','I','O','U','a','e','i','o','u'
            };
            var words = S.Split(" ");
            string endText = default;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                endText += "a";
                var word = words[i];
                var firstChar = word[0];
                if (!vowels.Contains(firstChar))
                {
                    words[i] = word.Substring(1) + firstChar;
                }

                sb.Append(words[i] + "ma" + endText + " ");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
