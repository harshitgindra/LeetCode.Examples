using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class ThreeSum
    {


        public IList<IList<int>> ThreeSumTest(int[] nums)
        {
            List<IList<int>> returnValue = new List<IList<int>>();

            if (nums != null && nums.Length > 2)
            {
                Array.Sort(nums);
                HashSet<(int, int, int)> uniqueKeys = new HashSet<(int, int, int)>();
                HashSet<int> uniqueNums = nums.ToHashSet();
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    int firstNum = nums[i];
                    for (int j = i + 1; j < nums.Length - 1; j++)
                    {
                        int secondNum = nums[j];

                        var remainder = (secondNum + firstNum) * -1;

                        if (uniqueNums.Contains(remainder))
                        {
                            for (int k = j + 1; k < nums.Length; k++)
                            {
                                int thirdNum = nums[k];
                                if (thirdNum == remainder)
                                {
                                    uniqueKeys.Add((firstNum, secondNum, thirdNum));
                                    break;
                                }
                            }
                        }
                    }
                }

                returnValue.AddRange(uniqueKeys.Select(x => new List<int>() { x.Item1, x.Item2, x.Item3 }));
            }

            return returnValue;
        }

        public IList<IList<int>> ThreeSumTest2(int[] nums)
        {

            List<IList<int>> returnValue = new List<IList<int>>();
            HashSet<string> uniqueKeys = new HashSet<string>();
            if (nums != null && nums.Length > 2)
            {
                Array.Sort(nums);
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    int firstNum = nums[i];
                    for (int j = i + 1; j < nums.Length - 1; j++)
                    {
                        int secondNum = nums[j];

                        if (!uniqueKeys.Any(x => x.Contains($"{firstNum}") && x.Contains($"{secondNum}")))
                        {
                            for (int k = j + 1; k < nums.Length; k++)
                            {
                                int thirdNum = nums[k];
                                if (thirdNum + firstNum + secondNum == 0)
                                {
                                    int[] arry = new int[3] { firstNum, secondNum, thirdNum };
                                    uniqueKeys.Add($"{firstNum},{secondNum},{thirdNum}");

                                    //Array.Sort(arry);
                                    returnValue.Add(arry);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/3sum/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("3Sum")]
        [TestCaseSource("Input")]
        public void Test1((IList<IList<int>> Output, int[] Input) item)
        {
            var response = ThreeSumTest(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(IList<IList<int>> Output, int[] Input)> Input
        {
            get
            {
                return new List<(IList<IList<int>> Output, int[] Input)>()
                {

                    (new List<IList<int>>()
                    {
                        new List<int>(){-1,-1,2},
                        new List<int>(){-1,0,1}
                    }, new int[] {-1,0,1,2,-1,-4}),
                    (null, new int[0]),
                    (null, new int[] {0}),
                };
            }
        }
    }
}
