using LeetCode.SharedUtils;


namespace LeetCode.Problems._2021.December
{
    public class Middle_of_the_Linked_List
    {
        public ListNode MiddleNode(ListNode head)
        {
            return Helper(head, head.next);
        }

        private ListNode Helper(ListNode slowPointingNode, ListNode fastPointingNode)
        {
            if (fastPointingNode == null)
            {
                //***
                //*** Odd number of nodes, return node pointed by slow pointer 
                //***
                return slowPointingNode;
            }
            else if (fastPointingNode.next == null)
            {
                //***
                //*** Even number of nodes, return next node pointed by slow pointer 
                //***
                return slowPointingNode.next;
            }
            else
            {
                //***
                //*** Continue the iteration by 
                //*** incrementing slow pointer by 1
                //*** incrementing fast pointer by 2
                //***
                return Helper(slowPointingNode.next, fastPointingNode.next.next);
            }
        }
    }
}