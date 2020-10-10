using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class Partition_Labels
    {
        public IList<int> PartitionLabels(string S)
        {
            List<int> results = new List<int>();
            if (S != null && S.Any())
            {
                results = Filter(S.Select(x => x.ToString()).ToList(), results, 0);
            }

            return results;
        }

        private static List<int> Filter(List<string> inputList, List<int> results, int firstIndex)
        {
            int lastIndex = default;
            int currentIndex = firstIndex;
            do
            {
                string entry = inputList[currentIndex];

                int tempLastIndex = inputList.LastIndexOf(entry);

                lastIndex = Math.Max(lastIndex, tempLastIndex);
                currentIndex++;
            } while (currentIndex <= lastIndex && currentIndex < inputList.Count);

            results.Add(lastIndex - firstIndex + 1);

            if (lastIndex != inputList.Count - 1)
            {
                results = Filter(inputList, results, lastIndex + 1);
            }

            return results;
        }
    }
}
}
