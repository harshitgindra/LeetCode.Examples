using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class Length_Of_Last_Word
{
    public int LengthOfLastWord(string s)
    {
        int returnValue = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == ' ' && returnValue != 0)
            {
                return returnValue;
            }
            else if (s[i] == ' ' && returnValue == 0)
            {
                // do nothing - we are still counting empty spaces at the end
            }
            else
            {
                returnValue++;
            }
        }

        return returnValue;
    }

    [Test(Description = "https://leetcode.com/problems/length-of-last-word/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Length Of Last Word")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, string Input) item)
    {
        var response = LengthOfLastWord(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, string Input)> Input =>
        new List<(int Output, string Input)>()
        {
            (6, "luffy is still joyboy"),
            (4, "l   fly me   to   the moon  "),
        };
}