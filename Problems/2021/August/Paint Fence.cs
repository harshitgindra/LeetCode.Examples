using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.August
{
    class Paint_Fence
    {
        public int NumWays(int n, int k)
        {
            int returnValue = 0;
            if (n == 0)
            {
                returnValue = 0;
            }
            if (n == 1)
            {
                returnValue = k;
            }
            else
            {
                returnValue = k;
                int differentColorCombinations = k;
                //***
                //*** Loop through all posts and calculate combinations for same color and different color
                //***
                for (int i = 2; i <= n; i++)
                {
                    //***
                    //*** Previous post different color combination becomes current post same color combination
                    //***
                    int sameColorCombinations = differentColorCombinations;
                    //***
                    //*** Current post diff color combination = previous total * k-1
                    //***
                    differentColorCombinations = returnValue * (k - 1);
                    //***
                    //*** Add same color and diff color combinations to get total
                    //***
                    returnValue = sameColorCombinations + differentColorCombinations;
                }
            }

            return returnValue;
        }


        [Test(Description = "https://leetcode.com/problems/paint-fence/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Paint Fence")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int n, int k) Input) item)
        {
            var response = NumWays(item.Input.n, item.Input.k);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int n, int k) Input)> Input
        {
            get
            {
                return new List<(int Output, (int n, int k) Input)>()
                {
                    (42, (7,2)),
                    (6, (3,2)),
                };
            }
        }
    }
}
