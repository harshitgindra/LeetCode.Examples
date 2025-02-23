using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Path_Sum
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                return Add(root, sum, root.val);
            }
        }

        private bool Add(TreeNode node, int sum, int currSum)
        {
            if (node.left == null && node.right == null)
            {
                return sum == currSum;
            }
            else
            {
                if (node.left != null)
                {
                    if (Add(node.left, sum, currSum + node.left.val))
                    {
                        return true;
                    }
                }

                if (node.right != null)
                {
                    if (Add(node.right, sum, currSum + node.right.val))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        [Test(Description = "https://leetcode.com/problems/path-sum/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Path Sum")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (int?[], int) Input) item)
        {
            var treeNode = TreeNodeBuilder.ArrayToTreeNode(item.Input.Item1);
            var response = HasPathSum(treeNode, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (int?[], int) Input)> Input
        {
            get
            {
                return new List<(bool Output, (int?[], int) Input)>()
                {
                    (true, (new int?[] { 5,4,8,11,null,13,4,7,2,null,null,null,1 }, 22)),
                };
            }
        }
    }
}