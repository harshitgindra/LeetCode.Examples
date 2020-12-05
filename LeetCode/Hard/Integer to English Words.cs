using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Hard
{
    public class Integer_to_English_Words
    {
        public string NumberToWords(int num)
        {
            if (num == 0)
            {
                return "Zero";
            }

            IDictionary<string, string> singleToStr = new Dictionary<string, string>(9)
            {
                {"1", "One"},
                {"2", "Two"},
                {"3", "Three"},
                {"4", "Four"},
                {"5", "Five"},
                {"6", "Six"},
                {"7", "Seven"},
                {"8", "Eight"},
                {"9", "Nine"},
                {"0", ""}
            };

            IDictionary<string, string> Ten_TwentyToStr = new Dictionary<string, string>(10)
            {
                {"10", "Ten"},
                {"11", "Eleven"},
                {"12", "Twelve"},
                {"13", "Thirteen"},
                {"14", "Fourteen"},
                {"15", "Fifteen"},
                {"16", "Sixteen"},
                {"17", "Seventeen"},
                {"18", "Eighteen"},
                {"19", "Nineteen"}
            };


            IDictionary<string, string> DecToStr = new Dictionary<string, string>(8)
            {
                {"2", "Twenty"},
                {"3", "Thirty"},
                {"4", "Forty"},
                {"5", "Fifty"},
                {"6", "Sixty"},
                {"7", "Seventy"},
                {"8", "Eighty"},
                {"9", "Ninety"},
                {"0", ""}
            };

            string[] pow2Str = new string[]
            {
                "",
                "Thousand",
                "Million",
                "Billion",
                "Trillion"
            };

            var str = num.ToString();
            int pow = 0;
            List<string> returnValue = new List<string>();

            for (int i = str.Length - 1; i >= 0; i = i - 3)
            {
                var tensPlace = "0";
                if (i > 0)
                {
                    tensPlace = str[i - 1].ToString();
                }

                var unitsPace = str[i].ToString();

                var hundredsPlace = "0";
                if (i > 1)
                {
                    hundredsPlace = str[i - 2].ToString();
                }

                if (tensPlace == "0" && unitsPace == "0" && hundredsPlace == "0")
                {
                    pow++;
                }
                else
                {
                    returnValue.Add(pow2Str[pow++]);
                }


                if (hundredsPlace == "0")
                {
                    if (tensPlace == "1")
                    {
                        returnValue.Add(Ten_TwentyToStr[$"{tensPlace}{unitsPace}"]);
                    }
                    else
                    {
                        returnValue.Add(singleToStr[unitsPace]);
                        returnValue.Add(DecToStr[tensPlace]);
                    }
                }
                else
                {
                    if (tensPlace == "1")
                    {
                        returnValue.Add(Ten_TwentyToStr[$"{tensPlace}{unitsPace}"]);
                    }
                    else
                    {
                        returnValue.Add(singleToStr[unitsPace]);
                        returnValue.Add(DecToStr[tensPlace]);
                    }

                    returnValue.Add("Hundred");
                    returnValue.Add(singleToStr[hundredsPlace]);
                }
            }

            returnValue.Reverse();

            return string.Join(" ", returnValue.Where(x => !string.IsNullOrEmpty(x)));
        }

        [Test(Description = "https://leetcode.com/problems/integer-to-english-words/")]
        [Category("Hard")]
        [Category("Leetcode")]
        [Category("Integer to English Words")]
        [TestCaseSource("Input")]
        public void Test1((string Output, int Input) item)
        {
            var response = NumberToWords(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, int Input)> Input
        {
            get
            {
                return new List<(string Output, int Input)>()
                {
                    ("bab", 12345),
                    ("bab", 123456),
                };
            }
        }
    }
}