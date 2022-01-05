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
                //***
                //*** Get the remainder
                //***
                int remainder = t % 60;
                //***
                //*** Check if the 60-remainder exists in the array
                //*** If exists, we can build that many pairs with total 60, hence increement sum
                //***
                sum += mod[(60 - remainder) % 60];
                //***
                //*** Increment the current remainder for remaining calculations/songs
                //***
                mod[remainder]++;
            }
            return sum;
        }
    }
}