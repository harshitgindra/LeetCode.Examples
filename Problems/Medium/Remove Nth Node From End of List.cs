using Leetcode.Problems.Common;
using NUnit.Framework;
using System.Collections.Generic;

namespace LeetCode.Medium
{
    class Delete_Node_in_a_Linked_List
    {
        private int _maxNodes = 0;
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            return Process(head, n, 0);
        }

        private ListNode Process(ListNode node, int n, int position)
        {
            //***
            //*** if node is null, we are at the end of the chain
            //*** set the position as maximum nodes in the chain
            //***
            if (node == null)
            {
                _maxNodes = position;
            }
            else
            {
                //***
                //*** Read through the next node and increment the position
                //***
                node.next = Process(node.next, n, position + 1);
                //***
                //*** Replacing the node by the next in chain if
                //*** current position + n is equals to maximum nodes in the chain
                //***
                if (position + n == _maxNodes)
                {
                    node = node.next;
                }
            }

            return node;
        }


        [Test(Description = "https://leetcode.com/problems/remove-nth-node-from-end-of-list/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Remove Nth Node From End of List")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, (ListNode, int) Input) item)
        {
            var response = RemoveNthFromEnd(item.Input.Item1, item.Input.Item2);
            AssertExtensions.AreListnodesEqual(item.Output, response);
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
