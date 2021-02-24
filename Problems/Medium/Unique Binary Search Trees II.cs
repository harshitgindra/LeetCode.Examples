using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Unique_Binary_Search_Trees_II
    {

        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0) return new List<TreeNode>();
            return DFS(1, n);
        }

        private IList<TreeNode> DFS(int start, int end)
        {
            if (start > end)
            {
                return new List<TreeNode>() { null };
            }
            var result = new List<TreeNode>();
            for (int i = start; i <= end; i++)
            {
                var leftList = DFS(start, i - 1);
                var rightList = DFS(i + 1, end);

                foreach (var left in leftList)
                {
                    foreach (var right in rightList)
                    {
                        var root = new TreeNode(i);
                        root.left = left;
                        root.right = right;
                        result.Add(root);
                    }
                }
            }

            return result;
        }


        public IList<TreeNode> GenerateTrees2(int n)
        {
            TreeNode node = new TreeNode(n);
            var results = Map(new List<TreeNode>(), node, node, n - 1);
            //node.left = null;
            //results = Map(results, node.right, node, n - 1);
            return results;
        }

        private IList<TreeNode> Map(IList<TreeNode> result, TreeNode innernode, TreeNode mainnode, int remaining)
        {
            if (remaining == 0)
            {
                var n = new TreeNode(0, mainnode);
                result.Add(n.left);
            }
            else
            {
                if (innernode != null || remaining >= 0)
                {
                    // only left
                    innernode.left = new TreeNode(remaining);
                    result = Map(result, innernode.left, mainnode, remaining - 1);
                    innernode.left = null;

                    innernode.right = new TreeNode(remaining);
                    result = Map(result, innernode.right, mainnode, remaining - 1);
                    innernode.right = null;
                }
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/unique-binary-search-trees-ii/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Unique Binary Search Trees II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int Input) item)
        {
            var response = this.GenerateTrees(item.Input);
            Assert.AreEqual(item.Output, response.Count);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {
                    (5, 3),
                };
            }
        }
    }
}
