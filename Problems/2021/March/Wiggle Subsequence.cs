using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode;
using NUnit.Framework;

namespace Leetcode.Problems._2021.March
{
    class Wiggle_Subsequence
    {
        public int WiggleMaxLength(int[] nums)
        {
            //***
            //*** If length of nums is less than 2, return nums.length as max length
            //***
            if (nums.Length < 2)
            {
                return nums.Length;
            }
            else
            {
                //***
                //*** Get the difference between first two elements
                //***
                var difference = nums[1] - nums[0];
                //***
                //*** If the diff is 0, returnValue should be 1; else .
                //***
                var returnValue = difference == 0 ? 1 : 2;
                int i = 1;
                //***
                //*** Loop through i until it is less than nums.Length -1
                //***
                while (i < nums.Length - 1)
                {
                    //***
                    //*** Get the difference between current num and next num
                    //*** And compare it with previous difference
                    //***
                    var tempDiff = nums[i + 1] - nums[i];
                    //***
                    //*** If previous difference is greater than or equal to zero
                    //*** Then the new difference should be less than 0
                    //***
                    if (difference >= 0 && tempDiff < 0)
                    {
                        //***
                        //*** Condition met, update the difference and increment the count
                        //***
                        returnValue++;
                        difference = tempDiff;
                    }
                    //***
                    //*** If previous difference is less than or equal to zero
                    //*** Then the new difference should be greater than 0
                    //***
                    else if (difference <= 0 && tempDiff > 0)
                    {
                        //***
                        //*** Condition met, update the difference and increment the count
                        //***
                        returnValue++;
                        difference = tempDiff;
                    }

                    i++;
                }

                return returnValue;
            }
        }


        [Test(Description = "https://leetcode.com/problems/wiggle-subsequence/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Wiggle Subsequence")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = WiggleMaxLength(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (1, new int[]{3,3,3,2,5}),
                    (7, new int[]{1,17,5,10,13,15,10,5,16,8}),
                    //(default, "1(2(3(4(5(6(7(8)))))))"),
                    //(default, "4"),
                };
            }
        }
    }
}
