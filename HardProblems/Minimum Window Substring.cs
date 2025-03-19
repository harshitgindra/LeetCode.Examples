
namespace LeetCode.HardProblems
{
    class Minimum_Window_Substring
    {
        public string MinWindow(string s, string t)
        {
            string result = "";

            if (!string.IsNullOrEmpty(s) && !string.IsNullOrEmpty(t))
            {
                int sIndex = -1;
                int eIndex = s.Length;
                int max = s.Length;
                for (int i = 0; i < max; i++)
                {
                    var endIndex = Check(i, s, t.ToList(), max);
                    if (endIndex != -1 && endIndex - i < eIndex - sIndex)
                    {
                        max = Math.Min(s.Length - 1, i + eIndex - sIndex + 1);
                        sIndex = i;
                        eIndex = endIndex;
                    }
                }

                if (sIndex != -1)
                {
                    result = s.Substring(sIndex, eIndex - sIndex + 1);
                }
            }

            return result;
        }

        private int Check(int sIndex, string s, List<char> t, int max)
        {
            int ret = -1;
            for (int i = sIndex; i < s.Length; i++)
            {
                var c = s[i];
                if (t.Contains(c))
                {
                    t.RemoveAt(t.IndexOf(c));
                }

                if (t.Count == 0)
                {
                    ret = i;
                    break;
                }
            }

            return ret;
        }


        [Test(Description = "https://leetcode.com/problems/minimum-window-substring/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Best Time to Buy and Sell Stock IV")]
        [TestCaseSource(nameof(Input))]
        public void Test1((string Output, (string, string) Input) item)
        {
            var response = MinWindow(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(string Output, (string, string) Input)> Input =>
            new List<(string Output, (string, string) Input)>()
            {
                ("BANC", ("ADOBECODEBANC", "ABC")),
            };
    }
}