using LeetCode;

namespace Leetcode.Problems._2022.January
{
    public class Linked_List_Cycle_II
    {
        public ListNode DetectCycle(ListNode head) {
            if (head == null) return null;
        
            var slow = head;
            var fast = head;
        
            while(fast != null && fast.next != null) {           
                slow = slow.next;
                fast = fast.next.next;
            
                if (slow == fast) break;
            }
        
            if (fast == null || fast.next == null) return null;
            
            slow = head;
            while(slow != fast) {
                slow = slow.next;
                fast = fast.next;
            }

            return fast;   
        }
    }
}