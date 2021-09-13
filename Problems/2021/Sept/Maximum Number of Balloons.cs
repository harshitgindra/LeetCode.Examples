using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.Sept
{
    class Maximum_Number_of_Balloons
    {
        public int MaxNumberOfBalloons(string text)
        {
            int bCount = 0;
            int aCount = 0;
            int lCount = 0;
            int oCount = 0;
            int nCount = 0;

            foreach (var item in text.ToLower())
            {
                switch (item)
                {
                    case 'a':
                        aCount++;
                        break;
                    case 'b':
                        bCount++;
                        break;
                    case 'l':
                        lCount++;
                        break;
                    case 'o':
                        oCount++;
                        break;
                    case 'n':
                        nCount++;
                        break;
                }
            }

            lCount = lCount / 2;
            oCount = oCount / 2;

            int returnValue = Math.Min(aCount, Math.Min(bCount, Math.Min(lCount, Math.Min(oCount, nCount))));
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/maximum-number-of-balloons/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Maximum Number of Balloons")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string Input) item)
        {
            var response = MaxNumberOfBalloons(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {
                    (2, "loonbalxballpoon"),
                };
            }
        }
    }
}
