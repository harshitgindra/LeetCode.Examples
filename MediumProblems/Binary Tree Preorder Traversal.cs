using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
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
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Binary Tree Preorder Traversal")]
        [TestCaseSource("Input")]
        public void Test1((IList<int> Output, TreeNode Input) item)
        {
            var response = this.PreorderTraversal(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(IList<int> Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(IList<int> Output, TreeNode Input)>()
                {
                    (new List<int>{ 1,2,3},
                    new TreeNode(1,null, new TreeNode(2, new TreeNode(3))))
                };
            }
        }
    }
}
