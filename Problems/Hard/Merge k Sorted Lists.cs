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
            if (lists != null && lists.Length > 0)
            {
                if (lists.Length == 1)
                {
                    return lists[0];
                }
                else
                {
                    var currNode = lists[0];

                    for (int i = 1; i < lists.Length; i++)
                    {
                        currNode = Merge(currNode, lists[i]);
                    }

                    return currNode;
                }
            }
            else
            {
                return null;
            }
        }

        private ListNode Merge(ListNode node1, ListNode node2)
        {
            ListNode returnValue = new ListNode(0);
            var curr = returnValue;

            while (node1 != null && node2 != null)
            {
                if (node1 != null && node2 != null)
                {
                    if (node1.val < node2.val)
                    {
                        curr.next = node1;
                        node1 = node1.next;
                    }
                    else
                    {
                        curr.next = node2;
                        node2 = node2.next;
                    }
                }

                curr = curr.next;
            }

            if (node1 == null)
            {
                curr.next = node2;
            }

            if (node2 == null)
            {
                curr.next = node1;
            }

            return returnValue.next;
        }

        public ListNode MergeKLists2(ListNode[] lists)
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