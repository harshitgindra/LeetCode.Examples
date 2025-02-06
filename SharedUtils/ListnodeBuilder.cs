namespace LeetCode.SharedUtils
{
    public static class ListnodeBuilder
    {
        public static ListNode ToListNode(this int[] nums)
        {
            var node = Build(nums, 0, new ListNode());
            return node;
        }

        private static ListNode Build(int[] nums, int index, ListNode node)
        {
            if (nums.Length > index)
            {
                node = new ListNode(nums[index]);
                node.next = Build(nums, index + 1, node.next);
            }

            return node;
        }
    }
}
