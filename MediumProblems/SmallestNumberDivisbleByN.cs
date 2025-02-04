using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    public class SmallestNumberDivisbleByN
    {
        public int SmallestRepunitDivByK(int K)
        {
            for (int i = 1, a = 0; i <= K; i++)
                if ((a = (a * 10 + 1) % K) == 0)
                    return i;
            return -1;
        }


        [Test(Description = "https://leetcode.com/problems/max-consecutive-ones-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Max Consecutive Ones II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = SmallestRepunitDivByK(item.Input.Item2);
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