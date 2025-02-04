using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    public class MinStack
    {
        /** initialize your data structure here. */
        readonly List<int> _data;
        int _lastIndex = 0;
        public MinStack()
        {
            _data = new List<int>();
            _lastIndex = -1;
        }

        public void Push(int x)
        {
            _data.Add(x);
            _lastIndex++;
        }

        public void Pop()
        {

            _data.RemoveAt(_lastIndex);
            _lastIndex--;
        }

        public int Top()
        {
            return _data[_lastIndex];
        }

        public int GetMin()
        {
            return _data.Min();
        }
    }


}
