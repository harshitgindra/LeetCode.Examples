using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    public class BinaryWatch
    {
        public IList<string> ReadBinaryWatch(int num)
        {
            List<string> result = new List<string>();

            if (num <= 10)
            {
                Read(num, 0, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, result);
            }

            return result;
        }

        private void Read(int num, int startIndex, int[] binaryText, List<string> result)
        {
            if (binaryText.Count(x => x == 1) == num)
            {
                int hour = Convert.ToInt32($"{binaryText[0]}{binaryText[1]}{binaryText[2]}{binaryText[3]}", 2);

                if (hour < 12)
                {
                    int min = Convert.ToInt32($"{binaryText[4]}{binaryText[5]}{binaryText[6]}{binaryText[7]}{binaryText[8]}{binaryText[9]}", 2);

                    if (min < 60)
                    {
                        result.Add($"{hour}:{min:00}");
                    }
                }
            }
            else
            {
                for (int i = startIndex; i < 10; i++)
                {
                    binaryText[i] = 1;
                    Read(num, i + 1, binaryText, result);
                    binaryText[i] = 0;
                }
            }
        }


        [Test(Description = "https://leetcode.com/problems/binary-watch/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Binary Watch")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int Input) item)
        {
            var response = ReadBinaryWatch(item.Input);
            ClassicAssert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {

                    (10, 1),
                };
            }
        }
    }
}
