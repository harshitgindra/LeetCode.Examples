namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/jump-game-ii/
/// </summary>
public class JumpGameII
{
    public int Jump(int[] nums)
    {
        int jumps = 0; // Total jumps needed
        int currentEnd = 0; // Boundary of current jump range
        int farthest = 0; // Maximum reachable index

        // Iterate through all positions except last (no jump needed from end)
        for (int i = 0; i < nums.Length - 1; i++)
        {
            // Update maximum reachable index from current position
            farthest = Math.Max(farthest, i + nums[i]);

            // When reaching current boundary, make jump and update boundary
            if (i == currentEnd)
            {
                jumps++;
                currentEnd = farthest; // New reachable range for next jump
            }
        }

        return jumps; // Minimum jumps to reach end
    }
}