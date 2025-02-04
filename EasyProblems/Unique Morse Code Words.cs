using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    public class Unique_Morse_Code_Words
    {
        private static string[] _codes = new[]
        {
            ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---",
            ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."
        };
        public int UniqueMorseRepresentations(string[] words)
        {

            return 1;
        }
        
        [Test(Description = "https://leetcode.com/problems/unique-email-addresses/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Unique Email Addresses")]
        public void Test1()
        {
            var response = UniqueMorseRepresentations(new string[]{"gin", "zen", "gig", "msg"});
            ClassicAssert.AreEqual(2, response);
        }
    }
}