using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Hard
{
    //https://leetcode.com/problems/merge-k-sorted-lists/submissions/
    class Merge_k_Sorted_Lists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists != null || lists.Count() > 0)
            {
                List<int> vals = new List<int>();
                foreach (var item in lists)
                {
                    vals = Read(item, vals);
                }

                var orderedList = vals.OrderBy(x => x).ToArray();

                ListNode currNode = default, prevNode = default;
                for (int i = orderedList.Length - 1; i >= 0; i--)
                {
                    prevNode = currNode;
                    currNode = new ListNode(orderedList[i], prevNode);
                }

                return currNode;
            }
            else
            {
                return default;
            }
        }

        private List<int> Read(ListNode node, List<int> val)
        {
            if (node != null)
            {
                val.Add(node.val);
                val = Read(node.next, val);
            }
            return val;
        }
    }
}
