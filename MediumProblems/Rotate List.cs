using LeetCode.SharedUtils;


namespace LeetCode.MediumProblems
{
    class Rotate_List
    {
        public ListNode RotateRight(ListNode head, int k)
        {

            if (head == null || head.next == null) return head;
            ListNode tail = head, current = head;
            int length = 1;
            while (tail.next != null)
            {
                length++;
                tail = tail.next;
            }
            k = k % length;
            if (k == 0) return head;
            for (int i = 0; i < length - k - 1; i++)
            {
                current = current.next;
            }

            var newHead = current.next;
            tail.next = head;
            current.next = null;
            return newHead;
        }

        [Test(Description = "https://leetcode.com/problems/rotate-list/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Rotate List")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, (ListNode, int) Input) item)
        {
            var response = RotateRight(item.Input.Item1, item.Input.Item2);
           // ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, (ListNode, int) Input)> Input
        {
            get
            {
                return new List<(ListNode Output, (ListNode, int) Input)>()
                {
                    (new ListNode(3, new ListNode(4, new ListNode(1, new ListNode(2)))),

                    (new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))),2)
                    )
                };
            }
        }
    }
}
