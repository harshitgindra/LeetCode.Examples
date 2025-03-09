using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Binary_Tree_Inorder_Traversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> results = new List<int>();
            Traverse(root, results);
            return results;
        }

        private void Traverse(TreeNode node, IList<int> results)
        {
            if (node != null)
            {
                this.Traverse(node.left, results);
                results.Add(node.val);
                this.Traverse(node.right, results);
            }
        }

        [Test(Description = "https://leetcode.com/problems/binary-tree-inorder-traversal/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Binary Tree Inorder Traversal")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<int> Output, TreeNode Input) item)
        {
            var response = this.InorderTraversal(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
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
