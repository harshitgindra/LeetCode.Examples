using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Easy
{
    class Fibonacci_Number
    {
        private IDictionary<int, int> combo = new Dictionary<int, int>()
        {
            {0,0 },
            {1,1 },
        };

        public int Fib(int N)
        {
            int returnValue = 0;

            if (combo.ContainsKey(N))
            {
                returnValue = combo[N];
            }
            else
            {
                for (int i = N - 2; -1 < i && i < N; i++)
                {
                    if (combo.ContainsKey(i))
                    {
                        returnValue += combo[i];
                    }
                    else
                    {
                        returnValue += Fib(i);
                    }
                }

                combo.Add(N, returnValue);
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/fibonacci-number/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Fibonacci Number")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int Input) item)
        {
            var response = Fib(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {

                    (3,4),
                };
            }
        }
    }
}
