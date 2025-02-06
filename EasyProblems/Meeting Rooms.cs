namespace LeetCode.EasyProblems
{
    class Meeting_Rooms
    {
        public bool CanAttendMeetings(int[][] intervals)
        {
            var ints = intervals.OrderBy(x => x[0]);

            HashSet<int> dict = new HashSet<int>();
            for (int i = 0; i < ints.Count(); i++)
            {
                var item1 = intervals[i];
                for (int j = item1[0]; i < item1[1]; i++)
                {
                    if (!dict.Add(j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //[Test(Description = "https://leetcode.com/problems/meeting-rooms/")]
        //[Category("Easy")]
        //[Category("LeetCode")]
        //[Category("Find the Town Judge")]
        //[TestCaseSource("Input")]
        //public void Test1((int Output, int[][] Input) item)
        //{
        //    var response = CanAttendMeetings(item.Input);
        //    ClassicAssert.AreEqual(item.Output, response);
        //}

        //public static IEnumerable<(int Output, int[][] Input)> Input
        //{
        //    get
        //    {
        //        return new List<(int Output, (int, int[][]) Input)>()
        //        {
        //            (null, (null, null))
        //        };
        //    }
        //}
    }
}
