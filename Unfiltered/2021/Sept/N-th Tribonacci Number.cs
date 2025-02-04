using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Leetcode.Problems._2021.Sept
{
    public class N_th_Tribonacci_Number
    {
        public int Tribonacci(int n)
        {
            int a = 0, b = 1, c = 1;
            if (n == 0)
            {
                return a;
            }
            if (n == 1 || n == 2)
            {
                return b;
            }

            for (int i = 3; i <= n; i++)
            {
                int temp = a + b + c;
                a = b;
                b = c;
                c = temp;
            }

            return c;
        }
        
        [Test(Description ="https://leetcode.com/problems/n-th-tribonacci-number/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("N-th Tribonacci Number")]
        [Category("1137")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int Input) item)
        {
            var response = Tribonacci(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {
                    (2, 3),
                    (1389537, 25),
                };
            }
        }
    }
}