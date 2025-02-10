using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class FindTheIndexOfFirstOccurenceInTheString
{
    public int StrStr(string haystack, string needle)
    {
        int result = -1;

        if (needle.Length < haystack.Length)
        {
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                if (haystack[i] == needle[0])
                {
                    result = i;
                    for (int j = 1; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            result = -1;
                            break;
                        }
                    }
                    
                    if (result != -1)
                    {
                        break;
                    }
                }
            }
        }
        else if (needle == haystack)
        {
            return 0;
        }

        return result;
    }
    
    [Test(Description = "https://leetcode.com/problems/remove-element/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Remove Element")]
    [TestCaseSource("Input")]
    public void Test1((int Output, (string, string) Input) item)
    {
        var response = StrStr(item.Input.Item1, item.Input.Item2);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(int Output, (string, string) Input)> Input
    {
        get
        {
            return new List<(int Output, (string, string) Input)>()
            {

                (2, ("abc", "c")),
                (0, ("a", "a")),
                (0, ("sadbutsad", "sad")),
                (-1, ("leetcode", "leeto")),
            };
        }
    }
}