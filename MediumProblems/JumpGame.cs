namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/jump-game/
/// </summary>
public class JumpGame
{
    public bool CanJump(int[] nums) {
        // Tracks the farthest reachable index from current position
        int lastReachable = nums.Length - 1;
        
        // Check positions in reverse (from second-last to first)
        for (int i = nums.Length - 2; i >= 0; i--) {
            // Update last reachable index if current position can reach it
            if (i + nums[i] >= lastReachable) {
                lastReachable = i;
            }
        }
        
        // Start index is reachable if we propagated reachability to position 0
        return lastReachable == 0;
    }
}