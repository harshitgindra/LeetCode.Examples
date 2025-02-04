using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using SharedUtils;

namespace LeetCode.Easy
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
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, ListNode Input) item)
        {
            var response = HasCycle(item.Input);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, ListNode Input)> Input
        {
            get
            {
                return new List<(ListNode Output, ListNode Input)>()
                {

                    (new ListNode(1, new ListNode(3, new ListNode(2, new ListNode(1)))),
                    new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))))),
                };
            }
        }
    }
}
