namespace LeetCode
{
    public class Intersection_of_Two_Arrays_II
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return Find(nums2, nums1);
            }

            return Find(nums1, nums2);
        }

        public int[] Find(int[] startLoop, int[] arry)
        {
            List<int> secondList = arry.ToList();
            List<int> common = new List<int>();
            
            foreach (var item in startLoop)
            {
                if (secondList.Contains(item))
                {
                    secondList.Remove(item);
                    common.Add(item);
                }
            }

            return common.ToArray();
        }
    }
}
