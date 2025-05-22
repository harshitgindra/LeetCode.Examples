namespace LeetCode.MediumProblems;
/// <summary>
/// https://leetcode.com/problems/factorial-trailing-zeroes/
/// </summary>
public class FactorialTrailingZeroes
{
    public int TrailingZeroes(int n)
    {
        // To count trailing zeroes in n!, count the number of times 5 is a factor in the sequence 1..n
        // Because 5 * 2 = 10, and 2s are more common, count only the 5s.
        int trailingZeroes = 0;

        // Iterate and divide n by 5, adding the quotient each time
        // This counts all factors of 5, 25, 125, etc. in n!
        while (n >= 5)
        {
            n /= 5;
            trailingZeroes += n;
        }

        return trailingZeroes;
    }
}