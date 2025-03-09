using LeetCode.SharedUtils;

namespace LeetCode
{
    public class AddTwoNumbers
    {
        public AddTwoNumbers()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Add two numbers");
            Console.WriteLine("----------------------------------------------------------");
        }

        public ListNode Start(ListNode l1, ListNode l2)
        {
            return Add(l1, l2);
        }

        public ListNode Add(ListNode l1, ListNode l2, ListNode response = default, bool cof = false)
        {
            //***
            //*** Check if nodes are not null
            //***
            if (l1 == null && l2 == null && cof)
            {
                //***
                //*** Add last node with value 1 as COF is true and there are no next nodes 
                //***
                response = new ListNode(1);
            }
            else if (l1 == null && l2 == null)
            {
                //***
                //*** All nodes complete
                //***
            }
            else
            {
                int val1 = l1?.val ?? 0;
                int val2 = l2?.val ?? 0;
                response = new ListNode(val1 + val2);
                //***
                //*** COF is set to true, increement value by 1
                //*** 
                if (cof)
                {
                    response.val++;
                }
                //***
                //*** Check if the total of the nodes is greater than 9 for carry over
                //***
                if (response.val > 9)
                {
                    response.val %= 10;
                    cof = true;
                }
                else
                {
                    cof = false;
                }
                //***
                //*** Repeat the loop for next nodes
                //***
                response.next = Add(l1?.next, l2?.next, response.next, cof);
            }

            return response;
        }

        //private class ListNode
        //{
        //    public int val;
        //    public ListNode next;
        //    public ListNode(int val = 0, ListNode next = null)
        //    {
        //        this.val = val;
        //        this.next = next;
        //    }
        //}
    }
}
