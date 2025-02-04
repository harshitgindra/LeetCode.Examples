using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Hard
{
    class Trapping_Rain_Water
    {

        public int Trap(int[] height)
        {
            int total = 0;

            if (height != null && height.Length > 1)
            {
                (int Position, int Height) firstElement = default;
                int index = 0;
                do
                {
                    if (firstElement == default)
                    {
                        int nextIndex = Math.Min(index + 1, height.Length - 1);
                        if (height[index] != 0 && height[index] > height[nextIndex])
                        {
                            firstElement.Position = index;
                            firstElement.Height = height[index];
                            index = height.Length;

                            int maxHeightDiff = firstElement.Height;
                            for (int i = firstElement.Position + 2; i < height.Length; i++)
                            {
                                if (firstElement.Height <= height[i])
                                {
                                    index = i;
                                    break;
                                }
                                else if (firstElement.Height - height[i] < maxHeightDiff)
                                {
                                    index = i;
                                    maxHeightDiff = firstElement.Height - height[i];
                                }
                            }
                        }
                        else
                        {
                            index++;
                        }
                    }
                    else
                    {
                        if (height[index] > 0)
                        {
                            int minHeight = Math.Min(firstElement.Height, height[index]);

                            for (int i = firstElement.Position + 1; i < index; i++)
                            {
                                int tempTotal = Math.Max(minHeight - height[i], 0);
                                total += tempTotal;
                            }

                            firstElement = default;
                        }
                        else
                        {
                            index++;
                        }
                    }

                } while (index < height.Length);
            }

            return total;
        }

        public int Trap1(int[] height)
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
        [Category("LeetCode")]
        [Category("Trapping Rain Water")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = Trap(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (1, new int[] {4,9,4,5,3,2}),
                    (14, new int[] {5,2,1,2,1,5}),
                    (1, new int[] {5,4,1,2}),
                    (1, new int[] {4,2,3}),
                    (6, new int[] {0,1,0,2,1,0,1,3,2,1,2,1}),
                };
            }
        }
    }
}
