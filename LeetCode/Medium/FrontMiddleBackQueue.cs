using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class FrontMiddleBackQueue
    {
        private List<int> _values;

        public FrontMiddleBackQueue()
        {
            _values = new List<int>();
        }

        public void PushFront(int val)
        {
            _values.Insert(0, val);
        }

        public void PushMiddle(int val)
        {
            int length = _values.Count;
            if (length == 0)
            {
                _values.Add(val);
            }
            else if (length == 1)
            {
                _values.Insert(0, val);
            }
            else if (length % 2 == 0)
            {
                _values.Insert((length / 2), val);
            }
            else
            {
                var d = Convert.ToInt32(Math.Floor(length / 2.0));
                _values.Insert(d, val);
            }
        }

        public void PushBack(int val)
        {
            _values.Add(val);
        }

        public int PopFront()
        {
            if (_values.Count == 0)
            {
                return -1;
            }
            else
            {
                int val = _values[0];
                _values.RemoveAt(0);
                return val;
            }
        }

        public int PopMiddle()
        {
            int length = _values.Count;
            if (length == 0)
            {
                return -1;
            }
            else if (length == 2)
            {
                var val = _values[0];
                _values.RemoveAt(0);
                return val;
            }
            else if (length % 2 == 0)
            {
                var index = (length / 2) - 1;
                var val = _values[index];
                _values.RemoveAt(index);
                return val;
            }
            else
            {
                var d = Convert.ToInt32(Math.Floor(length / 2.0));
                var val = _values[d];
                _values.RemoveAt(d);
                return val;
            }
        }

        public int PopBack()
        {
            if (_values.Count == 0)
            {
                return -1;
            }
            else
            {
                var val = _values[_values.Count - 1];
                _values.RemoveAt(_values.Count - 1);
                return val;
            }
        }

        [Test(Description = "https://leetcode.com/problems/super-palindromes/")]
        [Category("Hard")]
        [Category("Leetcode")]
        [Category("Super Palindromes")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (string, string) Input) item)
        {
            // FrontMiddleBackQueue q = new FrontMiddleBackQueue();
            // q.PushFront(1); // [1]
            // q.PushBack(2); // [1, 2]
            // q.PushMiddle(3); // [1, 3, 2]
            // q.PushMiddle(4); // [1, 4, 3, 2]
            // var t = q.PopFront(); // return 1 -> [4, 3, 2]
            // t = q.PopMiddle(); // return 3 -> [4, 2]
            // t = q.PopMiddle(); // return 4 -> [2]
            // t = q.PopBack(); // return 2 -> []
            // t = q.PopFront(); // return -1 -> [] (The queue is empty)

            FrontMiddleBackQueue q = new FrontMiddleBackQueue();
            q.PopMiddle(); // [1]
            q.PushMiddle(1); // [1, 2]
            q.PushMiddle(2); // [1, 2]
            q.PushMiddle(3); // [1, 2]
            var t = q.PopMiddle(); // return 3 -> [4, 2]
            t = q.PopMiddle(); // return 3 -> [4, 2]
            t = q.PopMiddle(); // return 3 -> [4, 2]
        }

        public static IEnumerable<(int Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(int Output, (string, string) Input)>()
                {
                    (4, ("4", "1000")),
                };
            }
        }
    }
}