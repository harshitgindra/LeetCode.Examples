namespace LeetCode.EasyProblems;

public class MaximumHeightOfTriangle
{
    public int MaxHeightOfTriangle(int red, int blue)
    {
        int redStart = _buildRed(red, blue, 1);
        int blueStart = _buildBlue(red, blue, 1);

        return Math.Max(redStart, blueStart);
    }

    private int _buildRed(int remainingRed, int remainingBlue, int level)
    {
        if (remainingRed >= level)
        {
            return _buildBlue(remainingRed - level, remainingBlue, level + 1) + 1;
        }

        return 0;
    }

    private int _buildBlue(int remainingRed, int remainingBlue, int level)
    {
        if (remainingBlue >= level)
        {
            return _buildRed(remainingRed, remainingBlue - level, level + 1) + 1;
        }

        return 0;
    }

    [Test(Description = "https://leetcode.com/problems/maximum-height-of-a-triangle/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Maximum Height of Triangle")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, (int red, int blue) Input) item)
    {
        var response = MaxHeightOfTriangle(item.Input.red, item.Input.blue);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, (int red, int blue) Input)> Input =>
        new List<(int Output, (int red, int blue) Input)>()
        {
            (3, (2, 4)),
            (2, (10, 1)),
        };
}