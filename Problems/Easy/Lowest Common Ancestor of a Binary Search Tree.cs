using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var val = Find(root, new List<int>(), p.val, q.val, new List<List<int>>());

            var arry1 = val[0];
            var arry2 = val[1];
            var minLength = Math.Min(arry1.Count, arry2.Count);
            for (int i = minLength - 1; i >= 0; i--)
            {
                if (arry1[i] == arry2[i])
                {
                    return new TreeNode(arry1[i]);
                }
            }
            return default;
        }

        public List<List<int>> Find(TreeNode node, List<int> key, int pValue, int qValue, List<List<int>> val)
        {
            if (node == null || val.Count == 2)
            {
                return val;
            }
            if (node.val == pValue || node.val == qValue)
            {
                key.Add(node.val);
                val.Add(key.ToList());
                key.RemoveAt(key.Count - 1);
            }

            if (val.Count < 2)
            {
                key.Add(node.val);
                val = Find(node.left, key, pValue, qValue, val);
                val = Find(node.right, key, pValue, qValue, val);
                key.RemoveAt(key.Count - 1);
            }
            return val;
        }

        [Test(Description = "https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Lowest Common Ancestor of a Binary Search Tree")]
        [TestCaseSource("Input")]
        public void Test1((TreeNode Output, (TreeNode, TreeNode, TreeNode) Input) item)
        {
            var response = this.LowestCommonAncestor(item.Input.Item1, item.Input.Item2, item.Input.Item3);
            // Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(TreeNode Output, (TreeNode, TreeNode, TreeNode) Input)> Input
        {
            get
            {
                return new List<(TreeNode Output, (TreeNode, TreeNode, TreeNode) Input)>()
                {
                      (new TreeNode(6), (new TreeNode(6, new TreeNode(2), new TreeNode(8)), new TreeNode(2), new TreeNode(8))),

                     //(new TreeNode(2), (new TreeNode(6, new TreeNode(2, new TreeNode(4)), new TreeNode(8)), new TreeNode(2), new TreeNode(4)))
                };
            }
        }
    }
}
