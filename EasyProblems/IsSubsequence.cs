

namespace LeetCode.EasyProblems;

public class IsSubsequenceSolution
{
    public bool IsSubsequence(string s, string t)
    {
        int i = 0;
        int j = 0;

        while (i < s.Length && j < t.Length)
        {
            if (s[i] == t[j])
            {
                i++;
            }
            j++;
        }

        return i == s.Length;
    }
    
    [Test(Description = "https://leetcode.com/problems/is-subsequence/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Is Subsequence")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, (string, string) Input) item)
    {
        var response = IsSubsequence(item.Input.Item1, item.Input.Item2);
        ClassicAssert.IsTrue(response);
    }

    public static IEnumerable<(bool Output, (string, string) Input)> Input =>
        new List<(bool Output, (string, string) Input)>()
        {

            (true, ("abc", "ahbgdc")),
        };
}