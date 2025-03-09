using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2021.March
{
    class Single_Row_Keyboard
    {
        public int CalculateTime(string keyboard, string word)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int i = 0;
            foreach (var item in keyboard)
            {
                dict.Add(item, i++);
            }

            int last = 0;
            int returnValue = 0;
            foreach (var item in word)
            {
                var curr = dict[item];
                returnValue += Math.Abs(curr - last);
                last = curr;
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/single-row-keyboard/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Single-Row Keyboard")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (string, string) Input) item)
        {
            var response = CalculateTime(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(int Output, (string, string) Input)>()
                {
                    (4, ("abcdefghijklmnopqrstuvwxyz", "cba")),
                };
            }
        }
    }
}
