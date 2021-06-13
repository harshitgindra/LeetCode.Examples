using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode.Problems.Common;
using NUnit.Framework;

namespace Leetcode.Problems.Hard
{
    class Minimum_Number_of_Refueling_Stops
    {
        private int _minimum;
        public int MinRefuelStops(int target, int startFuel, int[][] stations)
        {
            _minimum = Int32.MaxValue;
            _StartFueling(target, startFuel, 0, 0, stations);

            if (_minimum.Equals(Int32.MaxValue))
            {
                _minimum = -1;
            }
            return _minimum;
        }

        private void _StartFueling(int remainingTarget, int fuelRemaining, int timesRefueled, int i, int[][] stations)
        {
            if (remainingTarget <= fuelRemaining)
            {
                _minimum = timesRefueled;
            }
            else if (_minimum <= timesRefueled)
            {
                //***
                //*** Already crossed the last minimum record
                //***
            }
            else
            {
                for (int j = i; j < stations?.Length; j++)
                {
                    var station = stations[j];

                    if (station[0] > fuelRemaining)
                    {
                        break;
                    }
                    else
                    {
                        _StartFueling(remainingTarget, fuelRemaining + station[1],
                            timesRefueled + 1, j + 1, stations);
                    }
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/minimum-number-of-refueling-stops/")]
        [Category("Hard")]
        [Category("Leetcode")]
        [Category("Minimum Number of Refueling Stops")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int target, int startFuel, int[][] stations) Input) item)
        {
            var response = MinRefuelStops(item.Input.target, item.Input.startFuel, item.Input.stations);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int target, int startFuel, int[][] stations) Input)> Input
        {
            get
            {
                return new List<(int Output, (int target, int startFuel, int[][] stations) Input)>()
                {

                    (2,(100, 10, new int[4][]
                        {
                            new int[]{10,60},
                            new int[]{20,30},
                            new int[]{30,30},
                            new int[]{60,40},
                        })
                    ),

                    (-1,(100, 1, new int[4][]
                        {
                            new int[]{10,60},
                            new int[]{20,30},
                            new int[]{30,30},
                            new int[]{60,40},
                        })
                    ),

                    (0,(1, 1, null)
                    ),

                    (3,(100, 25, new int[3][]
                        {
                            new int[]{25,25},
                            new int[]{50,25},
                            new int[]{75,25},
                        })
                    ),

                    (-1,(1000, 83, new int[][]
                        {
                            new int[]{25,27},
                            new int[]{36,187},
                            new int[]{140,186},
                            new int[]{378,6},
                            new int[]{492,20},
                            new int[]{517,89},
                            new int[]{579,234},
                            new int[]{673, 86},
                            new int[]{808,53},
                            new int[]{954,49},
                        })
                    ),

                    (2,(200, 50, new int[][]
                        {
                            new int[]{25,25},
                            new int[]{50,100},
                            new int[]{100,100},
                            new int[]{150,40},
                        })
                    ),
                };
            }
        }
    }
}
