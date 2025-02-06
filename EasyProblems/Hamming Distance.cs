using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Hamming_Distance
    {
        public int HammingDistance(int x, int y)
        {
            string xStr = Convert.ToString(x, 2);
            string yStr = Convert.ToString(y, 2);

            int maxLength = Math.Max(xStr.Length, yStr.Length);
            xStr = xStr.PadLeft(maxLength, '0');
            yStr = yStr.PadLeft(maxLength, '0');

            int returnValue = 0;
            for (int i = 0; i < maxLength; i++)
            {
                if (xStr[i] != yStr[i])
                {
                    returnValue++;
                }
            }
            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/hamming-distance/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Hamming Distance")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int, int) Input) item)
        {
            var response = HammingDistance(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int, int) Input)> {
                    (2, (1,4)),
                };
            }
        }
    }
}
