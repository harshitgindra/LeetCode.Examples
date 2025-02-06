namespace LeetCode.MediumProblems
{
    class Meeting_Rooms_II
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            int[] start = new int[intervals.Length];
            int[] end = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                start[i] = intervals[i][0];
                end[i] = intervals[i][1];
            }

            Array.Sort(start);
            Array.Sort(end);

            int ret = 0;
            for (int i = 0, j = 0; i < start.Length; i++)
            {
                if (start[i] < end[j])
                {
                    ret++;
                }
                else
                {
                    j++;
                }
            }

            return ret;
        }
    }
}
