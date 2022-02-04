using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Invert_Binary_Tree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            return Invert(root);
        }

        private TreeNode Invert(TreeNode root)
        {
            if (root != null)
            {
                var tempNode = root.left;
                root.left = root.right;
                root.right = tempNode;

                root.left = Invert(root.left);
                root.right = Invert(root.right);
            }

            return root;
        }


        [Test(Description = "https://leetcode.com/problems/invert-binary-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Invert Binary Tree")]
        [TestCaseSource("Input")]
        public void Test1((TreeNode Output, TreeNode Input) item)
        {
            var response = this.InvertTree(item.Input);
            //Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(TreeNode Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(TreeNode Output, TreeNode Input)>()
                {
                    (null,
                    new TreeNode(4,new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7, new TreeNode(6), new TreeNode(9))))
                };
            }
        }
    }
}
