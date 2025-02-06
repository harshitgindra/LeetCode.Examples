namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/add-digits/
    /// </summary>
    class Add_Digits
    {
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

        public int AddDigits(int num)
        {
            if (num > 9)
            {
                var str = num.ToString();
                var sum = 0;
                foreach (var item in str)
                {
                    sum += dict[item];
                }
                return AddDigits(sum);
            }
            else
            {
                return num;
            }
        }
    }
}
