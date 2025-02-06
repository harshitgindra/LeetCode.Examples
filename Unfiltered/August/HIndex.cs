namespace LeetCode.August
{
    public class HIndexTest
    {
        public int HIndex(int[] citations)
        {
            int hIndex = 0;
            int tempCounter = 0;
            while (true)
            {
                var count = citations.Count(x => x >= tempCounter);
                if (count < tempCounter)
                {
                    break;
                }

                if (tempCounter <= count && tempCounter > hIndex)
                {
                    hIndex = tempCounter;
                }

                tempCounter++;
            }

            return hIndex;
        }
    }
}
