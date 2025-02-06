namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/add-strings/
    /// </summary>
    class Add_Strings
    {
        public string AddStrings(string num1, string num2)
        {
            var maxLength = Math.Max(num1.Length, num2.Length);

            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');

            int carry = 0;
            int[] ret = new int[maxLength];
            for (int i = maxLength - 1; i >= 0; i--)
            {
                var sum = dict[num1[i]] + dict[num2[i]] + carry;
                if (sum > 9)
                {
                    ret[i] = sum % 10;
                    carry = 1;
                }
                else
                {
                    ret[i] = sum;
                    carry = 0;
                }
            }

            var str = string.Join("", ret);
            if (carry == 1)
            {
                str = $"1{str}";
            }

            return str;
        }

        private IDictionary<char, int> dict = new Dictionary<char, int>
        {
            {'1',1 },
            {'2',2 },
            {'3',3 },
            {'4',4 },
            {'5',5 },
            {'6',6 },
            {'7',7 },
            {'8',8 },
            {'9',9 },
            {'0',0 },
        };
    }
}
