using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeetCode
{
    public class SingleNumberTest
    {
        public SingleNumberTest()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Single Number Test");
            Console.WriteLine("----------------------------------------------------------");
        }



        public int SingleNumber(int[] nums)
        {
            HashSet<int> i = new HashSet<int>();
            foreach (var num in nums)
            {
                if (i.Contains(num))
                {
                    i.Remove(num);
                }
                else
                {
                    i.Add(num);
                }
            }

            return i.First();
        }
    }
}
