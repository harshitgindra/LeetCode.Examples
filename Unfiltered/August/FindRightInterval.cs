namespace LeetCode.August
{
    public class FindRightIntervalTest
    {
        public int[] FindRightInterval(int[][] intervals)
        {
            SortedList<int, int> firstItems = new SortedList<int, int>();
            int index = 0;
            foreach (var item in intervals)
            {
                firstItems.Add(item[0], index);
                index++;
            }

            int[] returnValue = new int[intervals.Length];
            int maxNum = firstItems.Last().Key;

            for (int i = 0; i < intervals.Length; i++)
            {
                int num = intervals[i][1];

                if (firstItems.ContainsKey(num))
                {
                    returnValue[i] = firstItems[num];
                }
                else
                {
                    while (true)
                    {
                        num++;
                        if (firstItems.ContainsKey(num))
                        {
                            returnValue[i] = firstItems[num];
                            break;
                        }

                        if (num >= maxNum)
                        {
                            returnValue[i] = -1;
                            break;
                        }
                    }
                }
            }

            return returnValue;

        }
    }
}
