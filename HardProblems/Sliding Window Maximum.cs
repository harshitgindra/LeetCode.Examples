namespace LeetCode.HardProblems
{
    public class Sliding_Window_Maximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            var response = FindHighest(nums, 0, 0, -1, k);

            List<int> result = new List<int>() {response.Max};
            for (int i = 1; i <= nums.Length - k; i++)
            {
                response = FindHighest(nums, i, response.Max, response.Index, k);
                result.Add(response.Max);
            }

            return result.ToArray();
        }

        private (int Max, int Index) FindHighest(int[] nums, int start, int lastMax, int lastMaxIndex, int k)
        {
            if (start <= lastMaxIndex)
            {
                if (nums[start + k - 1] >= lastMax)
                {
                    return (nums[start + k - 1], start + k - 1);
                }
                else
                {
                    return (lastMax, lastMaxIndex);
                }
            }
            else
            {
                int max = Int32.MinValue;
                int index = 0;
                for (int i = start; i < start + k; i++)
                {
                    if (nums[i] > max)
                    {
                        index = i;
                        max = nums[i];
                    }
                }

                return (max, index);
            }
        }

        [Test(Description = "https://leetcode.com/problems/sliding-window-maximum/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Sliding Window Maximum")]
        [TestCaseSource(nameof(Input))]
        [Ignore("")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            // var response = MaxSlidingWindow(item.Input.Item1, item.Input.Item2);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                    (4, (new int[] {1, 3, -1, -3, 5, 3, 6, 7}, 3)),
                };
            }
        }
    }
}