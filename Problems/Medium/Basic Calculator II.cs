using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class Basic_Calculator_II
    {
        public int Calculate(string s)
        {
            List<string> stack = new List<string>();
            s = s.Replace(" ", string.Empty);
            string str = "";

            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '+':
                        stack.Add(str);
                        stack.Add("+");
                        str = "";

                        break;
                    case '-':

                        stack.Add($"{str}");
                        stack.Add("-");
                        str = "";

                        break;
                    case '*':

                        stack.Add(str);
                        stack.Add("*");
                        str = "";

                        break;
                    case '/':

                        stack.Add(str);
                        stack.Add("/");
                        str = "";

                        break;
                    default:
                        str += s[i];
                        break;
                }
            }

            stack.Add(str);
            
            int j = 1;

            while (j < stack.Count)
            {
                if (stack[j] == "*")
                {
                    stack[j - 1] = $"{Convert.ToInt32(stack[j - 1]) * Convert.ToInt32(stack[j + 1])}";
                    stack.RemoveAt(j);
                    stack.RemoveAt(j);
                }

                else if (stack[j] == "/")
                {
                    stack[j - 1] = $"{Convert.ToInt32(stack[j - 1]) / Convert.ToInt32(stack[j + 1])}";
                    stack.RemoveAt(j);
                    stack.RemoveAt(j);
                }
                else
                {
                    j++;
                }
            }

            j = 0;

            var ret = Convert.ToInt32(stack[0]);
            while (j < stack.Count)
            {
                if (stack[j] == "+")
                {
                    ret += Convert.ToInt32(stack[j + 1]);
                }
                else if (stack[j] == "-")
                {
                    ret -= Convert.ToInt32(stack[j + 1]);
                }

                j++;
            }

            return ret;
        }


        [Test(Description = "https://leetcode.com/problems/basic-calculator-ii/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Basic Calculator II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (string[], string) Input) item)
        {
            var response = Calculate(item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (string[], string) Input)> Input
        {
            get
            {
                return new List<(int Output, (string[], string) Input)>()
                {
                    (7, (new string[] {"CompetitiveProgramming", "CounterPick", "ControlPanel"}, "3-2*2")),
                };
            }
        }
    }
}