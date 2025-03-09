using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Valid_Anagram
    {
        public bool IsAnagram(string s, string t)
        {
            return string.Concat(s.OrderBy(c => c)) == String.Concat(t.OrderBy(c => c));
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
