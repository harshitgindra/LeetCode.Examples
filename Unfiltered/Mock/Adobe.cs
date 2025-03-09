namespace LeetCode.Mock
{
    class Adobe
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }
            else
            {
                var nums = GetIntArray(x);
                int sIndex = 0;
                int eIndex = nums.Count - 1;

                while (sIndex < eIndex)
                {
                    if (nums[sIndex++] != nums[eIndex--])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        List<int> GetIntArray(int num)
        {
            List<int> listOfInts = new List<int>();
            while (num > 0)
            {
                listOfInts.Add(num % 10);
                num = num / 10;
            }
            return listOfInts;
        }

        public string AddStrings(string num1, string num2)
        {
            int maxLength = Math.Max(num1.Length, num2.Length);

            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');

            string ret = "";

            int cof = 0;
            for (int i = maxLength - 1; i >= 0; i--)
            {
                var sum = dict[num1[i]] + dict[num2[i]] + cof;

                if (sum > 9)
                {
                    sum = 10 - sum;
                    ret = $"{sum}{ret}";
                    cof = 1;
                }
                else
                {
                    ret = sum + ret;
                    cof = 0;
                }
            }

            if (cof == 1)
            {
                ret = "1" + ret;
            }
            return ret;
        }

        private IDictionary<char, int> dict = new Dictionary<char, int>()
        {
            {'0',0 },
            {'1',1 },
            {'2',2 },
            {'3',3 },
            {'4',4 },
            {'5',5 },
            {'6',6 },
            {'7',7 },
            {'8',8 },
            {'9',9 },
        };

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = MaxDistToClosest(item.Input);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                     (3, new int[]{ 1,0,0,0}),
                     (2, new int[]{ 1,0,0,0,1,0,1}),
                };
            }
        }

        int[] nums = new int[] { 0, 1, 3, 8 };


        public int MaxDistToClosest(int[] seats)
        {
            int ret = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 0)
                {
                    var tempI = i;
                    int lDist = 0;
                    while (tempI >= 0)
                    {
                        if (seats[tempI--] == 0)
                        {
                            lDist++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    tempI = i;
                    int RDist = 0;
                    while (tempI < seats.Length)
                    {
                        if (seats[tempI++] == 0)
                        {
                            RDist++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (i == 0)
                    {
                        ret = Math.Max(ret, RDist);
                    }
                    else if (i == seats.Length - 1)
                    {
                        ret = Math.Max(ret, lDist);
                    }
                    else
                    {
                        ret = Math.Max(ret, Math.Min(lDist, RDist));
                    }
                }
            }

            return ret;
        }


    }
}
