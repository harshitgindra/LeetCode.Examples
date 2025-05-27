using System.Text;

namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/zigzag-conversion/
/// </summary>
public class ZigzagConversion
{
    public string Convert(string s, int numRows)
    {
        if (numRows == 1) return s;

        StringBuilder result = new StringBuilder();
        int cycleLen = 2 * numRows - 2;
        int n = s.Length;

        for (int row = 0; row < numRows; row++)
        {
            for (int i = 0; i + row < n; i += cycleLen)
            {
                result.Append(s[i + row]);
                // Handle middle rows (non-top/bottom)
                if (row != 0 && row != numRows - 1 && i + cycleLen - row < n)
                {
                    result.Append(s[i + cycleLen - row]);
                }
            }
        }

        return result.ToString();
    }
}