using LeetCode.SharedUtils;


namespace LeetCode.MediumProblems
{
    class Odd_Even_Linked_List
    {
        public ListNode OddEvenList(ListNode head)
        {
            var response = Build(0, head, null, null);
            return Build(response.Item1, response.Item2);
        }

        private ListNode Build(ListNode even, ListNode odd)
        {
            if (even == null)
            {
                even = odd;
            }
            else
            {
                even.next = Build(even.next, odd);
            }

            return even;
        }

        private (ListNode, ListNode) Build(int index, ListNode head, ListNode even, ListNode odd)
        {
            if (head != null)
            {
                if (index % 2 == 0)
                {
                    even = new ListNode(head.val);
                    (even.next, odd) = Build(index + 1, head.next, even.next, odd);
                }
                else
                {
                    odd = new ListNode(head.val);
                    (even, odd.next) = Build(index + 1, head.next, even, odd.next);
                }
            }

            return (even, odd);
        }

        [Test(Description = "https://leetcode.com/problems/odd-even-linked-list/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Odd Even Linked List")]
        [TestCaseSource(nameof(Input))]
        public void Test1((ListNode Output, ListNode Input) item)
        {
            var response = OddEvenList(item.Input);
        }

        public static IEnumerable<(ListNode Output, ListNode)> Input
        {
            get
            {
                return new List<(ListNode Output, ListNode)>()
                {
                    (new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))),
                    new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))))
                    )
                };
            }
        }
    }
}
