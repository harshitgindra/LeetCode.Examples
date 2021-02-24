using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class LRUCache
    {
        private int capacity = 0;
        private LinkedList<int[]> list = new LinkedList<int[]>();
        private Dictionary<int, LinkedListNode<int[]>> dict = new Dictionary<int, LinkedListNode<int[]>>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!dict.ContainsKey(key))
                return -1;

            Reorder(dict[key]);

            return dict[key].Value[1];
        }

        public void Put(int key, int value)
        {
            if (dict.ContainsKey(key))
                dict[key].Value[1] = value;
            else
            {
                if (dict.Count == this.capacity)
                {
                    dict.Remove(list.Last.Value[0]);
                    list.RemoveLast();
                }

                dict.Add(key, new LinkedListNode<int[]>(new int[] { key, value }));
            }

            Reorder(dict[key]);
        }

        private void Reorder(LinkedListNode<int[]> node)
        {
            if (node.Previous != null)
                list.Remove(node);

            if (list.First != node)
                list.AddFirst(node);
        }
    }

    public class Test
    {
        [Test(Description = "https://leetcode.com/problems/3sum-closest/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("3Sum Closest")]
        public void Test1()
        {
            LRUCache lRUCache = new LRUCache(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            lRUCache.Get(1);    // return 1
            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            lRUCache.Get(2);    // returns -1 (not found)
            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            lRUCache.Get(1);    // return -1 (not found)
            lRUCache.Get(3);    // return 3
            lRUCache.Get(4);    // return 4
        }
    }
}
