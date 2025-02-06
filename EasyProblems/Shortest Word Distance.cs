namespace LeetCode.EasyProblems
{
    class Shortest_Word_Distance
    {
        /// <summary>
        /// https://leetcode.com/problems/shortest-word-distance/
        /// </summary>
        /// <param name="words"></param>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            var itema = Int32.MaxValue;
            var itemb = Int32.MaxValue;

            int retVal = Int32.MaxValue;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                {
                    retVal = Math.Min(retVal, Math.Abs(i - itemb));
                    itema = i;
                }
                else if (words[i] == word2)
                {
                    retVal = Math.Min(retVal, Math.Abs(i - itema));
                    itemb = i;
                }
            }
            return retVal;
        }
    }
}
