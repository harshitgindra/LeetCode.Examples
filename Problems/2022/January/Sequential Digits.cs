using System;
using System.Collections.Generic;

namespace Leetcode.Problems._2022.January
{
    /// <summary>
    /// https://leetcode.com/problems/sequential-digits/
    /// </summary>
    public class Sequential_Digits
    {
        public IList<int> SequentialDigits(int low, int high)
        {
            string sample = "123456789";
            int lowLength = low.ToString().Length;
            int highLength = high.ToString().Length;
            IList<int> result = new List<int>();
            //***
            //*** Iterate through all numbers between low length and high length
            //***
            for (int i = lowLength; i <= highLength; i++)
            {
                for (int j = 0; j < sample.Length -i; j++)
                {
                    var num = Convert.ToInt32(sample.Substring(j, i));
                    if (num >= low && num <= high)
                    {
                        result.Add(num);
                    }
                }
            }

            return result;
        }
    }
}