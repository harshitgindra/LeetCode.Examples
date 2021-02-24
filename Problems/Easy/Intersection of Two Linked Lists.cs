using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Intersection_of_Two_Linked_Lists
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            List<int> headANodes = new List<int>();
            var nodeA = headA;
            while (nodeA != null)
            {
                headANodes.Add(nodeA.val);
                nodeA = nodeA.next;
            }

            ListNode nodeToReturn = null;
            var nodeB = headB?.next;
            while (nodeB != null)
            {
                if (headANodes.Contains(nodeB.val))
                {
                    var indexOf = headANodes.IndexOf(nodeB.val);
                    if (IsMatch(headANodes, indexOf, nodeB))
                    {
                        nodeToReturn = nodeB;
                        break;
                    }
                }

                nodeB = nodeB.next;
            }

            return nodeToReturn?.next;
        }

        private bool IsMatch(List<int> val, int index, ListNode node)
        {
            if (node == null || index >= val.Count)
            {
                return true;
            }
            else if (val.ElementAt(index) == node.val)
            {
                return IsMatch(val, index + 1, node.next);
            }
            else
            {
                return false;
            }
        }

        [Test(Description = "https://leetcode.com/problems/intersection-of-two-linked-lists/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Intersection of Two Linked Lists")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, (ListNode, ListNode) Input) item)
        {
            var response = GetIntersectionNode(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, (ListNode, ListNode) Input)> Input
        {
            get
            {
                return new List<(ListNode Output, (ListNode, ListNode) Input)>()
                {
                    (new ListNode(8, new ListNode(4, new ListNode(5))),
                    (new ListNode(4, new ListNode(1, new ListNode(8, new ListNode(4, new ListNode(5))))),
                    new ListNode(5, new ListNode(1, new ListNode(1, new ListNode(8, new ListNode(4, new ListNode(5))))))
                    )),
                };
            }
        }
    }
}
