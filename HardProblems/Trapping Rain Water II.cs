using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Hard
{
    class Trapping_Rain_Water_II
    {
        public int TrapRainWater(int[][] heightMap)
        {
            int total = 0;
            if (heightMap != null && heightMap.Length > 1)
            {
                IDictionary<(int, int), (int Value, int Max)> maxDictionary = new Dictionary<(int, int), (int, int)>();
                int iMax = heightMap.Length;
                int jMax = default;
                for (int i = 0; i < heightMap.Length; i++)
                {
                    for (int j = 0; j < heightMap[i].Length; j++)
                    {
                        jMax = heightMap[i].Length;
                        int max = GetMaxHeightAround(i, j, heightMap.Length, heightMap[i].Length, heightMap);
                        maxDictionary.Add((i, j), (heightMap[i][j], max));
                    }
                }


                for (int i = 0; i < heightMap.Length; i++)
                {
                    for (int j = 0; j < heightMap[i].Length; j++)
                    {
                        Neighbor(maxDictionary, i, j, iMax, jMax, maxDictionary[(i, j)].Max, new HashSet<(int, int)>());
                    }
                }

                for (int i = 1; i < heightMap.Length - 1; i++)
                {
                    for (int j = 1; j < heightMap[i].Length - 1; j++)
                    {
                        var element = maxDictionary[(i, j)];

                        total += Math.Max(element.Max - element.Value, 0);
                    }
                }
            }

            return total;
        }

        private void Neighbor(IDictionary<(int, int), (int Value, int Max)> maxDictionary,
            int i, int j,
            int iMax, int jMax,
            int currentMax,
            HashSet<(int, int)> uniqueCombo)
        {
            int max = currentMax;

            for (int iValue = i; iValue <= iMax; iValue++)
            {
                if (maxDictionary.ContainsKey((iValue, j)) && maxDictionary[(iValue, j)].Value < max)
                {
                    max = Math.Min(max, maxDictionary[(iValue, j)].Max);
                    maxDictionary[(iValue, j)] = (maxDictionary[(iValue, j)].Value, max);
                }
                else
                {
                    break;
                }
            }

            for (int iValue = i; iValue >= 0; iValue--)
            {
                if (maxDictionary.ContainsKey((iValue, j)) && maxDictionary[(iValue, j)].Value < max)
                {
                    max = Math.Min(max, maxDictionary[(iValue, j)].Max);
                    maxDictionary[(iValue, j)] = (maxDictionary[(iValue, j)].Value, max);
                }
                else
                {
                    break;
                }
            }

            for (int jValue = j; jValue <= jMax; jValue++)
            {
                if (maxDictionary.ContainsKey((i, jValue)) && maxDictionary[(i, jValue)].Value < max)
                {
                    max = Math.Min(max, maxDictionary[(i, jValue)].Max);
                    maxDictionary[(i, jValue)] = (maxDictionary[(i, jValue)].Value, max);
                }
                else
                {
                    break;
                }
            }

            for (int jValue = j; jValue >= 0; jValue--)
            {
                if (maxDictionary.ContainsKey((i, jValue)) && maxDictionary[(i, jValue)].Value < max)
                {
                    max = Math.Min(max, maxDictionary[(i, jValue)].Max);
                    maxDictionary[(i, jValue)] = (maxDictionary[(i, jValue)].Value, max);
                }
                else
                {
                    break;
                }
            }
        }

        private int GetMaxHeightAround(int i, int j, int maxI, int maxJ, int[][] heightMap)
        {
            //***
            //*** Upper 
            //***
            int tempI = i;
            int maxUpperI = heightMap[i][j];
            while (tempI >= 0)
            {
                maxUpperI = Math.Max(maxUpperI, heightMap[tempI][j]);
                tempI--;
            }

            //***
            //*** Lower 
            //***
            tempI = i;
            int maxLowerI = heightMap[i][j];
            while (tempI < maxI)
            {
                maxLowerI = Math.Max(maxLowerI, heightMap[tempI][j]);
                tempI++;
            }

            //***
            //*** Left 
            //***
            int tempJ = j;
            int maxLeftJ = heightMap[i][j];
            while (tempJ >= 0)
            {
                maxLeftJ = Math.Max(maxLeftJ, heightMap[i][tempJ]);
                tempJ--;
            }

            //***
            //*** Right 
            //***
            tempJ = j;
            int maxRightJ = heightMap[i][j];
            while (tempJ < maxJ)
            {
                maxRightJ = Math.Max(maxRightJ, heightMap[i][tempJ]);
                tempJ++;
            }

            return Math.Min(maxRightJ, Math.Min(maxLeftJ, Math.Min(maxUpperI, maxLowerI)));
        }

        [Test(Description = "https://leetcode.com/problems/trapping-rain-water-ii/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Trapping Rain Water II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[][] Input) item)
        {
            var response = TrapRainWater(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[][] Input)> Input
        {
            get
            {
                return new List<(int Output, int[][] Input)>()
                {

                    (4, new int[3][] {
                        new int[6]{ 1, 4, 3, 1, 3, 2 },
                        new int[6]{ 3, 2, 1, 3, 2, 4 },
                        new int[6]{ 2, 3, 3, 2, 3, 1 }
                        }),

                     (14, new int[5][] {
                        new int[4]{ 12,13,1,12 },
                        new int[4]{ 13,4,13,12 },
                        new int[4]{ 13, 8, 10, 12 },
                        new int[4]{ 12,13,12,12 },
                        new int[4]{ 13,13,13,13 },
                        }),

                      (215, new int[5][] {
                        new int[11]{ 9,9,9,9,9,9,8,9,9,9,9 },
                        new int[11]{ 9,0,0,0,0,0,1,0,0,0,9 },
                        new int[11]{ 9,0,0,0,0,0,0,0,0,0,9 },
                        new int[11]{ 9,0,0,0,0,0,0,0,0,0,9 },
                        new int[11]{ 9,9,9,9,9,9,9,9,9,9,9 }
                        }),
                };
            }
        }
    }
}
