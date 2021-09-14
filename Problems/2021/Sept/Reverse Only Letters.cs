using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.Sept
{
    /// <summary>
    /// https://leetcode.com/problems/reverse-only-letters/
    /// </summary>
    class Reverse_Only_Letters
    {
        public string ReverseOnlyLetters(string S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return string.Empty;
            }
            else
            {
                var arry = S.ToCharArray();
                int sIndex = 0;
                int eIndex = S.Length - 1;
                while (sIndex < eIndex)
                {
                    if (char.IsLetter(arry[sIndex]))
                    {
                        if (char.IsLetter(arry[eIndex]))
                        {
                            var temp = arry[eIndex];
                            arry[eIndex--] = arry[sIndex];
                            arry[sIndex++] = temp;
                        }
                        else
                        {
                            eIndex--;
                        }
                    }
                    else
                    {
                        sIndex++;
                    }
                }

                return string.Join("", arry);
            }
        }
    }
}
