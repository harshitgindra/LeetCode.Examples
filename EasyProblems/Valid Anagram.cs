
namespace LeetCode.EasyProblems
{
    class Valid_Anagram
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> counts = new Dictionary<char, int>();

            foreach (char c in s)
            {
                counts[c] = counts.GetValueOrDefault(c, 0) + 1;
            }

            foreach (char c in t)
            {
                if (!counts.ContainsKey(c) || counts[c] == 0) return false;
                counts[c]--;
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/valid-anagram/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Valid Anagram")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, (string, string) Input) item)
        {
            var response = IsAnagram(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(bool Output, (string, string) Input)> Input =>
            new List<(bool Output, (string, string) Input)>()
            {

                (true, ("anagram", "nagaram")),
                (false, ("rat", "car")),
            };
    }
}
