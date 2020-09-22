using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeetCode.Easy
{
    public class Increasing_Order_Search_Tree
    {
        public TreeNode IncreasingBST(TreeNode root)
        {
            var result = Discover(root, new List<int>());
            TreeNode node = new TreeNode(result[0]);
            node = Add(result, 1, node);
            return node;
        }

        private TreeNode Add(List<int> nums, int index, TreeNode node)
        {
            if (index < nums.Count)
            {
                node.right = new TreeNode(nums[index]);
                node.right = Add(nums, index + 1, node.right);
            }

            return node;
        }

        private List<int> Discover(TreeNode node, List<int> nums)
        {
            if (node != null)
            {
                nums = Discover(node.left, nums);
                nums.Add(node.val);
                nums = Discover(node.right, nums);
            }

            return nums;
        }

        [Test(Description = "https://leetcode.com/problems/increasing-order-search-tree/")]
        [Category("Easy")]
        [Category("Leetcode")]
        [Category("Increasing Order Search Tree")]
        [TestCaseSource("Input")]
        public void Test1((TreeNode Output, TreeNode Input) item)
        {
            var response = IncreasingBST(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(TreeNode Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(TreeNode Output, TreeNode Input)>()
                {

                    (null, new TreeNode(5, new TreeNode(3, new TreeNode(2, new TreeNode(1)), new TreeNode(4)), new TreeNode(6, null, new TreeNode(8, new TreeNode(7), new TreeNode(9)))))
                };
            }
        }
    }
}
