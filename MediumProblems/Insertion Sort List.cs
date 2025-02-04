using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;
using SharedUtils;

namespace LeetCode.Medium
{
    class Insertion_Sort_List
    {
        public ListNode InsertionSortList(ListNode head)
        {
            var nums = Read(head, new List<int>()).ToArray();

            Array.Sort(nums);

            ListNode currNode = null;
            ListNode prevNode = null;

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                currNode = new ListNode(nums[i]);
                currNode.next = prevNode;
                prevNode = currNode;
            }

            return prevNode;
        }

        private List<int> Read(ListNode node, List<int> nums)
        {
            if (node != null)
            {
                nums.Add(node.val);
                nums = Read(node.next, nums);
            }

            return nums;
        }

        [Test(Description = "https://leetcode.com/problems/insertion-sort-list/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Insertion Sort List")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, ListNode Input) item)
        {
            var response = InsertionSortList(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
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
