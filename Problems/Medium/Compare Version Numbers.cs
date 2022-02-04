using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class Compare_Version_Numbers
    {
        public int CompareVersion(string version1, string version2)
        {
            var v1 = version1.Split(".")
                .Select(x => Int32.Parse(x))
                .ToList();

            var v2 = version2.Split(".")
                .Select(x => Int32.Parse(x))
                .ToList();

            var maxLength = Math.Max(v1.Count, v2.Count);

            while (v1.Count < maxLength)
            {
                v1.Add(0);
            }

            while (v2.Count < maxLength)
            {
                v2.Add(0);
            }

            for (int i = 0; i < maxLength; i++)
            {
                if (v1[i] > v2[i])
                {
                    return 1;
                }
                else if (v1[i] < v2[i])
                {
                    return -1;
                }
            }

            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Combination Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (string, string) Input) item)
        {
            var response = CompareVersion(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(int Output, (string, string) Input)>()
                {
                    (0, ("1.01", "1.001")),
                };
            }
        }
    }
}