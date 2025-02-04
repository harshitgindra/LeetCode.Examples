using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode.Hard
{
    public class LFUCache
    {
        private int _capacity = 0;
        private Dictionary<int, int> _keys;
        private Dictionary<int, int> _usages;
        private List<int> _history;
        private int _maxUsage = 0;

        public LFUCache(int capacity)
        {
            _capacity = capacity;
            _keys = new Dictionary<int, int>();
            _usages = new Dictionary<int, int>();
            _history = new List<int>();
        }

        public int Get(int key)
        {
            if (_keys.ContainsKey(key))
            {
                _usages[key]++;
                _maxUsage = Math.Max(_maxUsage, _usages[key]);

                _history.RemoveAll(x => x == key);
                _history.Add(key);
                return _keys[key];
            }
            else
            {
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_capacity > 0)
            {
                if (!_keys.ContainsKey(key))
                {
                    if (_keys.Count == _capacity)
                    {
                        //**
                        //** get highest usage
                        //**
                        var data = _usages.Where(x => x.Value == _usages.Values.Min())
                            .Select(x => x.Key);
                        if (data.Count() > 1)
                        {
                            foreach (var item in _history)
                            {
                                if (data.Contains(item))
                                {
                                    _Remove(item);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            var frst = data.First();
                            _Remove(frst);
                        }
                    }

                    _Insert(key, value);
                }
                else
                {
                    _keys[key] = value;
                    _usages[key]++;
                }
            }
        }

        private void _Remove(int key)
        {
            _keys.Remove(key);
            _usages.Remove(key);
            _history.RemoveAll(x => x == key);
        }

        private void _Insert(int key, int value)
        {
            _keys.Add(key, value);
            _usages.Add(key, 0);
            _history.Add(key);
        }
    }

    public class Test4
    {
        [Test(Description = "https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Minimum Difficulty of a Job Schedule")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            LFUCache lfu = new LFUCache(3);
            lfu.Put(1, 1);
            lfu.Put(2, 2);
            lfu.Put(3, 3);
            lfu.Put(4, 4);
            lfu.Get(4);
            lfu.Get(3);
            lfu.Get(2);
            lfu.Get(1);
            lfu.Put(5, 5);
            lfu.Get(1);
            lfu.Get(2);
            lfu.Get(3);
            lfu.Get(4);
            lfu.Get(5);

        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {

                    (-1, (new int[] {1,1,1}, 4)),
                    (3, (new int[] {1,1,1}, 3)),
                    (7, (new int[] {6,5,4,3,2, 1}, 2)),
                    (6, (new int[] {1,5,3,2,4}, 2)),
                    (10, (new int[] {1,5,3,2,4}, 3)),
                };
            }
        }
    }
}
