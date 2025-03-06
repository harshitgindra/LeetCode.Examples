using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Contains_Duplicate_II
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    if (i - map[nums[i]] <= k)
                    {
                        return true;
                    }
                    else
                    {
                        map[nums[i]] = i;
                    }
                }
                else
                {
                    map.Add(nums[i], i);
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/contains-duplicate-ii/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("LeetCode 219")]
        [Category("Contains Duplicate II")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (int[], int) Input) item)
        {
            var response = ContainsNearbyDuplicate(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int[], int) Input)>()
                {
                    (true, (new int[] { 1, 2, 3, 1 }, 3)),
                    (true, (new int[] { 1, 0, 1, 1 }, 1)),
                    (false, (new int[] { 1, 2, 3, 1, 2, 3 }, 2)),
                    (true, (new int[] { 99,99 }, 1)),
                };
            }
        }
    }
}