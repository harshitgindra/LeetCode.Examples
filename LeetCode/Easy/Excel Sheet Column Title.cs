using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Excel_Sheet_Column_Title
    {
        const string alphas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string ConvertToTitle(int n)
        {
            if (n < 27)
            {
                return alphas[n - 1].ToString();
            }

            return ConvertToTitle((n - 1) / 26) + alphas[(n - 1) % 26].ToString();
        }

        [Test(Description = "https://leetcode.com/problems/excel-sheet-column-title/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Excel Sheet Column Title")]
        [TestCaseSource("Input")]
        public void Test1((string Output, int Input) item)
        {
            var response = ConvertToTitle(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, int Input)> Input
        {
            get
            {
                return new List<(string Output, int Input)>()
                {

                    ("ZY", 701),
                };
            }
        }
    }
}
