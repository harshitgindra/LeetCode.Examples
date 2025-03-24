namespace LeetCode.EasyProblems;

public class CheckIfDigitsAreEqualInStringAfterOperationsI
{
    public bool HasSameDigits(string s) {
        while (s.Length > 2) {
            System.Text.StringBuilder newbornString = new System.Text.StringBuilder();
            for (int i = 0; i < s.Length - 1; i++) {
                int firstDigit = s[i];                  
                int secondDigit = s[i + 1];            
                int newDigit = (firstDigit + secondDigit) % 10; 
                newbornString.Append(newDigit);              
            }
            s = newbornString.ToString();                     
        }
        
        return s[0] == s[1];
    }
    
    [Test(Description = "https://leetcode.com/problems/check-if-digits-are-equal-in-string-after-operations-i/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Check If Digits Are Equal in String After Operations I")]
    [TestCaseSource(nameof(Input))]
    public void Test1((bool Output, string Input) item)
    {
        var response = HasSameDigits(item.Input);
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(bool Output, string Input)> Input =>
        new List<(bool Output, string Input)>()
        {
            (true, "3902"),
        };
}