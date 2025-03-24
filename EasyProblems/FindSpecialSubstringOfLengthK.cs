namespace LeetCode.EasyProblems;

public class FindSpecialSubstringOfLengthK
{
    public bool HasSpecialSubstring(string s, int k) {
        int n = s.Length;
        int i = 0;

        for (int j = 0; j < n; j++) {
            if (s[j] == s[i]) continue;
            if (j - i == k) return true;
            i = j;
        }

        return (n - i) == k;
    }
    
    [Test(Description = "https://leetcode.com/problems/find-special-substring-of-length-k/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Find Special Substring of Length K")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, (string, int) Input) item)
    {
        var response = HasSpecialSubstring(item.Input.Item1, item.Input.Item2);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(bool Output, (string, int) Input)> Input =>
        new List<(bool Output, (string, int) Input)>()
        {
            (true, ("aaabaaa", 3)),
        };
}