namespace LeetCode.EasyProblems;

public class FindTheChildWhoHasTheBall
{
    public int NumberOfChild(int n, int k)
    {
        // Decrement n by 1 to work with a 0-based index range (0 to n-1)
        // This simplifies the calculation of back-and-forth movements
        n--;

        // Calculate how many complete back-and-forth trips the ball makes
        // Each complete trip consists of passing through all n children twice
        // (once forward, once backward)
        int rounds = k / n;

        // Calculate the remaining passes after the last complete trip
        // This tells us how far into the next trip the ball has traveled
        int rem = k % n;

        if (rounds % 2 == 0)
        {
            // If the number of complete trips is even, the ball is currently
            // moving in the forward direction (from child 0 toward child n-1)
            // So we return the remainder directly, which represents how many
            // steps forward from the beginning
            return rem;
        }
        else
        {
            // If the number of complete trips is odd, the ball is currently
            // moving in the backward direction (from child n-1 toward child 0)
            // So we return (n - rem), which represents how many steps backward
            // from the end of the line
            return n - rem;
        }
    }

    [Test(Description = "https://leetcode.com/problems/find-the-child-who-has-the-ball-after-k-seconds/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Find The Child Who Has The Ball After K Seconds")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, (int, int) Input) item)
    {
        var response = NumberOfChild(item.Input.Item1, item.Input.Item2);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, (int, int) Input)> Input =>
        new List<(int Output, (int, int) Input)>()
        {
            (1, (3, 5)),
        };
}