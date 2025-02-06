namespace LeetCode.Problems._2022.January
{
    /// <summary>
    /// https://leetcode.com/problems/gas-station/submissions/
    /// </summary>
    public class Gas_Station
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Sum() >= cost.Sum())
            {
                int returnValue = 0;
                int total = 0;
                for (int i = 0; i < gas.Length; i++)
                {
                    total += gas[i] - cost[i];
                    if (total < 0)
                    {
                        total = 0;
                        returnValue = i + 1;
                    }
                }

                return returnValue;
            }
            else
            {
                return -1;
            }
        }
    }
}