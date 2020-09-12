using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    public class House_Robber_III
    {
        public int Rob(TreeNode root)
        {
            var result = StartRobbing(root, 0, new SortedDictionary<int, int>());
            return Rob(result.Values.ToArray(), 0, result.Count);
        }

        public int Rob(int[] nums, int start, int end)
        {
            int previousLevel1 = 0;
            int previousLevel2 = 0;
            int current = 0;
            for (int i = start; i < end; i++)
            {
                current = Math.Max(nums[i] + previousLevel2, previousLevel1);
                previousLevel2 = previousLevel1;
                previousLevel1 = current;
            }
            return current;
        }

        private SortedDictionary<int, int> StartRobbing(TreeNode node, int level, SortedDictionary<int, int> result)
        {
            if (node != null)
            {
                if (result.ContainsKey(level))
                {
                    result[level] = result[level] + node.val;
                }
                else
                {
                    result.Add(level, node.val);
                }

                result = StartRobbing(node.left, level + 1, result);
                result = StartRobbing(node.right, level + 1, result);
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/house-robber-iii/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("House Robber 3")]
        public void Test1()
        {
            var response = Rob(new TreeNode(4, new TreeNode(1, new TreeNode(2, new TreeNode(3)))));
        }
    }
}
