using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class MyCalendar2
    {
        private SortedDictionary<int, int> _dict;
        public MyCalendar2()
        {
            _dict = new SortedDictionary<int, int>();
        }

        public bool Book(int start, int end)
        {
            //   s1------e1
            // s-----e
            //      s---e
            // s------------e
            //      s---------e
            //s--e good
            //               s--e

            if (!_dict.TryGetValue(start, out var temp))
            {
                _dict.Add(start, temp + 1);
            }
            else
            {
                _dict[start]++;
            }

            if (!_dict.TryGetValue(end, out var temp1))
            {
                _dict.Add(end, temp1 - 1);
            }
            else
            {
                _dict[end]--;
            }

            int active = 0;
            foreach (var d in _dict.Values)
            {
                active += d;
                if (active >= 3)
                {
                    _dict[start]--;
                    _dict[end]++;
                    if (_dict[start] == 0)
                    {
                        _dict.Remove(start);
                    }

                    return false;
                }
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/my-calendar-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("My Calendar 2")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (int, int) Input) item)
        {
            //MyCalendar cal = new MyCalendar();
            var response = this.Book(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (int, int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int, int) Input)>()
                {

                    //(true, (10,20)),
                    //(true, (50,60)),
                    //(true, (10,40)),
                    //(false, (5,15)),

                    (true, (1,10)),
                    (true, (15,23)),
                    (true, (10,18)),
                    (false, (17,25)),
                };
            }
        }
    }
}
