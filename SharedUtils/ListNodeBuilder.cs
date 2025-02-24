namespace LeetCode.SharedUtils
{
    public static class ListNodeBuilder
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
        
        /// <summary>
        /// Builds a linked list from an array of integers.
        /// </summary>
        /// <param name="array">The array of integers.</param>
        /// <returns>The head of the linked list.</returns>
        public static ListNode BuildListNode(int[] array)
        {
            if (array == null || array.Length == 0)
                return null;

            ListNode head = new ListNode(array[0]);
            ListNode current = head;

            for (int i = 1; i < array.Length; i++)
            {
                current.next = new ListNode(array[i]);
                current = current.next;
            }

            return head;
        }
        
        /// <summary>
        /// Asserts if a linked list matches an array of integers.
        /// </summary>
        /// <param name="listNode">The head of the linked list.</param>
        /// <param name="array">The array of integers.</param>
        /// <returns>True if the linked list matches the array, false otherwise.</returns>
        public static bool AssertListNode(ListNode listNode, int[] array)
        {
            if (array == null && listNode == null)
                return true;

            if (array == null || listNode == null)
                return false;

            if (array.Length == 0 && listNode == null)
                return true;

            if (array.Length == 0 || listNode == null)
                return false;

            int index = 0;
            ListNode current = listNode;

            while (current != null && index < array.Length)
            {
                if (current.val != array[index])
                    return false;

                current = current.next;
                index++;
            }

            // Check if there are remaining elements in either the array or the list
            return current == null && index == array.Length;
        }
    }
}
