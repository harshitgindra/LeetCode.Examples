namespace LeetCode.August
{
    public class FindAllDuplicatesInAnArray
    {
        public static IList<int> FindDuplicates(int[] nums)
        {
            List<int> uniqueList = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var initialIndexValue = Math.Abs(nums[i]);
                var numValue = nums[initialIndexValue - 1];
                if (numValue < 0)
                {
                    uniqueList.Add(initialIndexValue);
                }
                nums[initialIndexValue - 1] = -numValue;
            }

            return uniqueList;

            //HashSet<int> tempList = new HashSet<int>();
            //HashSet<int> uniqueList = new HashSet<int>();
            //foreach (var num in nums)
            //{
            //    if (!tempList.Add(num))
            //    {
            //        uniqueList.Add(num);
            //    }
            //}

            //return uniqueList.ToList();


            //var response = nums.GroupBy(x => x)
            //    .Where(x => x.Count() == 2)
            //    .Select(x => x.Key)
            //    .ToList();

            //return response;
        }
    }
}
