using NUnit.Framework;
using System.Collections.Generic;

namespace Leetcode.Problems._2021.Sept
{
    class Slowest_Key
    {
        public char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            int prev = 0;
            int maxTime = 0;
            char returnValue = default;
            for (int i = 0; i < keysPressed.Length; i++)
            {
                //***
                //*** Calculate key pressed time 
                //*** 
                var time = releaseTimes[i] - prev;
                //***
                //*** time greater than previous max time
                //*** Update the max time
                //*** And set returnValue to corresponding char
                //***
                if (time > maxTime)
                {
                    returnValue = keysPressed[i];
                    maxTime = time;
                }
                //***
                //*** Time equal to previous max time
                //*** Compare previous char to current char and select char higher in lexicographical order
                //***
                else if (time == maxTime && returnValue < keysPressed[i])
                {
                    returnValue = keysPressed[i];
                }
                prev = releaseTimes[i];
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/slowest-key/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Sloweest Key")]
        [TestCaseSource("Input")]
        public void Test1((char Output, (int[] releaseTimes, string keysPressed) Input) item)
        {
            var response = SlowestKey(item.Input.releaseTimes, item.Input.keysPressed);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(char Output, (int[] releaseTimes, string keysPressed) Input)> Input
        {
            get
            {
                return new List<(char Output, (int[] releaseTimes, string keysPressed) Input)>()
                {
                    ('c',(new int[]{ 9,29,49,50}, "cbcd")),
                    ('a',(new int[]{ 12,23,36,46,62}, "spuda")),
                };
            }
        }
    }
}
