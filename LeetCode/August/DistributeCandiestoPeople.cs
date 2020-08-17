using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.August
{
    public class DistributeCandiestoPeople
    {
        public int[] DistributeCandies(int candies, int num_people)
        {
            int[] ppl = new int[num_people];
            int index = 0, numOfCandiesToGive = 1;
            while (true)
            {
                //***
                //*** Check if there are enough candies left to give
                //*** 
                if (candies > numOfCandiesToGive)
                {
                    //***
                    //*** Give the candies and substract it from the total
                    //***
                    ppl[index] += numOfCandiesToGive;
                    candies -= numOfCandiesToGive;
                }
                else
                {
                    //***
                    //*** Give away the rest of the candies and break the loop
                    //*** 
                    ppl[index] += candies;
                    break;
                }

                numOfCandiesToGive++;
                //***
                //*** If next index equals to length, reset the index
                //***
                if (index + 1 == num_people)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }

            return ppl;
        }
    }
}
