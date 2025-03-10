namespace LeetCode.EasyProblems
{
    public class LongestCommonPrefixTest
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length > 1)
            {
                Array.Sort(strs);

                string first = strs[0];
                string last = strs[strs.Length - 1];
                string result = "";
                for (int i = 0; i < Math.Min(first.Length, last.Length); i++)
                {
                    if (first[i] != last[i])
                    {
                        return result;
                    }
                    result += first[i];
                }

                return result;
            }
            else if(strs.Length == 1)
            {
                return strs[0];
            }
            else
            {
                return null;
            }
        }
        
        [Test(Description = "https://leetcode.com/problems/longest-common-prefix/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Longest Common Prefix")]
        [TestCaseSource(nameof(Input))]
        public void Test1((string Output, string[] Input) item)
        {
            var response = LongestCommonPrefix(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(string Output, string[] Input)> Input =>
            new List<(string Output, string[] Input)>()
            {

                ("fl", (["flower","flow","flight"])),
            };
    }
}
