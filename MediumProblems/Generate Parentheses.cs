using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class Generate_Parentheses
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            Generate(result, new StringBuilder(), n, n);
            return result;
        }

        public void Generate(IList<string> list, StringBuilder sb, int leftRemaining, int rightRemaining)
        {
            if (leftRemaining == 0 && rightRemaining == 0)
            {
                list.Add(sb.ToString());
            }
            else
            {
                if (leftRemaining > 0)
                {
                    sb.Append("(");
                    Generate(list, sb, leftRemaining - 1, rightRemaining);
                    sb.Remove(sb.Length - 1, 1);
                }
                if (rightRemaining > leftRemaining)
                {
                    sb.Append(")");
                    Generate(list, sb, leftRemaining, rightRemaining - 1);
                    sb.Remove(sb.Length - 1, 1);
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/generate-parentheses/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Generate Parentheses")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int Input) item)
        {
            var response = GenerateParenthesis(item.Input);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {

                    (5, 3),
                };
            }
        }
    }
}
