using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Delete_Node_in_a_Linked_List
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n, int currentNode = 1)
        {
            var response = Process(head, n, 0);
            return response.Item1;
        }

        private (ListNode, int) Process(ListNode head, int n, int currentNode)
        {
            if (head == null)
            {
                return (head, currentNode);
            }
            else
            {
                var response = Process(head.next, n, currentNode + 1);
                if (response.Item2 - n == currentNode)
                {
                    head = head.next;
                }
                else
                {
                    head.next = response.Item1;
                }

                return (head, response.Item2);
            }
        }

        [Test(Description = "https://leetcode.com/problems/remove-nth-node-from-end-of-list/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Remove Nth Node From End of List")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, (ListNode, int) Input) item)
        {
            var response = RemoveNthFromEnd(item.Input.Item1, item.Input.Item2);
            //Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, (ListNode, int) Input)> Input
        {
            get
            {
                return new List<(ListNode Output, (ListNode, int) Input)>()
                {

                    (new ListNode(1, new ListNode(2, new ListNode(4))),
                    (new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))),2)
                    ),
                };
            }
        }
    }
}
