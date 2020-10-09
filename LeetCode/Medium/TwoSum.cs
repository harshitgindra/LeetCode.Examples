using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    public class TwoSum
    {
        private readonly IDictionary<int, int> _num2Count = new Dictionary<int, int>();

        public TwoSum()
        {
        }

        public void Add(int number)
        {
            if (!_num2Count.ContainsKey(number))
            {
                _num2Count[number] = 0;
            }

            _num2Count[number]++;
        }

        public bool Find(int value)
        {
            foreach (var n2c in _num2Count)
            {
                var one = n2c.Key;
                var second = value - one;

                if (one == second)
                {
                    if (n2c.Value >= 2)
                    {
                        return true;
                    }
                }
                else
                {
                    if (_num2Count.ContainsKey(second))
                    {
                        return true;
                    }
                }

            }

            return false;
        }
    }
}
