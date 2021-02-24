using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Easy
{
    public class Defuse_the_Bomb
    {
        public int[] Decrypt(int[] code, int k)
        {
            if (k == 0)
            {
                return new int[code.Length];
            }

            int[] prefixSum = new int[code.Length * 2 + 2];
            for (int i = 0; i < code.Length; i++)
            {
                prefixSum[i + 1] = prefixSum[i] + code[i];
            }

            for (int i = 0; i < code.Length; i++)
            {
                prefixSum[code.Length + i + 1] = prefixSum[code.Length + i] + code[i];
            }

            int[] result = new int[code.Length];
            for (int i = 0; i < code.Length; i++)
            {
                if (k < 0)
                {
                    int newK = -1 * k;
                    result[i] = prefixSum[i + code.Length] - prefixSum[i + code.Length - newK];
                }

                else
                {
                    result[i] = prefixSum[i + 1 + k] - prefixSum[i + 1];
                }
            }

            return result;
        }
    }
}