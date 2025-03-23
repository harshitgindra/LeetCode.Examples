namespace LeetCode.EasyProblems;

public class TransformArrayByParity
{
    public int[] TransformArray(int[] nums) {
        int j = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] % 2 == 0) {
                nums[j++] = 0;
            }
        }
        while (j < nums.Length) {
            nums[j++] = 1;
        }
        return nums;
    }
    
    [Test(Description = "https://leetcode.com/problems/transform-array-by-parity/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Transform Array By Parity")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int[] Output, int[] Input) item)
    {
        var response = TransformArray(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int[] Output, int[] Input)> Input =>
        new List<(int[] Output, int[] Input)>()
        {
            ([0,0,1,1], [4,3,2,1]),
        };
}