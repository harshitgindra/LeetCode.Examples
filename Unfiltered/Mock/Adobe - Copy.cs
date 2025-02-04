using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Mock
{
    class Adobe2
    {
        public int MissingNumber(int[] nums)
        {
            Array.Sort(nums);

            var tempNum = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                if (tempNum + 1 != nums[i])
                {
                    return tempNum + 1;
                }
                else
                {
                    tempNum = nums[i];
                }
            }

            return tempNum + 1;
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = Jump(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                     (3, new int[]{ 2,3,1,1,4}),
                };
            }
        }

        public int HeightChecker(int[] heights)
        {
            int movement = 0;
            int loop = 0;
            var tempHeights = heights.ToArray();
            while (loop < heights.Length)
            {
                int element = heights[0];
                int i = 1;

                while (i > 0 && i < heights.Length)
                {
                    if (element > heights[i])
                    {
                        heights[i - 1] = heights[i];
                        heights[i] = element;
                        movement++;
                    }
                    else
                    {
                        element = heights[i];
                    }
                    i++;
                }
                loop++;
            }

            int backMovement = 0;
            loop = 0;
            while (loop < heights.Length)
            {
                int element = tempHeights[heights.Length - 1];
                int i = heights.Length - 2;

                while (i >= 0)
                {
                    if (element < tempHeights[i])
                    {
                        tempHeights[i + 1] = tempHeights[i];
                        tempHeights[i] = element;
                        backMovement++;
                    }
                    else
                    {
                        element = tempHeights[i];
                    }
                    i--;
                }
                loop++;
            }

            return Math.Min(backMovement, movement);
        }


        public bool IsLongPressedName(string name, string typed)
        {
            if (name.Length > typed.Length)
            {
                return false;
            }
            else
            {
                var nameElements = Read(name);
                var typedElements = Read(typed);

                if (nameElements.Count != typedElements.Count)
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < nameElements.Count; i++)
                    {
                        var item1 = nameElements[i];
                        var item2 = typedElements[i];

                        if (item1.Item1 != item2.Item1
                            || item1.Item2 > item2.Item2)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        private List<(char, int)> Read(string s)
        {
            List<(char, int)> elements = new List<(char, int)>();

            int i = 1;
            char element = s[0];
            int count = 1;
            while (i < s.Length)
            {
                if (s[i] == element)
                {
                    count++;
                }
                else
                {
                    elements.Add((element, count));
                    element = s[i];
                    count = 1;
                }
                i++;
            }

            elements.Add((element, count));

            return elements;
        }


        public int Jump(int[] nums)
        {

            int step = 0, currMaxPos = 0, nextMaxPos = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                nextMaxPos = Math.Max(nextMaxPos, i + nums[i]);
                if (i == currMaxPos)
                {
                    step++;
                    currMaxPos = nextMaxPos;
                }
            }

            return step;
        }
    }
}
