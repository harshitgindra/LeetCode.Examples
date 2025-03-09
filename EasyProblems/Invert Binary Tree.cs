using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
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
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Invert Binary Tree")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int?[] Output, int?[] Input) item)
        {
            var response = InvertTree(item.Input.ToTreeNode());
            Assert.That(response.ToArray(), Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int?[] Output, int?[] Input)> Input =>
            new List<(int?[] Output, int?[] Input)>()
            {
                ([4, 7, 2, 9, 6, 3, 1], ( [4, 2, 7, 1, 3, 6, 9])),
            };
    }
}