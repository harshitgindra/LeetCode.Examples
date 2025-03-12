namespace LeetCode.EasyProblems
{
    public class RansomNote
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char c in magazine)
            {
                if (counts.ContainsKey(c))
                {
                    counts[c]++;
                }
                else
                {
                    counts.Add(c, 1);
                }
            }

            foreach (char c in ransomNote)
            {
                if (counts.ContainsKey(c) && counts[c] > 0)
                {
                    counts[c]--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/ransom-note/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Ransom Node")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, (string, string) Input) item)
        {
            var response = CanConstruct(item.Input.Item1, item.Input.Item2);
            Assert.That(item.Output, Is.EqualTo(response));
        }

        public static IEnumerable<(bool Output, (string, string) Input)> Input =>
            new List<(bool Output, (string, string) Input)>()
            {
                (false, ("aa", "ab")),
            };
    }
}