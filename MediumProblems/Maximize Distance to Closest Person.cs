﻿

namespace LeetCode.MediumProblems
{
    class Maximize_Distance_to_Closest_Person
    {
        public int MaxDistToClosest(int[] seats)
        {
            int returnValue = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                int left = 0;
                int lIndex = i;
                if (seats[i] == 0)
                {
                    // check left
                    while (lIndex != 0)
                    {

                    }
                }
            }
            return 0;
        }

        [Test(Description = "https://leetcode.com/problems/3sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("3Sum")]
        [TestCaseSource(nameof(Input))]
        [Ignore("")]
        public void Test1((int Output, int[] Input) item)
        {
            // var response = MaxDistToClosest(item.Input);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input =>
            new List<(int Output, int[] Input)>()
            {
                (2, [1,0,0,0,1,0,1]),
                // (3, [1,0,0,0]),
                // (1, [0,1])
            };
    }
}
