using LeetCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace Leetcode.Problems._2021.Sept
{
    class Maximum_Average_Subtree
    {
        double _maxAverage = 0.0;
        public double MaximumAverageSubtree(TreeNode root)
        {
            _maxAverage = 0;
            Traverse(root);
            return _maxAverage;
        }

        private (double total, int count) Traverse(TreeNode node)
        {
            if (node == null)
            {
                return (0.0, 0);
            }
            else
            {
                var leftResponse = Traverse(node.left);
                var rightResponse = Traverse(node.right);

                var sum = node.val + leftResponse.total + rightResponse.total;
                var count = leftResponse.count + rightResponse.count + 1;
                _maxAverage = Math.Max(_maxAverage, sum / count);
                return (sum, count);
            }
        }

        [Test(Description = "https://leetcode.com/problems/maximum-average-subtree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Maximum Average Subtree")]
        [TestCaseSource("Input")]
        public void Test1((double Output, TreeNode Input) item)
        {
            var response = MaximumAverageSubtree(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(double Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(double Output, TreeNode Input)>()
                {
                    (1.5,new TreeNode(2, null, new TreeNode(1))),
                };
            }
        }
    }
}
