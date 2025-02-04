using System;
using System.Collections.Generic;
using System.Text;
using SharedUtils;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// </summary>
    class Merge_Two_Sorted_Lists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var node = Merge(null, l1, l2);
            return node;
        }


        private ListNode Merge(ListNode result, ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {

            }
            else if (l1 == null || l1.val > l2?.val)
            {
                result = new ListNode(l2.val);
                result.next = Merge(result.next, l1, l2.next);
            }
            else if (l2 == null || l1?.val <= l2.val)
            {
                result = new ListNode(l1.val);
                result.next = Merge(result.next, l1.next, l2);
            }

            return result;
        }
    }
}
