﻿

namespace LeetCode.EasyProblems
{
    class Duplicate_Zeros
    {
        public void DuplicateZeros(int[] arr)
        {
            int index = 0;
            while (index < arr.Length - 1)
            {
                if (arr[index] == 0)
                {
                    int tempIndex = arr.Length - 2;

                    while (tempIndex > index)
                    {
                        arr[tempIndex + 1] = arr[tempIndex];
                        tempIndex--;
                    }
                    index++;
                    arr[index] = 0;
                }
                index++;
            }
        }

        [Test(Description = "https://leetcode.com/problems/duplicate-zeros/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Duplicate Zeros")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            DuplicateZeros(item.Input);
            Assert.That(item.Input, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    ([1,0,0,2,3,0,0,4], [1,0,2,3,0,4,5,0]),
                    ([1,2,3], [1,2,3]),
                    ([0,0,0,0,0,0,0], [0,0,0,0,0,0,0]),
                };
            }
        }
    }
}
