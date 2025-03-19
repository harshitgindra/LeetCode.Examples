

namespace LeetCode.MediumProblems
{
    class Meeting_Scheduler
    {
        public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
        {
            IList<int> ret = new List<int>();
            Array.Sort(slots1, (a, b) => a[0].CompareTo(b[0]));
            Array.Sort(slots2, (a, b) => a[0].CompareTo(b[0]));

            if (slots2.Length != 0 && slots1.Length != 0)
            {
                int i = 0, j = 0;
                while (i < slots1.Length && j < slots2.Length)
                {
                    var itema = slots1[i];
                    var itemb = slots2[j];

                    var diff = Math.Min(itema[1], itemb[1]) - Math.Max(itema[0], itemb[0]);
                    if (diff >= duration)
                    {
                        var fNum = Math.Max(itema[0], itemb[0]);
                        ret.Add(fNum);
                        ret.Add(fNum + duration);
                        break;
                    }
                    else
                    {
                        if (itema[0] > itemb[0])
                        {
                            j++;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }

            return ret;
        }

        [Test(Description = "https://leetcode.com/problems/meeting-scheduler/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Meeting Scheduler")]
        [TestCaseSource(nameof(Input))]
        public void Test1((List<int> Output, (int[][], int[][], int) Input) item)
        {
            var response = MinAvailableDuration(item.Input.Item1, item.Input.Item2, item.Input.Item3);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(List<int> Output, (int[][], int[][], int) Input)> Input
        {
            get
            {
                return new List<(List<int> Output, (int[][], int[][], int) Input)>()
                {

                    (new List<int>(){ 60,68}, (new int[][]{
                        new int[]{10,50 },
                        new int[]{60,120 },
                        new int[]{140,210 },
                        },
                    new int[][]{
                        new int[]{0,15 },
                        new int[]{60,70 },
                        },
                    8
                    )),
                    (new List<int>(){}, (new int[][]{
                        new int[]{10,50 },
                        new int[]{60,120 },
                        new int[]{140,210 },
                        },
                    new int[][]{
                        new int[]{0,15 },
                        new int[]{60,70 },
                        },
                    12
                    )),
                };
            }
        }
    }
}
