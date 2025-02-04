using System.Collections.Generic;
using System.Linq;
using SharedUtils;

namespace LeetCode.Medium
{
    public class Next_Greater_Node_In_Linked_List
    {
        public int[] NextLargerNodes(ListNode head)
        {
            List<int> nums = new List<int>();

            var node = head;
            while (node != null)
            {
                nums.Add(node.val);
                node = node.next;
            }

            var arry = nums.OrderBy(x => x)
                .ToArray();

            int maxIndex = nums.Max();
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == arry[maxIndex])
                {
                    nums[i] = 0;
                    maxIndex--;
                }
                else
                {
                    
                    nums[i] = arry[maxIndex];
                }
            }

            return nums.ToArray();
        }
    }
}