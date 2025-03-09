namespace LeetCode.MediumProblems
{
    class Remove_Interval
    {
        public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            int toBeRemovedStart = toBeRemoved[0];
            int toBeRemovedEnd = toBeRemoved[0];

            foreach (var item in intervals)
            {
                var i = item[0];
                var j = item[1];
                if (j <= toBeRemovedStart || i >= toBeRemovedEnd)
                {
                    //***
                    //*** do nothing
                    //***
                    ret.Add(item);
                }
                else
                {
                    if (j > toBeRemovedStart && i < toBeRemovedStart)
                    {
                        ret.Add(new List<int>() { i, toBeRemovedStart });
                    }

                    if (i < toBeRemovedEnd && j > toBeRemovedEnd)
                    {
                        ret.Add(new List<int>() { toBeRemovedEnd, j,  });
                    }
                }
            }

            return ret;
        }


        [Test(Description = "https://leetcode.com/problems/remove-interval/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Remove Interval")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<IList<int>> Output, (int[][], int[]) Input) item)
        {
            var response = RemoveInterval(item.Input.Item1, item.Input.Item2);
        }

        public static IEnumerable<(IList<IList<int>> Output, (int[][], int[]) Input)> Input
        {
            get
            {
                return new List<(IList<IList<int>> Output, (int[][], int[]) Input)>()
                {

                    (null, (new int[3][]
                    {
                        new int[]{0,2},
                        new int[]{3,4},
                        new int[]{5,7},
                    }, new int[]{1,6})),
                };
            }
        }
    }
}
