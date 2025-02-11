using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class SearchInsertPosition
{
    public int SearchInsert(int[] nums, int target)
    {
        int first = 0;
        int last = nums.Length - 1;

        while(first <= last){
            int mid = (first + last) / 2;

            if(target == nums[mid]){
                return mid;
            }
            if(target < nums[mid]){
                last = mid - 1;
            }
            else{
                first = mid + 1;
            }
        }
        return first;
    }
    
    [Test(Description = "https://leetcode.com/problems/search-insert-position/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Search Insert Position")]
    [TestCaseSource("Input")]
    public void Test1((int Output, (int[], int) Input) item)
    {
        var response = SearchInsert(item.Input.Item1, item.Input.Item2);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(int Output, (int[], int) Input)> Input
    {
        get
        {
            return new List<(int Output, (int[], int) Input)>()
            {

                (4, (new int[] {1,3,5,6}, 7)),
            };
        }
    }
}