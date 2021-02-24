using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Reverse_Linked_List
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode prev = null;
            ListNode cur = head;

            while (cur != null)
            {
                ListNode post = cur.next;
                cur.next = prev;
                prev = cur;
                cur = post;
            }

            return prev;
        }

        [Test(Description = "https://leetcode.com/problems/reverse-linked-list/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Reverse Linked List")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, ListNode Input) item)
        {
            var response = ReverseList(item.Input);
            //Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, ListNode Input)> Input
        {
            get
            {
                return new List<(ListNode Output, ListNode Input)>()
                {

                    (new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(1)))),
                    new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))))),
                };
            }
        }
    }
}
