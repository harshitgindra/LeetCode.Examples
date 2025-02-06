namespace LeetCode.EasyProblems
{
    class Rotate_String
    {
        public bool RotateString(string A, string B)
        {
            if (A.Length != B.Length) return false;
            return (B + B).IndexOf(A) != -1;
        }
    }
}
