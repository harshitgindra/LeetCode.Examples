namespace LeetCode.HardProblems
{
    class MergeKSortedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            // Handle edge cases
            if (lists == null || lists.Length == 0) return null;

            // Start the divide-and-conquer process
            return MergeDivideAndConquer(lists, 0, lists.Length - 1);
        }

        private ListNode MergeDivideAndConquer(ListNode[] lists, int left, int right)
        {
            // Base case: only one list in the current range
            if (left == right) return lists[left];

            // Divide the problem into two halves
            int mid = left + (right - left) / 2;
            ListNode leftList = MergeDivideAndConquer(lists, left, mid);
            ListNode rightList = MergeDivideAndConquer(lists, mid + 1, right);

            // Merge the two halves
            return MergeTwoLists(leftList, rightList);
        }

        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            // Create a dummy head to simplify edge cases
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            // Compare and link nodes in sorted order
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    current.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    current.next = l2;
                    l2 = l2.next;
                }

                current = current.next;
            }

            // Attach remaining nodes (if any)
            current.next = (l1 != null) ? l1 : l2;

            return dummy.next;
        }


        [Test(Description = "https://leetcode.com/problems/merge-k-sorted-lists/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Merge K Sorted Lists")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[][] Input) item)
        {
            var response = MergeKLists(item.Input.Select(x => x.ToListNode()).ToArray());
            Assert.That(response.ToArray(), Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[][] Input)> Input =>
            new List<(int[] Output, int[][] Input)>()
            {
                ([1, 1, 2, 3, 4, 4, 5, 6], ( [[1, 4, 5], [1, 3, 4], [2, 6]])),
            };
    }
}