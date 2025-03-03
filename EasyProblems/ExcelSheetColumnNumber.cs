namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/excel-sheet-column-number/
    /// </summary>
    public class ExcelSheetColumnNumber
    {
        /// <summary>
        /// Converts a title (e.g., "A", "B", "Z", "AA", etc.) to its corresponding number.
        /// </summary>
        /// <param name="s">The title string.</param>
        /// <returns>The numerical value of the title.</returns>
        public int TitleToNumber(string s)
        {
            int total = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                // Calculate the value of the character at the current position.
                int charValue = s[i] - 64; // 'A' is 65, so subtract 64 to get 1-based value.
                int positionalValue = (int)Math.Pow(26, s.Length - 1 - i) * charValue;

                // Add the positional value to the total.
                total += positionalValue;
            }

            return total;
        }

    }
}
