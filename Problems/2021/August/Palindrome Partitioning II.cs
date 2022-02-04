using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.August
{
    class Palindrome_Partitioning_II
    {
        public int MinCut(string s)
        {
            int returnValue = 0;
            if (!string.IsNullOrEmpty(s))
            {
                bool[][] dp = new bool[s.Length][];

                //***
                //*** Setting true for all letters as they are palindrome
                //*** Single character
                //***
                for (int i = 0; i < s.Length; i++)
                {
                    dp[i] = new bool[s.Length];
                    dp[i][i] = true;
                }
                //***
                //*** Compare letters in 2 character length strings
                //***
                for (int i = 0; i < s.Length - 1; i++)
                {
                    dp[i][i + 1] = s[i] == s[i + 1];
                }

                for (int length = 3; length <= s.Length; length++)
                {
                    for (int i = 0; i < s.Length - length + 1; i++)
                    {
                        int j = i + length - 1;
                        if (s[i] == s[j] && dp[i + 1][j - 1])
                        {
                            dp[i][j] = true;
                        }
                    }
                }

                int[] cuts = new int[s.Length];

                for (int i = 0; i < s.Length; i++)
                {
                    //***
                    //*** If the substring is already a palindrome, no cut is needed
                    //***
                    if (dp[0][i])
                    {
                        cuts[i] = 0;
                    }
                    else
                    {
                        int temp = int.MaxValue;
                        //***
                        //*** Loop to cut at every possible place within the substring
                        //*** And verify if the result will be palindrome or not
                        //*** And the cuts are optimal based on the previous combinations
                        //***
                        for (int j = 0; j < i; j++)
                        {
                            if (dp[j + 1][i] && temp > cuts[j] + 1)
                            {
                                temp = cuts[j] + 1;
                            }
                        }

                        cuts[i] = temp;
                    }
                }

                returnValue = cuts[s.Length - 1];
            }
            return returnValue;
        }


        [Test(Description = "https://leetcode.com/problems/palindrome-partitioning-ii/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Palindrome Partitioning II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string Input) item)
        {
            var response = MinCut(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {

                    (0, "efe"),
                    (1, "banana"),
                    (1, "aab"),
                };
            }
        }
    }
}
