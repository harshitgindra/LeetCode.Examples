namespace LeetCode.EasyProblems
{
    class Pascal_s_Triangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> results = new List<IList<int>>()
            {
            };

            if (numRows >= 1)
            {
                results.Add(new List<int>(){1});
            }
            
            int[] prev = new int[2]{1,1};
            if (numRows >= 2)
            {
                results.Add(prev);
            }
            
            for (int i = 2; i < numRows; i++)
            {
                var current = Iterate(prev);
                results.Add(current);
                prev = current;
            }

            return results;
        }

        private int[] Iterate(int[] prev)
        {
            int[] current = new int[prev.Length + 1];
            
            current[0] = prev[0];
            current[prev.Length] = prev[prev.Length - 1];

            for (int i = 1; i < prev.Length ; i++)
            {
                current[i] = prev[i - 1] + prev[i];
            }

            return current;
        }
    }
}
