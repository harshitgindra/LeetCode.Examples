namespace LeetCode.August
{
    public class Minimum_Cost_For_Tickets
    {
        public int MincostTickets(int[] days, int[] costs)
        {
            bool[] dayIncluded = new bool[days[days.Length - 1] + 1];
            foreach (var item in days)
            {
                dayIncluded[item] = true;
            }

            int[] minCost = new int[dayIncluded.Length];
            minCost[0] = 0;
            for (int day = 1; day < dayIncluded.Length; ++day)
            {
                if (!dayIncluded[day])
                {
                    //****
                    //**** No plan to travel; skip the day
                    //****
                    minCost[day] = minCost[day - 1];
                    continue;
                }
                //***
                //*** Adding one day ticket cost
                //***
                int min = minCost[day - 1] + costs[0];
                //***
                //*** Adding 7 day ticket cost
                //***
                int resp7 = minCost[Math.Max(0, day - 7)] + costs[1];
                min = Math.Min(min, resp7);
                //***
                //*** Adding 30 day ticket cost
                //***
                int resp30 = minCost[Math.Max(0, day - 30)] + costs[2];
                min = Math.Min(min, resp30);
                minCost[day] = min;
            }

            return minCost[dayIncluded.Length - 1];
        }
    }
}
