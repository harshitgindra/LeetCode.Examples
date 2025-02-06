using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.Mock.Bloomberg
{
    class MockTest1
    {
        /// <summary>
        /// Sum of Left Leaves
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public int SumOfLeftLeaves(TreeNode root)
        {
            return Sum(root, 0, false);
        }

        private int Sum(TreeNode node, int sum, bool isLeft)
        {
            if (node != null)
            {
                if (node.left == null && node.right == null)
                {
                    if (isLeft)
                    {
                        return sum + node.val;
                    }
                }
                else
                {
                    sum = Sum(node.left, sum, true);
                    sum = Sum(node.right, sum, false);
                }
            }
            return sum;
        }


        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var respone = MinCostClimbingStairs(item.Input);
            ClassicAssert.AreEqual(item.Output, respone);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (6, new int[]{ 1, 100, 1, 1, 1, 100, 1, 1, 100, 1}),
                    (15, new int[]{ 10,15,20}),
                };
            }
        }

        /// <summary>
        /// Min Cost Climbing Stairs
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinCostClimbingStairs(int[] cost)
        {
            return Math.Min(Climb(cost, 0, 0, Int32.MaxValue), Climb(cost, 1, 0, Int32.MaxValue));
        }

        private int Climb(int[] cost, int currIndex, int currTotal, int minTotal)
        {
            if (currIndex >= cost.Length)
            {
                return Math.Min(minTotal, currTotal);
            }
            else
            {
                //***
                //*** Taking 2 step
                //***
                if (currIndex <= cost.Length - 2)
                {
                    var total = currTotal + cost[currIndex];
                    if (total < minTotal)
                    {
                        minTotal = Climb(cost, currIndex + 2, total, minTotal);
                    }
                }
                //***
                //*** Taking 1 step
                //***
                var tempTotal = currTotal + cost[currIndex];
                if (tempTotal < minTotal)
                {
                    minTotal = Climb(cost, currIndex + 1, tempTotal, minTotal);
                }
            }

            return minTotal;
        }
    }
}
