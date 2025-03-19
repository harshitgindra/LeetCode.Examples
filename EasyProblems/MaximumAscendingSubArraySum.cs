

namespace EasyProblems;

public class MaximumAscendingSubArraySum
{
    public int MaxAscendingSum(int[] nums) {
        
        if (nums.Length == 0) 
        {
            return 0;
        }
        if (nums.Length == 1)
        {
            return nums[0];
        }
        
        int tempSum = nums[0];
        int result = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                tempSum+= nums[i];
            }
            else
            {
                result = Math.Max(tempSum, result);
                tempSum = nums[i];
            }
        }
        
        result = Math.Max(tempSum, result);
        
        return result;
    }
    
    [Test(Description = "https://leetcode.com/problems/maximum-ascending-subarray-sum/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Maximum Ascending Sub Array")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = MaxAscendingSum(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }
    
    public static IEnumerable<(int Output, int [] Input)> Input =>
        new List<(int Output, int [] Input)>()
        {
            (65, [10,20,30,5,10,50]),
            (150, [10,20,30,40,50]),
            (33, [12,17,15,13,10,11,12]),
        };
}