namespace LeetCode.EasyProblems
{
    public class Find_Common_Characters
    {
        public IList<string> CommonChars(string[] A)
        {
            var wordA = A[0].ToList();

            for (int i = 1; i < A.Length; i++)
            {
                List<char> tempStore = new List<char>();
                foreach (var item in A[i])
                {
                    if (wordA.Contains(item))
                    {
                        tempStore.Add(item);
                        wordA.Remove(item);
                    }
                }
                wordA = tempStore;
            }
            return wordA.Select(x => x.ToString()).ToList();
        }
    }
}
