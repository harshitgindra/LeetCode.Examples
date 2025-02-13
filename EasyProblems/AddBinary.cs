using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems;

public class Add_Binary
{
    public string AddBinary(string a, string b)
    {
        int ia = a.Length - 1;
        int ib = b.Length - 1;
        string returnValue = "";
        char carry = '0';
        
        while (ia >= 0 || ib >= 0)
        {
            var tempA = '0';
            if (ia >= 0)
            {
                tempA = a[ia];
            }
            
            var tempB = '0';
            if (ib >= 0)
            {
                tempB = b[ib];
            }

            var result = Add(tempA, tempB, carry);

            carry = result.carry;
            returnValue = $"{result.sum}{returnValue}";
            
            ia--;
            ib--;
        }
        
        if (carry != '0')
        {
            returnValue = $"{carry}{returnValue}";
        }
        return returnValue;
    }

    private (char sum, char carry) Add(char a, char b, char carry)
    {
        switch ($"{a}{b}{carry}")
        {
            case "000":
                return ('0', '0');
            case "001":
            case "010":
            case "100":
                return ('1', '0');
            case "110":
            case "101":
            case "011":
                return ('0', '1');
            case "111":
                return ('1', '1');
            default:
                throw new Exception();
        }
    }

    [Test(Description = "https://leetcode.com/problems/plus-one/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Plus One")]
    [TestCaseSource("Input")]
    public void Test1((string Output, (string a, string b) Input) item)
    {
        var response = AddBinary(item.Input.a, item.Input.b);
        ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(string Output, (string a, string b) Input)> Input
    {
        get
        {
            return new List<(string Output, (string a, string b) Input)>()
            {
                ("100", ("11", "1")),
                ("10101", ("1010", "1011")),
                ("11110", ("1111", "1111")),
            };
        }
    }
}