namespace LeetCode.HardProblems
{
    class Palindrome_Pairs
    {
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var lstOutPut = new List<List<int>>();
            var lstReverse = new Dictionary<string, int>();
            int i = 0;

            for (int index = 0; index < words.Length; index++)
            {
                for (i = 0; i <= words[index].Length; i++)
                {
                    string prefix = words[index].Substring(0, i);
                    string suffix = words[index].Substring(i);

                    if (lstReverse.ContainsKey(prefix) && lstReverse[prefix] != index && IsPalindrome(suffix))
                    {
                        lstOutPut.Add(new List<int>() { index, lstReverse[prefix] });
                    }

                    if (prefix.Length > 0 && lstReverse.ContainsKey(suffix) && lstReverse[suffix] != index &&
                        IsPalindrome(prefix))
                    {
                        lstOutPut.Add(new List<int>() { lstReverse[suffix], index });
                    }

                }
            }
            return lstOutPut.Cast<IList<int>>().ToList();
        }

        private bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }


        [Test(Description = "https://leetcode.com/problems/palindrome-pairs/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Palindrome Pairs")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<IList<int>> Output, string[] Input) item)
        {
            var response = PalindromePairs(item.Input);
            //AssertExtensions.AreEqual(item.Output, response);
        }

        public static IEnumerable<(IList<IList<int>> Output, string[] Input)> Input
        {
            get
            {
                return new List<(IList<IList<int>> Output, string[] Input)>()
                {

                    (null, new string[]{"abcd","dcba","lls","s","sssll"}
                    ),
                };
            }
        }
    }
}
