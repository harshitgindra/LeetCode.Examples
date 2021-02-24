using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class MyLinkedList
    {
        private List<int> _values;
        public MyLinkedList()
        {
            _values = new List<int>();
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index >= _values.Count)
            {
                return -1;
            }
            return _values[index];
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            _values.Insert(0, val);
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            _values.Add(val);
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index < _values.Count)
            {
                _values.Insert(index, val);
            }
            else if (index == _values.Count)
            {
                _values.Add(val);
            }
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index < _values.Count)
            {
                _values.RemoveAt(index);
            }
        }
    }
}
