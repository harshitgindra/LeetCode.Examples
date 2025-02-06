namespace LeetCode
{
    public class MergeTwoSortedListsTest
    {
        public MergeTwoSortedListsTest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Merge Two Sorted Lists Test");
            Console.WriteLine("----------------------------------------------------------");
        }

        List<int> finalInts = new List<int>();

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode response = default;
            Merge(l1, l2);
            finalInts.Sort();
            response = Add(response, finalInts, 0);

            return response;
        }

        public ListNode Add(ListNode response, List<int> nums, int currentIndex)
        {
            if (currentIndex < nums.Count)
            {
                response = new ListNode(nums[currentIndex]);
                response.next = Add(response.next, nums, (currentIndex + 1));
            }

            return response;
        }

        public void Merge(ListNode l1, ListNode l2)
        {
            if (l1 != null)
            {
                finalInts.Add(l1.val);
                if (l2 != null)
                {
                    finalInts.Add(l2.val);
                }
            }
            else if (l2 != null)
            {
                finalInts.Add(l2.val);
            }

            if (l1?.next != null || l2?.next != null)
            {
                Merge(l1?.next, l2?.next);
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            return $"{this.val}";
        }
    }
}
