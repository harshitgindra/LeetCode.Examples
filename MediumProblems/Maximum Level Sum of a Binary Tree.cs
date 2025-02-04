using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Medium
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree/
    /// </summary>
    public class Maximum_Level_Sum_of_a_Binary_Tree
    {
        public int MaxLevelSum(TreeNode root)
        {
            if (root != null)
            {
                var dict = new Dictionary<int, int>();
                dict = Check(root, dict, 1);
                return dict.OrderByDescending(x=>x.Value)
                    .First()
                    .Key;
            }

            return 0;
        }

        private Dictionary<int, int> Check(TreeNode node, Dictionary<int, int> dict, int currLevel)
        {
            if (node != null)
            {
                if (dict.ContainsKey(currLevel))
                {
                    dict[currLevel] += node.val;
                }
                else
                {
                    dict.Add(currLevel, node.val);
                }

                dict = Check(node.left, dict, currLevel + 1);
                dict = Check(node.right, dict, currLevel + 1);
            }

            return dict;
        }
    }
}