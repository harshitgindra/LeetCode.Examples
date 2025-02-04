using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedUtils;

namespace LeetCode.Medium
{
    class Sort_List
    {
        /// <summary>
        /// https://leetcode.com/problems/sort-list/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SortList(ListNode head)
        {
            List<int> nums = new List<int>();
            Read(head, nums);

            nums = nums.OrderByDescending(x => x).ToList();

            ListNode currNode = default, prevNode = new ListNode();
            int i = 0;
            while (i < nums.Count)
            {
                prevNode = currNode;
                currNode = new ListNode(nums[i], prevNode);
                i++;
            }

            return currNode;
        }

        private void Read(ListNode node, List<int> result)
        {
            if (node != null)
            {
                result.Add(node.val);
                Read(node.next, result);
            }
        }
    }
}
