using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Car_Pooling
    {
        public bool CarPooling(int[][] trips, int capacity)
        {
            if (trips == null || !trips.Any())
            {
                return true;
            }
            else if (trips.Length == 1)
            {
                return true;
            }
            else
            {
                int[] passengers = new int[1001];
                foreach (var trip in trips)
                {
                    passengers[trip[1]] += trip[0];
                    passengers[trip[2]] -= trip[0];
                }

                int currentCapacity = 0;
                for (int i = 0; i < passengers.Length; i++)
                {
                    currentCapacity += passengers[i];
                    if (currentCapacity > capacity)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        [Test(Description = "https://leetcode.com/problems/car-pooling/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Car Pooling")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (int[][], int) Input) item)
        {
            var response = CarPooling(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (int[][], int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int[][], int) Input)>()
                {

                    (false, (new int[2][] {new int[]{ 2, 1, 5 }, new int[]{ 3, 3, 7 } }, 4)),
                    (true, (new int[2][] {new int[]{ 2, 1, 5 }, new int[]{ 3, 3, 7 } }, 5)),
                    (true, (new int[2][] {new int[]{ 2, 1, 5 }, new int[]{ 3, 5, 7 } }, 3)),
                    (true, (new int[3][] {new int[]{ 3,2,7 }, new int[]{ 3, 7, 9 } ,  new int[]{ 8,3,9 } }, 11)),
                    (true, (new int[3][] {new int[]{ 2,2,6 }, new int[]{ 2,4,7 } ,  new int[]{ 8,6,7 } }, 11)),
                };
            }
        }
    }
}
