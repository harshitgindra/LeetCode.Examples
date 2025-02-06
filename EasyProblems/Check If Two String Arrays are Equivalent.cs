namespace LeetCode.EasyProblems
{
    public class Check_If_Two_String_Arrays_are_Equivalent
    {
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            var t = string.Concat(word1);
            var u = string.Concat(word2);

            return t == u;
        }
    }
}