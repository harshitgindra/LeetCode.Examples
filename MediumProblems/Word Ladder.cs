using System.Text;


namespace LeetCode.MediumProblems
{
    public class Word_Ladder
    {
        private char[] _alpha;

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if (wordList.Contains(endWord))
            {
                var orgwordList = wordList.OrderBy(x => x).ToHashSet();
                orgwordList.Remove(beginWord);
                _alpha = "qwertyuiopasdfghjklzxcvbnm".OrderBy(x => x).ToArray();

                var response = Search(new StringBuilder(beginWord),
                    orgwordList, 1, new StringBuilder(endWord), Int32.MaxValue);

                if (response.Item2 != Int32.MaxValue)
                {
                    return response.Item2 + 1;
                }
            }

            return 0;
        }

        private ( bool, int) Search(StringBuilder arry, HashSet<string> wordList, int jumps,
            StringBuilder finalWord,
            int mimJumps)
        {
            int min = mimJumps;
            bool found = false;
            if (jumps < mimJumps)
            {
                StringBuilder sb = new StringBuilder(arry.ToString());
                for (int i = 0; i < sb.Length; i++)
                {
                    var c = sb[i];
                    //***
                    //*** brute force
                    //***
                    foreach (var item in _alpha)
                    {
                        sb[i] = item;

                        if (sb.Equals(finalWord))
                        {
                            return (true, Math.Min(jumps, min));
                        }
                        else
                        {
                            if (wordList.Remove(sb.ToString()))
                            {
                                var response = Search(sb,
                                    wordList.ToHashSet(), jumps + 1, finalWord, min);
                                min = response.Item2;
                                found = response.Item1;
                            }
                        }
                    }

                    sb[i] = c;
                }
            }

            return (found, min);
        }

        [Test(Description = "https://leetcode.com/problems/maximal-rectangle/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("maximal rectangle")]
        [TestCaseSource(nameof(Input))]
        [Ignore("")]
        public void Test1((int Output, (string beginWord, string endWord, IList<string> wordList) Input) item)
        {
            // var response = LadderLength(item.Input.beginWord, item.Input.endWord, item.Input.wordList);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (string beginWord, string endWord, IList<string> wordList) Input)> Input =>
            new List<(int Output, (string beginWord, string endWord, IList<string> wordList) Input)>()
            {
                (4, ("hot", "dog", new List<string>() {"hot", "cog", "dog", "tot", "hog", "hop", "pot", "dot"})),
                // (3, ("hot", "dog", new List<string>() {"hot", "dog", "tot", "hog", "hop", "pot", "dot"})),
                // (5, ("hit", "cog", new List<string>() {"hot", "dot", "dog", "lot", "log", "cog"})),
            };
    }
}