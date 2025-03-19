

namespace LeetCode.MediumProblems
{
    public class SmallestNumberDivisbleByN
    {
        public int SmallestRepunitDivByK(int K)
        {
            for (int i = 1, a = 0; i <= K; i++)
                if ((a = (a * 10 + 1) % K) == 0)
                    return i;
            return -1;
        }


        [Test(Description = "https://leetcode.com/problems/max-consecutive-ones-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Max Consecutive Ones II")]
        [TestCaseSource(nameof(Input))]
        [Ignore("")]
        public void Test1((int Output, (int[], int) Input) item)
        {
            // var response = SmallestRepunitDivByK(item.Input.Item2);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, (int[], int) Input)> Input =>
            new List<(int Output, (int[], int) Input)>()
            {
                (10, ([0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1], 3)),
                // (6, ([1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0], 2)),
            };
    }
}