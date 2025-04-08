namespace LeetCode.MediumProblems
{
    class ValidateBinarySearchTree
    {
        public bool IsValidBST(TreeNode root)
        {
            // Use a more efficient approach with a single traversal
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBST(TreeNode node, long min, long max)
        {
            // Base case: empty trees are valid BSTs
            if (node == null)
            {
                return true;
            }

            // Check if current node's value is within valid range
            if (node.val <= min || node.val >= max)
            {
                return false;
            }

            // Recursively check left subtree (must be < node.Val) and right subtree (must be > node.Val)
            return IsValidBST(node.left, min, node.val) &&
                   IsValidBST(node.right, node.val, max);
        }

        [Test(Description = "https://leetcode.com/problems/validate-binary-search-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Validate Binary Search Tree")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, int?[] Input) item)
        {
            var response = this.IsValidBST(item.Input.ToTreeNode());
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(bool Output, int?[] Input)> Input =>
            new List<(bool Output, int?[] Input)>()
            {
                (true, [2, 1, 3])
            };
    }
}