using LeetCode.SharedUtils;


namespace LeetCode.EasyProblems
{
    class Remove_Linked_List_Elements
    {
        /// <summary>
        /// https://leetcode.com/problems/remove-linked-list-elements/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public ListNode RemoveElements(ListNode head, int val)
        {
            return Remove(head, val);
        }

        private ListNode Remove(ListNode node, int val)
        {
            if (node != null)
            {
                if (node.val == val)
                {
                    node = node.next;
                    node = Remove(node, val);
                }
                else
                {
                    node.next = Remove(node.next, val);
                }
            }

            return node;
        }
    }
}
