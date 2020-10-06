using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Group_Anagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IDictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                var o = string.Join("", strs[i].OrderBy(x => x));
                if (dict.ContainsKey(o))
                {
                    dict[o].Add(strs[i]);
                }
                else
                {
                    dict.Add(o, new List<string>() { strs[i] });
                }
            }

            IList<IList<string>> ret = new List<IList<string>>();
            foreach (var item in dict)
            {
                ret.Add(item.Value.ToList());
            }

            return ret;
        }
    }
}
