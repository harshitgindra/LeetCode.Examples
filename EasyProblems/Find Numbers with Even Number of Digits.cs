

namespace LeetCode.EasyProblems
{
    class Find_Numbers_with_Even_Number_of_Digits
    {
        public int FindNumbers(int[] nums)
        {
            IDictionary<int, int> dict = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (dict.ContainsKey($"{item}".Length))
                {
                    dict[$"{item}".Length]++;
                }
                else
                {
                    dict.Add($"{item}".Length, 1);
                }
            }

            int returnValue = 0;
            foreach (var item in dict)
            {
                if (item.Key % 2 == 0)
                {
                    returnValue += item.Value;
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/find-numbers-with-even-number-of-digits/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Find Numbers with Even Number of Digits")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindNumbers(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (2, [12,345,2,6,7896]),
            };
    }
}
