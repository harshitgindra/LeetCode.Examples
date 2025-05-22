namespace LeetCode.EasyProblems;

/// <summary>
/// https://leetcode.com/problems/assign-cookies/
/// </summary>
public class AssignCookies
{
    public int FindContentChildren(int[] greed, int[] cookieSize)
    {
        // Sort the greed factors and cookie sizes in ascending order
        Array.Sort(greed);       // O(n log n), where n = greed.Length
        Array.Sort(cookieSize);  // O(m log m), where m = cookieSize.Length

        int child = 0;   // Pointer for greed array (children)
        int cookie = 0;  // Pointer for cookieSize array (cookies)
        int count = 0;   // Number of content children

        // Try to satisfy each child with the smallest sufficient cookie
        while (child < greed.Length && cookie < cookieSize.Length)
        {
            if (greed[child] <= cookieSize[cookie])
            {
                // If the current cookie can satisfy the current child
                count++;    // Increment content children count
                child++;    // Move to next child
            }
            // Move to next cookie in either case
            cookie++;
        }
        return count;
    }
}