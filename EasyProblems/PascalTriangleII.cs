namespace LeetCode.EasyProblems
{
    public class PascalTriangleII
    {
        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 1)
            {
                return new int[] { 1 };
            }
            
            int[] prev = new int[2]{1,1};
            if (rowIndex == 2)
            {
                return prev;
            }
            
            for (int i = 2; i < rowIndex; i++)
            {
                var current = Iterate(prev);
                prev = current;
            }

            return prev;
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
