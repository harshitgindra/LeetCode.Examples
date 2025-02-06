using NUnit.Framework.Legacy;

namespace LeetCode.HardProblems
{
    public class Longest_Valid_Parentheses
    {
        public int LongestValidParentheses(string s)
        {
            int returnValue = 0;
            if (!string.IsNullOrEmpty(s))
            {
                //***
                //*** Initialize the stack and push -1
                //***
                Stack<int> stacks = new Stack<int>();
                stacks.Push(-1);

                for (int i = 0; i < s.Length; i++)
                {
                    char ch = s[i];
                    //***
                    //*** If '(', push index to the stack
                    //***
                    if (ch == '(')
                    {
                        stacks.Push(i);
                    }
                    //***
                    //*** If ')', pop the last entry from the stack
                    //***
                    else if (ch == ')')
                    {
                        stacks.Pop();
                        //***
                        //*** If stack is empty, push the current index to the stack
                        //***
                        if (!stacks.Any())
                        {
                            stacks.Push(i);
                        }
                        else
                        {
                            //***
                            //*** Stack is not empty, calculate max
                            //*** Max = difference of current index and the last index inserted into the stack
                            //***
                            returnValue = Math.Max(returnValue, i - stacks.Peek());
                        }
                    }
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/longest-valid-parentheses/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Longest Valid Parentheses")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string Input) item)
        {
            var response = LongestValidParentheses(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {
                    (4, ")()())"),
                };
            }
        }
    }
}
