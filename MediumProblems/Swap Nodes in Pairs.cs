using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;


namespace LeetCode.MediumProblems
{
    class Swap_Nodes_in_Pairs
    {
        public ListNode SwapPairs(ListNode head)
        {
            ListNode returnValue = default;
            returnValue = Map(head, returnValue);

            return returnValue;
        }

        private ListNode Map(ListNode a, ListNode result)
        {
            if (a?.next != null)
            {
                result = new ListNode(a.next.val, new ListNode(a.val));

                result.next.next = Map(a.next.next, result.next.next);
            }
            else if (a != null)
            {
                result = new ListNode(a.val);
            }

            return result;
        }


        [Test(Description = "https://leetcode.com/problems/swap-nodes-in-pairs/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Swap Nodes in Pairs")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = SwapPairs(item.Input.ToListNode());
            Assert.That(response.ToArray(), Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input =>
            new List<(int[] Output, int[] Input)>()
            {
                ([2, 1, 4, 3],
                    [1, 2, 3, 4]),
            };
    }
}