namespace LeetCode.EasyProblems;

public class HappyNumber
{
    public bool IsHappy(int n)
    {
        HashSet<int> visitedNumbers = new HashSet<int>();

        while (n != 1)
        {
            // Detect cycle - if we've seen this number before
            if (!visitedNumbers.Add(n))
                return false;

            n = SumOfSquares(n);
        }

        return true;
    }

    private static int SumOfSquares(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10; // Remove last digit
        }

        return sum;
    }

    [Test(Description = "https://leetcode.com/problems/happy-number/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Happy Number")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, int Input) item)
    {
        var response = IsHappy(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(bool Output, int Input)> Input =>
        new List<(bool Output, int Input)>()
        {
            (true, 19),
            (false, 2),
        };
}