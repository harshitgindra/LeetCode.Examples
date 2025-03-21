namespace LeetCode.EasyProblems;

public class ClearDigitsSolution
{
    public string ClearDigits(string s)
    {
        Stack<(char, bool)> stack = new();
        stack.Push((s[0], char.IsDigit(s[0])));

        for (int i = 1; i < s.Length; i++)
        {
            var isCurrentCharDigit = char.IsDigit(s[i]);
            if (stack.Count == 0)
            {
                stack.Push((s[i], isCurrentCharDigit));
            }
            else
            {
                var lastEntry = stack.Peek();
                if (!lastEntry.Item2 && isCurrentCharDigit)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push((s[i], isCurrentCharDigit));
                }
            }
        }

        string returnValue = "";
        foreach (var item in stack)
        {
            returnValue = item.Item1 + returnValue;
        }

        return returnValue;
    }

    [Test(Description = "https://leetcode.com/problems/clear-digits/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Clear Digits")]
    [TestCaseSource(nameof(Input))]
    public void Test1((string Output, string Input) item)
    {
        var response = ClearDigits(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(string Output, string Input)> Input =>
        new List<(string Output, string Input)>()
        {
            ("", "cb34"),
            ("abc", "abc"),
        };
}