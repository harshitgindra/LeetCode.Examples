

namespace LeetCode.Problems._2021.August
{
    class Decode_Ways
    {
        private IDictionary<int, int> _cache;

        public int NumDecodings(string s)
        {
            _cache = new Dictionary<int, int>();
            var result = Iterate(s, 0);
            return result;
        }

        private int Iterate(string s, int i)
        {
            //***
            //*** We are at the end of the string
            //*** Return 1 as the parsing/iteration is successful
            //***
            if (i == s.Length)
            {
                return 1;
            }
            else if (i < s.Length)
            {
                //***
                //*** Check the cache if we have already completed the calculation
                //***
                if (!_cache.ContainsKey(i))
                {
                    int tempResult = 0;
                    int num1 = Convert.ToInt32(s.Substring(i, 1));
                    //***
                    //*** If First num is 0, we can't split one character
                    //***
                    if (num1 != 0)
                    {
                        //***
                        //*** Continue the iteration by splitting 1 character
                        //***
                        tempResult = Iterate(s, i + 1);
                        //***
                        //*** If we can split the string for two characters, continue the iteration and look for a valid two digit num
                        //***
                        if (i + 2 <= s.Length)
                        {
                            int num2 = Convert.ToInt32(s.Substring(i, 2));
                            //***
                            //*** Verify if the number is greater than 9 and less than 27
                            //***
                            if (num2 > 9 && num2 < 27)
                            {
                                tempResult += Iterate(s, i + 2);
                            }
                        }
                    }

                    _cache.Add(i, tempResult);
                }

                return _cache[i];
            }
            else
            {
                return 0;
            }
        }

        [Test(Description = "https://leetcode.com/problems/decode-ways/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Decode Ways")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, string Input) item)
        {
            var response = NumDecodings(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {
                    (2, "11106"),
                    (2, "12"),
                    (3, "226"),
                    (0,"0")
                };
            }
        }
    }
}
