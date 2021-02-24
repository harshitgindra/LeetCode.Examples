using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    //https://leetcode.com/problems/uncommon-words-from-two-sentences/
    class Uncommon_Words_from_Two_Sentences
    {
        public string[] UncommonFromSentences(string A, string B)
        {
            IDictionary<string, int> dic = new Dictionary<string, int>();
            foreach (var item in $"{A} {B}".Split(" "))
            {
                if (!dic.ContainsKey(item))
                {
                    dic.Add(item, 1);
                }
                else
                {
                    dic[item]++;
                }
            }

            return dic.Where(x => x.Value == 1).Select(x => x.Key).ToArray();
        }
    }
}
