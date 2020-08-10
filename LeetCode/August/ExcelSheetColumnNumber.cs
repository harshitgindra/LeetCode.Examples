using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.August
{
    public class ExcelSheetColumnNumber
    {
        public int TitleToNumber(string s)
        {
            int total = 0;
            int position = s.Length - 1;
            foreach (var item in s)
            {
                total += _PositionValue(item, position);
                position--;
            }

            return total;
        }

        private int _PositionValue(char s, int position)
        {
            var charValue = s - 64;
            return Convert.ToInt32(Math.Pow(26, position) * charValue);
        }
    }
}
