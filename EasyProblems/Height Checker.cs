using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    public class Height_Checker
    {
        public int HeightChecker(int[] heights)
        {
            var tempHeights = heights.ToArray();
            Array.Sort(tempHeights);

            int returnValue = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != tempHeights[i])
                {
                    returnValue++;
                }
            }
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/height-checker/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Height Cracker")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = HeightChecker(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (3, [1,1,4,2,1,3]),
                    (5, [5,1,2,3,4]),
                    (0, [1,2,3,4, 5]),
                };
            }
        }
    }
}
