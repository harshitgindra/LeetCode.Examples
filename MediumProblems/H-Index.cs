namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/h-index/
/// </summary>
public class H_Index
{
    public int HIndex(int[] citations)
    {
        int[] counts = new int[citations.Length + 1];

        foreach (var item in citations)
        {
            if (item >= citations.Length)
            {
                counts[citations.Length]++;
            }
            else
            {
                counts[item]++;
            }
        }

        int totalCitations = 0;

        for (int i = counts.Length - 1; i >= 0; i--)
        {
            totalCitations += counts[i];
            if (totalCitations >= i)
            {
                return i;
            }
        }

        return 0;
    }
}