using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var val = Find(root, "", p.val, q.val, new List<string>());

            var arry1 = val[0].Split(",");
            var arry2 = val[1].Split(",");
            var minLength = Math.Min(arry1.Length, arry2.Length);
            for (int i = minLength - 1; i >= 0; i--)
            {
                if (arry1[i] == arry2[i])
                {
                    return new TreeNode(Convert.ToInt32(arry1[i]));
                }
            }
            return default;
        }

        public List<string> Find(TreeNode node, string key, int pValue, int qValue, List<string> val)
        {
            if (node == null || val.Count == 2)
            {
                return val;
            }
            if (node.val == pValue || node.val == qValue)
            {
                var newVal = $"{key},{node.val}";
                val.Add(newVal);
            }

            if (val.Count < 2)
            {
                var newVal = $"{key},{node.val}";
                val = Find(node.left, newVal, pValue, qValue, val);
                val = Find(node.right, newVal, pValue, qValue, val);
            }
            return val;
        }

        [Test(Description = "https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Lowest Common Ancestor of a Binary Search Tree")]
        [TestCaseSource("Input")]
        public void Test1((TreeNode Output, (TreeNode, TreeNode, TreeNode) Input) item)
        {
            var response = this.LowestCommonAncestor(item.Input.Item1, item.Input.Item2, item.Input.Item3);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(TreeNode Output, (TreeNode, TreeNode, TreeNode) Input)> Input
        {
            get
            {
                return new List<(TreeNode Output, (TreeNode, TreeNode, TreeNode) Input)>()
                {
                     (new TreeNode(2), (new TreeNode(6, new TreeNode(2, new TreeNode(4)), new TreeNode(8)), new TreeNode(2), new TreeNode(4)))
                };
            }
        }
    }
}
