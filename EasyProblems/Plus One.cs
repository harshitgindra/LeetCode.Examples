using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Plus_One
    {
        public int[] PlusOne(int[] digits)
        {
            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var newTotal = digits[i] + carry;
                if (newTotal == 10)
                {
                    digits[i] = 0;
                    carry = 1;
                }
                else
                {
                    digits[i] = newTotal;
                    carry = 0;
                }
            }

            if (digits[0] == 0 && carry == 1)
            {
                int[] newDigits = new int[digits.Length + 1];
                newDigits[0] = 1;

                for (int i = 1; i < digits.Length; i++)
                {
                    newDigits[i] = digits[i-1];
                }
                return newDigits;
            }
            else
            {
                return digits;
            }
        }

        [Test(Description = "https://leetcode.com/problems/plus-one/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Plus One")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = PlusOne(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input
        {
            get
            {
                return new List<(int[] Output, int[] Input)>()
                {
                    (new int[]{9,8,7,6,5,4,3,2,1,1}, new int[] {9,8,7,6,5,4,3,2,1,0}),
                    (new int[]{ 1,0,0,}, new int[] {9,9}),
                };
            }
        }
    }
}
