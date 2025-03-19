

namespace LeetCode.MediumProblems
{
    public class Contiguous_Array
    {
        public int FindMaxLength(int[] nums)
        {
            int returnValue = 0;

            if (nums != null && nums.Length > 0)
            {
                IDictionary<int, int> dictionary = new Dictionary<int, int>();
                dictionary.Add(0, -1);
                int sum = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                    {
                        sum--;
                    }
                    else
                    {
                        sum++;
                    }

                    if (dictionary.ContainsKey(sum))
                    {
                        returnValue = Math.Max(returnValue, i - dictionary[sum]);
                    }
                    else
                    {
                        dictionary.Add(sum, i);
                    }
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/contiguous-array/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Contiguous Array")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = FindMaxLength(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (2, new int[] {0, 1}),
                    (2, new int[] {0, 1, 1}),
                    (2, new int[] {0, 1, 0}),
                };
            }
        }
    }
}