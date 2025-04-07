using LeetCode.SharedUtils;

namespace LeetCode.MediumProblems
{
    class BinaryTreeZigzagLevelOrderTraversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            // Create a dictionary to store nodes at each level
            var levelMap = new Dictionary<int, IList<int>>();

            // Perform a depth-first traversal to populate the level map
            TraverseBinaryTree(root, 0, levelMap);

            // Convert the dictionary values to a list and return
            return levelMap.Values.ToList();
        }

        private void TraverseBinaryTree(TreeNode node, int level, IDictionary<int, IList<int>> levelMap)
        {
            if (node == null) return;

            // If this level hasn't been encountered before, add it to the dictionary
            if (!levelMap.ContainsKey(level))
            {
                levelMap[level] = new List<int>();
            }

            // Add the node's value to the appropriate level
            // For even levels, add to the end; for odd levels, add to the beginning
            if (level % 2 == 0)
            {
                levelMap[level].Add(node.val);
            }
            else
            {
                levelMap[level].Insert(0, node.val);
            }

            // Recursively traverse left and right children
            TraverseBinaryTree(node.left, level + 1, levelMap);
            TraverseBinaryTree(node.right, level + 1, levelMap);
        }

        [Test(Description = "https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Binary Tree Zig Zag Level Order Traversal")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<IList<int>> Output, int?[] Input) item)
        {
            var response = this.ZigzagLevelOrder(item.Input.ToTreeNode());
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(IList<IList<int>> Output, int?[] Input)> Input =>
            new List<(IList<IList<int>> Output, int?[] Input)>()
            {
                (new List<IList<int>>()
                {
                    new List<int>() { 3 },
                    new List<int>() { 20, 9 },
                    new List<int>() { 15, 7 },
                }, [3, 9, 20, null, null, 15, 7])
            };
    }
}