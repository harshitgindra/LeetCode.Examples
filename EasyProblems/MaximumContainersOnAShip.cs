namespace LeetCode.EasyProblems;

public class MaximumContainersOnAShip
{
    public int MaxContainers(int n, int w, int maxWeight)
    {
        if (n * n * w > maxWeight)
        {
            return maxWeight / w;
        }
        else
        {
            return n * n;
        }
    }

    [Test(Description = "https://leetcode.com/problems/maximum-containers-on-a-ship/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Maximum Containers On A Ship")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, (int n, int w, int maxWeight) Input) item)
    {
        var response = MaxContainers(item.Input.n, item.Input.w, item.Input.maxWeight);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, (int n, int w, int maxWeight) Input)> Input =>
        new List<(int, (int n, int w, int maxWeight))>()
        {
            (4, (2, 3, 15)),
            (4, (3, 5, 20)),
        };
}