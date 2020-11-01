using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Relative_Sort_Array
    {
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            var dict = new Dictionary<int, int>();
            foreach (var item in arr1)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            int[] ret = new int[arr1.Length];
            int index = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                var item = dict[arr2[i]];

                while (item > 0)
                {
                    ret[index++] = arr2[i];
                    item--;
                }
                dict.Remove(arr2[i]);
            }

            if (dict.Any())
            {
                foreach (var item in dict.OrderBy(x => x.Key))
                {
                    var temp = item.Value;
                    while (temp > 0)
                    {
                        ret[index++] = item.Key;
                        temp--;
                    }
                }
            }

            return ret;
        }
    }
}
