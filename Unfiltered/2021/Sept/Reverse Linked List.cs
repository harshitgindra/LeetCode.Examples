using LeetCode.SharedUtils;

namespace LeetCode.Problems._2021.Sept
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-linked-list/
    /// </summary>
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
    }
}
