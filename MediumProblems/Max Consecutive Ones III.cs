using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    public class Max_Consecutive_Ones_III
    {
        public int LongestOnes(int[] A, int K)
        {
            int ret = 0;
            int right = 0;
            int left = 0;

            for (right = 0; right < A.Length; right++)
            {
                if (A[right] == 0)
                {
                    K--;
                }

                if (K < 0)
                {
                    if (A[left] == 0)
                    {
                        K++;
                    }

                    left++;
                    ret = Math.Max(ret, right - left);
                }
            }

            ret = Math.Max(ret, right - left);
            return ret;
        }

        [Test(Description = "https://leetcode.com/problems/max-consecutive-ones-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Max Consecutive Ones II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = LongestOnes(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (10, (new int[] {0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1}, 3)),
                    (6, (new int[] {1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0}, 2)),
                };
            }
        }
    }
}