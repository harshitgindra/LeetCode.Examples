using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public class NumberOfSubstringsWithOnly_s
    {
        public int NumSub(string s)
        {
            int sLength = s.Length;
            int returnValue = 0;
            for (int i = 0; i < sLength; i++)
            {
                for (int j = 1; j <= sLength - i; j++)
                {
                    bool increment = true;
                    for (int k = i; k < j; k++)
                    {
                        if (s[k] == '0')
                        {
                            increment = false;
                            break;
                        }
                    }
                    if (!increment)
                    {
                        break;
                    }
                    else
                    {
                        returnValue++;

                    }
                }
            }

            return returnValue;
        }
    }
}
