namespace LeetCode.Easy
{
    public class Pairs_of_Songs_With_Total_Durations_Divisible_by_60
    {
        public int NumPairsDivisibleBy60(int[] time)
        {
            var mod = new int[60];
            int sum = 0;
            // when putting in an item, pair it with all the items put in before
            foreach (var t in time)
            {
                int seconds = t % 60;
                sum += mod[(60 - seconds) % 60];
                mod[seconds]++;
            }
            return sum;
        }
    }
}