using NUnit.Framework.Legacy;

namespace LeetCode.Mock
{
    class Test4
    {
        public string NextClosestTime(string time)
        {
            var split = time.Split(':');
            var hour = Convert.ToInt32(split[0]);
            var min = Convert.ToInt32(split[1]);

            var uniqueNums = new List<int>();
            foreach (var item in time)
            {
                if (int.TryParse(item.ToString(), out int t))
                {
                    uniqueNums.Add(t);
                }
            }

            uniqueNums = uniqueNums
                .OrderBy(x => x)
                .ToList();

            var lastMin = Convert.ToInt32(time[time.Length - 1]);

            if (uniqueNums.Any(x => x > lastMin))
            {
                lastMin = uniqueNums.First(x => x > lastMin);
            }
            else
            {
                lastMin = uniqueNums.First();
            }
            return null;
        }


        private char GetNextNum(char num)
        {
            if (num == '9')
            {
                return '0';
            }
            switch (num)
            {
                case '0':
                    return '1';
                case '1':
                    return '2';
                case '2':
                    return '3';
                case '3':
                    return '4';
                case '4':
                    return '5';
                case '5':
                    return '6';
                case '6':
                    return '7';
                case '7':
                    return '8';
                case '8':
                    return '9';
            }
            return '0';
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, (int[], int) Input) item)
        {
            var response = KEmptySlots(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int) Input)>()
                {
                     //(6, (new int[]{3,9,2,8,1,6,10,5,4,7}, 1)),
                     //(-1, (new int[]{ 1,2,3}, 1)),
                     (2, (new int[]{ 1,3,2}, 1)),
                };
            }
        }

        public int KEmptySlots(int[] bulbs, int K)
        {
            List<int> status = new List<int>();
            for (int i = 0; i < bulbs.Length; i++)
            {
                var item = bulbs[i];
                status.Add(item);

                if (Check(status, item, K))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        private bool Check(List<int> status, int index, int K)
        {
            if (status.Contains(index + K + 1))
            {
                bool ret = false;
                for (int i = index + 1; i < index + K + 1; i++)
                {
                    if (status.Contains(i))
                    {
                        ret = false;
                        break;
                    }
                    else
                    {
                        ret = true;
                    }
                }

                if (ret)
                {
                    return ret;
                }
            }

            if (status.Contains(index - K - 1))
            {
                bool ret = false;
                for (int i = index - 1; i > index - K; i--)
                {
                    if (status.Contains(i))
                    {
                        return false;
                    }
                    else
                    {
                        ret = true;
                    }
                }
                return ret;
            }
            else
            {
                return false;
            }
        }

        private bool Check2(int[] status, int start, int end)
        {
            if (start < 0)
            {
                start = 0;
            }
            else if (end >= status.Length)
            {
                end = status.Length - 1;
            }

            if (status[start] == 1
                     && status[end] == 1)
            {
                bool ret = false;
                for (int i = start + 1; i < end; i++)
                {
                    if (status[i] == 1)
                    {
                        return false;
                    }
                    else
                    {
                        ret = true;
                    }
                }
                return ret;
            }
            else
            {
                return false;
            }
        }



        public int MaxLengthBetweenEqualCharacters(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length < 1)
            {
                return -1;
            }
            else
            {
                Dictionary<char, List<int>> dict = new Dictionary<char, List<int>>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (dict.ContainsKey(s[i]))
                    {
                        dict[s[i]].Add(i);
                    }
                    else
                    {
                        dict.Add(s[i], new List<int>() { i });
                    }
                }

                int ret = 0;

                foreach (var item in dict.Where(x => x.Value.Count > 1))
                {
                    var ary = item.Value;
                    ret = Math.Max(ret, (ary.Last() - ary.First()));
                }

                return ret - 1;
            }
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource("Input2")]
        public void Test2((int Output, (int, int) Input) item)
        {
            var response = AreConnected(item.Input.Item1, item.Input.Item2);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int) Input)> Input2
        {
            get
            {
                return new List<(int Output, (int, int) Input)>()
                {
                     //(6, (new int[]{3,9,2,8,1,6,10,5,4,7}, 1)),
                     //(-1, (new int[]{ 1,2,3}, 1)),
                     (2, (6,1)),
                     (2, (6,2)),
                };
            }
        }

        public IList<bool> AreConnected(int n, int threshold, int[][] queries = null)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();

            for (int i = threshold + 1; i <= n; i++)
            {
                for (int j = threshold + 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        if (dict.ContainsKey(i))
                        {
                            dict[i].Add(j);
                        }
                        else
                        {
                            dict.Add(i, new List<int>() { j, 1 });
                        }
                    }
                }
            }

            IList<bool> ret = new List<bool>();

            foreach (var item in queries)
            {
                if (threshold == 0)
                {
                    ret.Add(true);
                }
                else
                {
                    var element = Math.Max(item[0], item[1]);

                    if (dict.ContainsKey(element))
                    {
                        var items = dict[element];
                        if (items.Count > 1)
                        {
                            if (items.Contains(item[0])
                                && items.Contains(item[1]))
                            {
                                ret.Add(true);
                            }
                            else
                            {
                                ret.Add(false);
                            }
                        }
                        else
                        {
                            ret.Add(false);
                        }
                    }
                    else
                    {
                        ret.Add(false);
                    }
                }
            }

            return ret;
        }
    }
}
