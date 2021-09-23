using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Leetcode.Problems._2021.Sept
{
    public class Break_a_Palindrome
    {
        public string BreakPalindrome(string palindrome)
        {
            string returnValue = "";
            //***
            //*** Check if length of string is greater than 2
            //*** if not, return empty string
            //*** 
            if (palindrome.Length > 1)
            {
                var arry = palindrome.ToArray();
                //***
                //*** Iterate through all characters until the center of string
                //***
                for (int i = 0; i < palindrome.Length / 2; i++)
                {
                    if (arry[i] != 'a')
                    {
                        arry[i] = 'a';
                        returnValue = new string(arry);
                        break;
                    }
                }

                if (string.IsNullOrEmpty(returnValue))
                {
                    //***
                    //*** We have all 'a' in the first half of the string
                    //*** It means that we also have all 'a' in second half
                    //*** So we will update the last character to 'b' and return the result
                    //***
                    arry[palindrome.Length -1] = 'b';
                    returnValue = new string(arry);
                }
            }

            return returnValue;

        }
        
        [Test(Description ="https://leetcode.com/problems/break-a-palindrome/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Break a Palindrome")]
        [Category("1328")]
        [TestCaseSource("Input")]
        public void Test1((string Output, string Input) item)
        {
            var response = BreakPalindrome(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, string Input)> Input
        {
            get
            {
                return new List<(string Output, string Input)>()
                {
                    ("aaccba", "abccba"),
                };
            }
        }
    }
}