using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ArrangingCoins
    {
        public ArrangingCoins()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Arranging Coins");
            Console.WriteLine("----------------------------------------------------------");
        }

        public int Start(int n)
        {
            int numberOfCoinsRemaining = n;
            int numberOfRows = 0;

            int i = 1;
            while (numberOfCoinsRemaining >= 0)
            {
                numberOfCoinsRemaining = numberOfCoinsRemaining - i;

                if (numberOfCoinsRemaining >= 0)
                {
                    numberOfRows++;
                }

                i++;
            }

            return numberOfRows;
        }
    }
}
