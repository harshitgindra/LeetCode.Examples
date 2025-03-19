using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems;

/// <summary>
/// https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks/
/// 2244
/// </summary>
public class Minimum_Rounds_to_Complete_All_Tasks_V1
{
    public int MinimumRounds(int[] tasks)
    {
        IDictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (var item in tasks)
        {
            if (dictionary.ContainsKey(item))
            {
                dictionary[item]++;
            }
            else
            {
                dictionary.Add(item, 1);
            }
        }

        int returnValue = 0;

        foreach (var item in dictionary)
        {
            if (item.Value == 1)
            {
                // It cannot be divided in rounds of 2 or 3. 
                // Hence return -1
                return -1;
            }

            if (item.Value % 3 == 0)
            {
                // Divisible by 3 means the tasks can be completed in rounds of 3
                returnValue += item.Value / 3;
            }
            else
            {
                // there are two possibilities
                // 1. When divided by 3, remainder is 1. In that case, we will do 2 rounds of 2
                // For eg. if count is 4, we will be 2 rounds of 2
                // 2. When divided by 3, remainder is 2. In that case, we will do 1 round of 3 and 1 round of 2
                // For eg. if count is 5, we will do 1 round of 2 and 1 round of 3
                returnValue += item.Value / 3 + 1;
            }
        }

        return returnValue;
    }

    [Test(Description = "https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Minimum Rounds to Complete All Tasks")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = MinimumRounds(item.Input);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(int Output, int[] )> Input
    {
        get
        {
            return new List<(int Output, int[] Input)>()
            {
                (4, new int[] {2, 2, 3, 3, 2, 4, 4, 4, 4, 4}),
                (20,
                    new int[]
                    {
                        66, 66, 63, 61, 63, 63, 64, 66, 66, 65, 66, 65, 61, 67, 68, 66, 62, 67, 61, 64, 66, 60, 69, 66,
                        65, 68, 63, 60, 67, 62, 68, 60, 66, 64, 60, 60, 60, 62, 66, 64, 63, 65, 60, 69, 63, 68, 68, 69,
                        68, 61
                    }),
            };
        }
    }
}