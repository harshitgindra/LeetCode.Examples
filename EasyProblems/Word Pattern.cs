namespace Easy;

/// <summary>
/// https://leetcode.com/problems/word-pattern/
/// 290
/// </summary>
public class Word_Pattern
{
    public bool WordPattern(string pattern, string s)
    {
        var sArray = s.Split(" ");
        if (pattern.Length != sArray.Length)
        {
            return false;
        }

        var dict1 = new Dictionary<char, string>();
        var dict2 = new Dictionary<string, char>();

        for (int i = 0; i < pattern.Length; i++)
        {
            if (!dict1.ContainsKey(pattern[i]) && !dict2.ContainsKey(sArray[i]))
            {
                dict1[pattern[i]] = sArray[i];
                dict2[sArray[i]] = pattern[i];
            }
            else
            {
                if (dict1.ContainsKey(pattern[i]))
                {
                    if (dict1[pattern[i]] != sArray[i])
                    {
                        return false;
                    }
                }

                if (dict2.ContainsKey(sArray[i]))
                {
                    if (dict2[sArray[i]] != pattern[i])
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    [Test(Description = "https://leetcode.com/problems/word-pattern/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Word Pattern")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, (string, string) Input) item)
    {
        var response = WordPattern(item.Input.Item1, item.Input.Item2);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(bool Output, (string, string) Input)> Input =>
        new List<(bool Output, (string, string) Input)>()
        {
            (true, ("abba", "dog cat cat dog")),
            (false, ("aaaa", "dog cat cat dog")),
            (false, ("abba", "dog cat cat fish")),
        };
}