

namespace LeetCode.EasyProblems
{
    class Isomorphic_Strings
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }

            // Create a dictionary to store character mappings
            Dictionary<char, char> charMap = new Dictionary<char, char>();

            for (int i = 0; i < s.Length; i++)
            {
                char original = s[i];
                char replacement = t[i];

                if (!charMap.TryGetValue(original, out var mappedCharacter))
                {
                    if (!charMap.ContainsValue(replacement))
                    {
                        charMap[original] = replacement;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (mappedCharacter != replacement)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/isomorphic-strings/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Isomorphic Strings")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, (string, string) Input) item)
        {
            var response = IsIsomorphic(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(bool Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(bool Output, (string, string) Input)>()
                {

                    (true, ("egg", "add")),
                };
            }
        }
    }
}
