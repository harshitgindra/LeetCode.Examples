using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Asteroid_Collision
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            List<int> returnValue = new List<int>();

            for (int i = 0; i < asteroids.Length; i++)
            {
                var item1 = asteroids[i];

                if (item1 != 0)
                {
                    returnValue.Add(item1);
                    int j = i + 1;
                    while (true)
                    {
                        var item2 = asteroids[j];

                        if (item2 != 0)
                        {
                            if (item1 > 0 && item2 > 0 || item1 < 0 && item2 < 0)
                            {
                                break;
                            }
                            if (item2 < 0)
                            {
                                if (item1 == item2 * -1)
                                {
                                    returnValue.RemoveAt(returnValue.Count - 1);
                                    asteroids[j] = 0;
                                }
                                else if (item1 > Math.Abs(item2))
                                {
                                    asteroids[j] = 0;
                                }
                                else if (item1 < Math.Abs(item2))
                                {
                                    returnValue.RemoveAt(returnValue.Count - 1);
                                    returnValue.Add(item2);
                                    j++;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }


                    //for (int j = i + 1; j < asteroids.Length; j++)
                    //{

                    //}
                }
            }


            return returnValue.ToArray();
        }

        [Test(Description = "https://leetcode.com/problems/asteroid-collision/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Asteroid Collision")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = AsteroidCollision(item.Input);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {

                    //(new int[]{ 5,10}, new int[]{5, 10, -5 }),
                    //(new int[]{ }, new int[]{8,-8 }),
                    (new int[]{ 10}, new int[]{10, 2, -5}),
                    //(new int[]{ -2, -1, 1, 2}, new int[]{-2, -1, 1, 2 }),
                };
            }
        }
    }
}
