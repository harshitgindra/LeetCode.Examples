using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeetCode.Medium
{
    class Find_K_Closest_Elements
    {
        public IList<int> FindClosestElements2(int[] arr, int k, int x)
        {
            List<(int, int)> diff = new List<(int, int)>();
            for (int i = 0; i < arr.Length; i++)
            {
                diff.Add((i, Math.Abs(arr[i] - x)));
            }

            var recs = diff.OrderBy(x => x.Item2)
                .Select(x => x.Item1)
                .OrderBy(x => x)
                .Take(k)
                .Select(x => arr[x])
                .ToList();

            return recs;
        }

        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            SortedDictionary<int, List<int>> dict = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                var difference = Math.Abs(arr[i] - x);

                if (dict.ContainsKey(difference))
                {
                    dict[difference].Add(arr[i]);
                }
                else
                {
                    dict.Add(difference, new List<int>() { arr[i] });
                }
            }

            List<int> result = new List<int>();
            int counter = 1;

            foreach (var item in dict.SelectMany(x => x.Value))
            {
                if (counter <= k)
                {
                    result.Add(item);
                    counter++;
                }
                else
                {
                    break;
                }
            }

            return result.OrderBy(x => x).ToList();
        }

        [Test(Description = "https://leetcode.com/problems/find-k-closest-elements/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Find K Closest Elements")]
        [TestCaseSource("Input")]
        public void Test1((IList<int> Output, (int[], int, int) Input) item)
        {
            var response = FindClosestElements(item.Input.Item1, item.Input.Item2, item.Input.Item3);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(IList<int> Output, (int[], int, int) Input)> Input
        {
            get
            {
                return new List<(IList<int> Output, (int[], int, int) Input)>()
                {
                    (new List<int>(){ 1,2,3,4}, (new int[]{1,2,3,4,5}, 4,3)),
                    (new List<int>(){ 1,2,3,4}, (new int[]{1,2,3,4,5}, 4,-1)),
                };
            }
        }
    }
}
