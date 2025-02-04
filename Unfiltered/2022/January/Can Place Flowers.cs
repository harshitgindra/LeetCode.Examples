namespace Leetcode.Problems._2022.January
{
    /// <summary>
    /// https://leetcode.com/problems/can-place-flowers/
    /// </summary>
    public class Can_Place_Flowers
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int i = 0;
            while (i < flowerbed.Length)
            {
                if (flowerbed[i] == 0)
                {
                    bool canPlant = _RightCanPlant(i, flowerbed);
                    canPlant &= _LeftCanPlant(i, flowerbed);

                    if (canPlant)
                    {
                        flowerbed[i] = 1;
                        n--;
                    }
                }

                i++;
            }

            return n <= 0;
        }

        private bool _LeftCanPlant(int i, int[] flowerbed)
        {
            if (i == 0)
            {
                return true;
            }
            else
            {
                return flowerbed[i - 1] == 0;
            }
        }

        private bool _RightCanPlant(int i, int[] flowerbed)
        {
            if (i == flowerbed.Length - 1)
            {
                return true;
            }
            else
            {
                return flowerbed[i + 1] == 0;
            }
        }
    }
}