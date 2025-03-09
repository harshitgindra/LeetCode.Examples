using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;


namespace LeetCode.EasyProblems
{
    class Linked_List_Cycle
    {
        public bool HasCycle(ListNode head)
        {
            ListNode fast = head, slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (slow == fast)
                {
                    return true;
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/linked-list-cycle/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Linked List Cycle")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, int[] Input) item)
        {
            var listNode = ListNodeBuilder.BuildListNode(item.Input);
            HasCycle(listNode);
        }

        public static IEnumerable<(bool Output, int[] Input)> Input =>
            new List<(bool Output, int[] Input)>()
            {

                (true, [3,2,0,4,2]),
            };
    }
}
