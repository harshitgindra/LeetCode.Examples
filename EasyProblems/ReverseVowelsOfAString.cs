using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class ReverseVowelsOfAString
{
    public string ReverseVowels(string s)
    {
        int i = 0;
        int j = s.Length - 1;
        char[] chars = s.ToCharArray();
        HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];

        while (i < j)
        {
            if (vowels.Contains(s[i]))
            {
                if (vowels.Contains(s[j]))
                {
                    chars[i] = s[j];
                    chars[j] = s[i];
                    i++;
                    j--;
                }
                else
                {
                    j--;
                }
            }
            else
            {
                i++;
            }
        }

        return new string(chars);
    }
    
    [Test(Description = "https://leetcode.com/problems/reverse-vowels-of-a-string/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Reverse Vowels of a string")]
    [TestCaseSource(nameof(Input))]
    public void Test1((string Output, string Input) item)
    {
        var response = ReverseVowels(item.Input);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(string Output, string Input)> Input
    {
        get
        {
            return new List<(string Output, string Input)>()
            {
                ("leotcede", "leetcode"),
                ("AceCreIm", "IceCreAm"),
                ("A", "A"),
            };
        }
    }
}