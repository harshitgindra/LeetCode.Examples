using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Climbing_Stairs
    {
        public int ClimbStairs(int n)
        {
            if (n <= 2)
            {
                return n;
            }

            int[] result = new int[n + 1];

            result[1] = 1;
            result[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }

            return result[n];
        }

        [Test(Description = "https://leetcode.com/problems/climbing-stairs/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Climbing Stairs")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int Input) item)
        {
            var response = ClimbStairs(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int Input)> Input =>
            new List<(int Output, int Input)>()
            {
                (3, 3),
                (2, 2),
            };
    }
}