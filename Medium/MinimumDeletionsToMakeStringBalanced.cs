namespace Medium;

public class MinimumDeletionsToMakeStringBalanced
{
    public int MinimumDeletions(string s)
    {
        if (s.Length < 2)
        {
            return 0;
        }
        int aCounter = 0;
        int bCounter = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'a')
            {
                bCounter++;
            }
        }

        int returnValue = bCounter;
        
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'a')
            {
                bCounter--;
            }
            else
            {
                aCounter++;
            }

            returnValue = Math.Min(aCounter + bCounter, returnValue);
        }
        

        return returnValue;
    }
    
    [Test(Description = "https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/?envType=daily-question&envId=2024-07-30")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Minimum deletions to make string balanced")]
    [TestCaseSource("Input")]
    public void Test1((int Output, string Input) item)
    {
        var response = MinimumDeletions(item.Input);
        Assert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(int Output, string Input)> Input
    {
        get
        {
            return new List<(int Output, string Input)>()
            {

                (2, "aababbab"),
                (2, "bbaaaaabb"),
                (0, "bbbbbbbbbbbbbb"),
            };
        }
    }
}