namespace LeetCode.EasyProblems;

public class ThreeConsecutiveOddsSolution
{
    public bool ThreeConsecutiveOdds(int[] arr)
    {
        int length = 0;
        foreach (var item in arr)
        {
            if (item % 2 == 1)
            {
                length++;
            }
            else
            {
                if (length > 2)
                {
                    return true;
                }

                length = 0;
            }
        }

        return length > 2;
    }

    [Test(Description = "https://leetcode.com/problems/three-consecutive-odds/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Three Consecutive Odds")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, int[] Input) item)
    {
        var response = ThreeConsecutiveOdds(item.Input);
        Assert.That(item.Output, Is.EqualTo(response));
    }

    public static IEnumerable<(bool Output, int[] Input)> Input =>
        new List<(bool Output, int[] Input)>()
        {
            (true, [1,2,34,3,4,5,7,23,12]),
        };
}