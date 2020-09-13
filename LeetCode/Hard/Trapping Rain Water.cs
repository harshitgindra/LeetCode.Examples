using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode.Hard
{
    class Trapping_Rain_Water
    {
        public int Trap(int[] height)
        {
            IDictionary<int, int> blocks = new Dictionary<int, int>();
            for (int i = 0; i < height.Length; i++)
            {
                blocks.Add(i, height[i]);
            }
            int total = 0;
            int fIndex = 0;
            do
            {
                var fItem = GetFirstIndex(fIndex, blocks, 1);
                var sItem = GetNextIndex(fItem.Key + 1, blocks, fItem.Value);
                if (sItem.Key != 0)
                {
                    int minHeight = Math.Min(sItem.Value, fItem.Value);
                    for (int i = fItem.Key + 1; i < sItem.Key; i++)
                    {
                        total = total + minHeight - height[i];
                    }
                    fIndex = sItem.Key;
                }
                else
                {
                    fIndex++;
                }
            }
            while (fIndex < height.Length - 1);

            return total;
        }

        private KeyValuePair<int, int> GetFirstIndex(int sIndex, IDictionary<int, int> dic, int benchmark)
        {
            return dic.FirstOrDefault(x => x.Key >= sIndex && x.Value >= benchmark);
        }

        private KeyValuePair<int, int> GetNextIndex(int sIndex, IDictionary<int, int> dic, int benchmark)
        {
            var item = dic.FirstOrDefault(x => x.Key >= sIndex && x.Value >= benchmark);
            return item;
        }


        [Test(Description = "https://leetcode.com/problems/trapping-rain-water/")]
        [Category("Hard")]
        [Category("Leetcode")]
        [Category("Trapping Rain Water")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = Trap(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (1, new int[] {4,2,3}),
                    (6, new int[] {0,1,0,2,1,0,1,3,2,1,2,1}),
                };
            }
        }
    }
}
