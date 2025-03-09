using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Binary_Tree_Preorder_Traversal
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> results = new List<int>();
            Process(root, results);
            return results;
        }

        private void Process(TreeNode node, IList<int> results)
        {
            if (node != null)
            {
                results.Add(node.val);

                Process(node.left, results);

                Process(node.right, results);
            }
        }

        [Test(Description = "https://leetcode.com/problems/binary-tree-preorder-traversal/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Binary Tree Preorder Traversal")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<int> Output, int?[] Input) item)
        {
            var input = TreeNodeBuilder.ArrayToTreeNode(item.Input);
            var response = this.PreorderTraversal(input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(IList<int> Output, int?[] Input)> Input
        {
            get
            {
                return new List<(IList<int> Output, int?[] Input)>()
                {
                    (new List<int>{ 1,2,3}, new int?[]{1, null, 2,3})
                };
            }
        }
    }
}
