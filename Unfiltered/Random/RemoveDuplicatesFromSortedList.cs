using LeetCode.SharedUtils;

namespace LeetCode
{
    public class RemoveDuplicatesFromSortedList
    {
        public RemoveDuplicatesFromSortedList()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Remove Duplicates From Sorted List");
            Console.WriteLine("----------------------------------------------------------");
        }

        private List<int> _uniqueKeys = new List<int>();

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            else
            {
                var resp = GetValue(head, new ListNode());
                return resp;
            }
        }

        public ListNode GetValue(ListNode node, ListNode response)
        {
            if (node != null)
            {
                if (!_uniqueKeys.Contains(node.val))
                {
                    response = new ListNode(node.val);
                    _uniqueKeys.Add(node.val);
                    response.next = GetValue(node.next, response?.next);
                }
                else
                {
                    response = GetValue(node.next, response);
                }

                return response;
            }
            else
            {
                return response;
            }
        }
    }
}