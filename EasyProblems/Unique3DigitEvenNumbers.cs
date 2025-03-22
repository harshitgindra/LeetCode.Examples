namespace LeetCode.EasyProblems;

public class Unique3DigitEvenNumbers
{
    public int TotalNumbers(int[] digits) 
    {
        HashSet<int> set = new HashSet<int>();
        int n = digits.Length;
        
        for (int i = 0; i < n; i++) 
        {
            if (digits[i] == 0) continue;
            for (int j = 0; j < n; j++) 
            {
                if (j == i) continue;
                for (int k = 0; k < n; k++) 
                {
                    if (k == i || k == j) continue;
                    if (digits[k] % 2 == 0) 
                    {
                        int number = digits[i] * 100 + digits[j] * 10 + digits[k];
                        set.Add(number);
                    }
                }
            }
        }
        return set.Count;
    }
    
    [Test(Description = "https://leetcode.com/problems/unique-3-digit-even-numbers/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Unique 3 digits even numbers")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int Output, int[] Input) item)
    {
        var response = TotalNumbers(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(int Output, int[] Input)> Input =>
        new List<(int Output, int[] Input)>()
        {
            (12, [1,2,3,4]),
        };
}