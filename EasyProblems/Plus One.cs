using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Plus_One
    {
        public int[] PlusOne(int[] digits)
        {
            Stack<int> result = new Stack<int>();

            int carry = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                if (digits[i] == 9 && carry == 1)
                {
                    carry = 1;
                    result.Push(0);
                }
                else
                {
                    result.Push(digits[i] + carry);
                    carry = 0;
                }
            }

            if (carry == 1)
            {
                result.Push(carry);
            }

            return result.ToArray();
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
