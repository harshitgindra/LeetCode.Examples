using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Leetcode.Problems.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/remove-k-digits/
    /// </summary>
    public class Remove_K_Digits
    {
        public string RemoveKdigits(string num, int k)
        {
            int i = 0;
            Stack<int> stack = new Stack<int>();

            while (i < num.Length)
            {
                var temp = Convert.ToInt16(num[i].ToString());
                if (stack.Count > 0 && k > 0)
                {
                    if (stack.Peek() > temp)
                    {
                        stack.Pop();
                        k--;
                    }
                    else
                    {
                        stack.Push(temp);
                        i++;
                    }
                }
                else
                {
                    if (stack.Count == 0 && temp == 0)
                    {
                    }
                    else
                    {
                        stack.Push(temp);
                    }

                    i++;
                }
            }

            while (k > 0)
            {
                stack.TryPop(out int _);
                k--;
            }

            string result = "";
            while (stack.Count > 0)
            {
                result = $"{stack.Pop()}{result}";
            }

            if (string.IsNullOrEmpty(result))
            {
                result = "0";
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/remove-k-digits/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Remove K Digits")]
        [TestCaseSource("Input")]
        public void Test1((string Output, (string, int) Input) item)
        {
            var response = RemoveKdigits(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, (string, int) Input)> Input
        {
            get
            {
                return new List<(string Output, (string, int) Input)>()
                {
                    ("200", ("10200", 1)),
                    ("1219", ("1432219", 3)),
                };
            }
        }
    }
}