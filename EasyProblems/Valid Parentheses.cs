using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class Valid_Parentheses
{
    private Dictionary<char, char> dictionary;
    public bool IsValid(string s) {
        dictionary = new Dictionary<char, char>();
        dictionary.Add('(', ')');
        dictionary.Add('[', ']');
        dictionary.Add('{', '}');

        Stack<char> stack = new Stack<char>();
        var response = Helper(0, s, stack);
        return response && stack.Count == 0;
    }

    private bool Helper(int i, string s, Stack<char> stack)
    {
        if (i < s.Length)
        {
            // If stack count is empty, it means we have found pairs for all parantheses so far
            if (stack.Count == 0 || dictionary[stack.Peek()] != s[i])
            {
                // Check if the char is opening parantheses
                // if it's a closing parantheses, it should have found a match already
                if (dictionary.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                    return Helper(i + 1, s, stack);
                }
                return false;
            }
            else
            {
                stack.Pop();
                return Helper(i + 1, s, stack);
            }
        }
        return true;
    }
    
    [Test(Description = "https://leetcode.com/problems/valid-parentheses/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Valid Parentheses")]
    [TestCaseSource("Input")]
    public void Test1((bool Output, string Input) item)
    {
        var response = IsValid(item.Input);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(bool Output, string Input)> Input
    {
        get
        {
            return new List<(bool Output, string Input)>()
            {
                (true, "([])"),
                (false, "(]"),
                (false, "["),
            };
        }
    }
}