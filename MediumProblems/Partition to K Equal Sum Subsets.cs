using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    public class Partition_to_K_Equal_Sum_Subsets
    {
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            if (nums != null && nums.Length > 1)
            {
                int sum = nums.Sum();

                if (sum % k == 0)
                {
                    var target = sum / k;

                    var usedNums = new List<int>();
                    Dictionary<int, bool> used = new Dictionary<int, bool>();

                    for (int i = 0; i < nums.Length; i++)
                    {
                        usedNums.Add(i);
                        used.Add(i, false);
                    }


                    Array.Sort(nums);
                    return StartPairing(nums, k, 0, target, used);
                }
            }

            return false;
        }

        private bool StartPairing(int[] nums, int setTarget, int total, int target, Dictionary<int, bool> numsUsed)
        {
            if (total == target)
            {
                if (setTarget == 1)
                {
                    return true;
                }
                else
                {
                    return StartPairing(nums, setTarget - 1, 0, target, numsUsed);
                }
            }
            else
            {
                int prev = -1;
                var tempCollection = numsUsed.ToDictionary(x => x.Key, y => y.Value);
                // for (int i = 0; i < numsUsed.Count; i++)
                foreach (var item in numsUsed.Where(x => !x.Value))
                {
                    //var index = numsUsed[i];
                    if (prev != nums[item.Key])
                    {
                        prev = nums[item.Key];
                        var current = total + nums[item.Key];
                        if (current <= target)
                        {
                            tempCollection[item.Key] = true;
                            if (StartPairing(nums, setTarget, current, target, tempCollection))
                            {
                                return true;
                            }

                            tempCollection[item.Key] = false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/partition-equal-subset-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Partition Equal Subset Sum")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (int[], int) Input) item)
        {
            var response = CanPartitionKSubsets(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int[], int) Input)>()
                {
                    (true, (
                        new int[]
                        {
                            724, 3908, 1444, 522, 325, 322, 1037, 5508, 1112, 724, 424, 2017, 1227, 6655, 5576, 543
                        }, 4)),
                    (true, (
                        new int[] {3832, 4539, 1487, 1527, 7, 5014, 966, 6172, 387, 6449, 569, 2401, 849, 1061, 1815},
                        5)),
                    // (true, (new int[] {4, 3, 2, 3, 5, 2, 1}, 4)),
                };
            }
        }
    }
}