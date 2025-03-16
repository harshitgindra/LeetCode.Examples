namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/add-digits/
    /// </summary>
    class Add_Digits
    {
        public int AddDigits(int num) {
            if(num == 0)
                return 0;
            int returnValue = num % 9;
            return returnValue == 0 ? 9 : returnValue;
        }
    }
}
