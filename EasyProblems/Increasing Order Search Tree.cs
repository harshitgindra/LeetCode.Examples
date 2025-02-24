using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
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
        [Category("LeetCode")]
        [Category("Increasing Order Search Tree")]
        [TestCaseSource("Input")]
        public void Test1((int?[] Output, int?[] Input) item)
        {
            var treeNode = TreeNodeBuilder.ArrayToTreeNode(item.Input);
            var response = IncreasingBST(treeNode);
            TreeNodeBuilder.AssertTreeNodeAgainstArray(response, item.Output);
        }

        public static IEnumerable<(int?[] Output, int?[] Input)> Input
        {
            get
            {
                return new List<(int?[] Output, int?[] Input)>()
                {

                    (new int?[]{1,null,2,null,3,null,4,null,5,null,6,null,7,null,8,null,9}, new int?[]{5,3,6,2,4,null,8,1,null,null,null,7,9})
                };
            }
        }
    }
}
