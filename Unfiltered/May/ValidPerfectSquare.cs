namespace LeetCode.May
{
    public class ValidPerfectSquare
    {
        public bool IsPerfectSquare(int num)
        {
            var t = Math.Log(num, 2);
            return t % 1 == 0;
        }
    }
}