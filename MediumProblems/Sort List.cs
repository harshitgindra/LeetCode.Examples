using LeetCode.SharedUtils;


namespace LeetCode.MediumProblems
{
    class SortListSolution
    {
        public ListNode SortList(ListNode head)
        {
            // Base case: empty list or single node is already sorted
            if (head == null || head.next == null)
            {
                return head;
            }

            // Split the list into two halves
            ListNode middle = GetMiddle(head);
            ListNode right = middle.next;
            middle.next = null; // Disconnect the two halves

            // Recursively sort both halves
            ListNode left = SortList(head);
            right = SortList(right);

            // Merge the sorted halves
            return Merge(left, right);
        }

        // Find the middle of the linked list using slow/fast pointers
        private ListNode GetMiddle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            return slow;
        }

        // Merge two sorted linked lists
        private ListNode Merge(ListNode left, ListNode right)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;

            // Compare nodes and link them in sorted order
            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    current.next = left;
                    left = left.next;
                }
                else
                {
                    current.next = right;
                    right = right.next;
                }

                current = current.next;
            }

            // Attach remaining nodes (if any)
            current.next = (left != null) ? left : right;

            return dummy.next;
        }

        [Test(Description = "https://leetcode.com/problems/sort-list/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Sort List")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int?[] Output, int[] Input) item)
        {
            var response = SortList(item.Input.ToListNode());
            Assert.That(response.ToArray(), Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input =>
            new List<(int[] Output, int[] Input)>()
            {
                ([-1, 0, 3, 4, 5], ( [-1, 5, 3, 4, 0])),
            };
    }
}