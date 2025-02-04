using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/insert-delete-getrandom-o1/
    /// </summary>
    public class RandomizedSet2
    {
        private HashSet<int> _set;
        private List<int> _nums;
        private Random _random;
        /** Initialize your data structure here. */
        public RandomizedSet2()
        {
            _set = new HashSet<int>();
            _nums = new List<int>();
            _random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (_set.Add(val))
            {
                _nums.Add(val);
                return true;
            }
            else
            {
                return false;
            }
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (_set.Remove(val))
            {
                _nums.Remove(val);
                return true;
            }
            else
            {
                return false;
            }
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return _nums[_random.Next(_nums.Count)];
        }
    }
    
    public class RandomizedSet
    {
        private IDictionary<int, int> _set;
        private List<int> _nums;
        private Random _random;
        
        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            _set = new Dictionary<int, int>();
            _nums = new List<int>();
            _random = new Random();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (_set.ContainsKey(val))
            {
                return false;
            }
            else
            {
                _set.Add(val, _nums.Count);
                _nums.Add(val);

                return true;
            }
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (_set.ContainsKey(val))
            {
                // Get the index of the val from Dictionary
                // Replace the val with the last number in the list
                // Update the Dictionary with the new index value for the number being switched
                // Remove the number at the last position in the list
                // Remove the val from dictionary 
                var index = _set[val];
                _nums[index] = _nums[_nums.Count - 1];
                _set[_nums[_nums.Count - 1]] = index;
                _nums.RemoveAt(_nums.Count -1);
                _set.Remove(val);
                return true;
            }
            else
            {
                return false;
            }
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            return _nums[_random.Next(_nums.Count)];
        }
    }
}
