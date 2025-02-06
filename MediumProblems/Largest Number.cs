using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Largest_Number
    {
        public string LargestNumber(int[] nums)
        {
            var numStrs = nums.Select(x => $"{x}").ToArray();
            Array.Sort(numStrs, (a, b) => (b + a).CompareTo(a + b));

            if (numStrs[0] == "0")
            {
                return "0";
            }

            return string.Join("", numStrs);
        }

        [Test(Description = "https://leetcode.com/problems/largest-number/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Largest Number")]
        [TestCaseSource("Input")]
        public void Test1((string Output, int[] Input) item)
        {
            var response = LargestNumber(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, int[] Input)> Input
        {
            get
            {
                return new List<(string Output, int[] Input)>()
                {

                    ("210", new int[]{2, 10 }),
                    ("9534330", new int[]{3,30,34,5,9 })
                };
            }
        }
    }
}
