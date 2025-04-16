namespace LeetCode.EasyProblems;

public class ReverseDegreeOfAString
{
    public int ReverseDegree(string s) {
        int returnValue = 0;
        int i=1;
        foreach(char ch in s){
            returnValue += Math.Abs( (ch-'a')-26) * i;
            i++;
        }
        return returnValue;
    }
    
    [Test(Description = "https://leetcode.com/problems/reverse-degree-of-a-string/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Reverse Degree Of A String")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, string Input) item)
    {
        var response = ReverseDegree(item.Input);
        Assert.That(item.Output, Is.EqualTo(response));
    }

    public static IEnumerable<(int Output, string Input)> Input =>
        new List<(int Output, string Input)>()
        {
            (160, "zaza"),
        };
}