using Leetcode.Problems.Common;
using LeetCode;
using NUnit.Framework;
using System.Collections.Generic;

namespace Leetcode.Problems._2021.March
{
    class Swapping_Nodes_in_a_Linked_List
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            ListNode firstNode = null, lastNode = null, currentNode = head;
            int counter = 1;
            //***
            //*** Loop through all nodes in the linked list
            //***
            while (currentNode != null)
            {
                //***
                //*** This check is used to get the Kth node from the end
                //*** We start by trailing through the head node only after we find the Kth element from the start
                //***
                if (lastNode != null)
                {
                    lastNode = lastNode.next;
                }
                //***
                //*** Find the first Kth element from the beginning 
                //***
                if (counter == k)
                {
                    firstNode = currentNode;
                    lastNode = head;
                }

                currentNode = currentNode.next;
                counter++;
            }
            //***
            //*** Exchange the value of the first and the last node
            //***
            counter = firstNode.val;
            firstNode.val = lastNode.val;
            lastNode.val = counter;
            return head;
        }

        [Test(Description = "https://leetcode.com/problems/swapping-nodes-in-a-linked-list/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Swapping Nodes in a Linked List")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, (ListNode, int) Input) item)
        {
            var response = SwapNodes(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output.val, response.val);
        }

        public static IEnumerable<(ListNode Output, (ListNode, int) Input)> Input
        {
            get
            {
                return new List<(ListNode Output, (ListNode, int) Input)>()
                {
                    (new int[]{1,4,3,2,5}.ToListNode(), (new int[]{1,2,3,4,5}.ToListNode(), 2)),
                };
            }
        }
    }
}
