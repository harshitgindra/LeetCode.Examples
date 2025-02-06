namespace LeetCode
{
    public class Rotate_Array
    {
        public void Rotate(int[] nums, int k)
        {
            IDictionary<int, int> calc = new Dictionary<int, int>();
            int nLength = nums.Length;
            for (int i = 0; i < nLength; i++)
            {
                int newPosition = (i + k);
                while (newPosition >= nLength)
                {
                    newPosition = Math.Abs(newPosition - nLength);
                }

                calc.Add(newPosition, nums[i]);
            }

            foreach (var item in calc)
            {
                nums[item.Key] = item.Value;
            }
        }

        public void Rotate2(int[] nums, int k)
        {
            int nLength = nums.Length;
            for (int i = 0; i < k; i++)
            {
                int tempStore = nums[0];
                for (int j = 0; j < nLength - 1; j++)
                {
                    int localStore = tempStore;
                    tempStore = nums[j + 1];
                    nums[j + 1] = localStore;
                }
                nums[0] = tempStore;
            }
        }
    }
}
