using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Binary_Tree_Inorder_Traversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> results = new List<int>();
            Process(root, results);
            return results;
        }

        private void Process(TreeNode node, IList<int> results)
        {
            if (node != null)
            {
                Process(node.left, results);

                results.Add(node.val);

                Process(node.right, results);
            }
        }

        [Test(Description = "https://leetcode.com/problems/binary-tree-preorder-traversal/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Binary Tree Preorder Traversal")]
        [TestCaseSource("Input")]
        public void Test1((IList<int> Output, TreeNode Input) item)
        {
            var response = this.InorderTraversal(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(IList<int> Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(IList<int> Output, TreeNode Input)>()
                {
                    (new List<int>{ 1,3, 2},
                    new TreeNode(1,null, new TreeNode(2, new TreeNode(3))))
                };
            }
        }
    }
}
