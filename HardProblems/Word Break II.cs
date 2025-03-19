

namespace LeetCode.HardProblems
{
    class Word_Break_II
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            IList<string> ret = Search(s, wordDict, new Dictionary<string, LinkedList<string>>());
            return ret;
        }

        private IList<string> Search(string s, IList<string> wordDict, Dictionary<string, LinkedList<String>> map)
        {
            // Look up cache 
            if (map.ContainsKey(s))
            {
                return map[s].ToList();
            }

            var list = new LinkedList<String>();

            // base case 
            if (s.Length == 0)
            {
                list.AddLast("");
                return list.ToList();
            }

            // go over each word in dictionary
            foreach (string word in wordDict)
            {
                // C# string.StartsWith API
                if (s.StartsWith(word))
                {
                    var nextList = Search(s.Substring(word.Length), wordDict, map);

                    foreach (string sub in nextList)
                    {
                        list.AddLast(word + (string.IsNullOrEmpty(sub) ? "" : " ") + sub);
                    }
                }
            }

            // memoization
            map.Add(s, list);

            return list.ToList();
        }




        [Test(Description = "https://leetcode.com/problems/word-break-ii/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Word Break II")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (string, IList<string>) Input) item)
        {
            var response = WordBreak(item.Input.Item1, item.Input.Item2);
            Assert.That(response.Count, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (string, IList<string>) Input)> Input =>
            new List<(int Output, (string, IList<string>) Input)>()
            {
                (2, ("catsanddog", new List<string>(){"cat", "cats", "and", "sand", "dog"})),
                (3, ("pineapplepenapple", new List<string>(){"apple", "pen", "applepen", "pine", "pineapple"})),
            };
    }
}
