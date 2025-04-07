namespace LeetCode.MediumProblems
{
    class Binary_Tree_Level_Order_Traversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            Dictionary<int, IList<int>> dict = new Dictionary<int, IList<int>>();
            Process(root, 0, dict);
            return dict.Values.ToList();
        }

        private void Process(TreeNode node, int level, Dictionary<int, IList<int>> dict)
        {
            if (node != null)
            {
                if (dict.ContainsKey(level))
                {
                    dict[level].Add(node.val);
                }
                else
                {
                    dict.Add(level, new List<int>() { node.val });
                }

                Process(node.left, level + 1, dict);
                Process(node.right, level + 1, dict);
            }
        }

        [Test(Description = "https://leetcode.com/problems/binary-tree-level-order-traversal/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Binary Tree Level Order Traversal")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<IList<int>> Output, TreeNode Input) item)
        {
            var response = this.LevelOrder(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(IList<IList<int>> Output, TreeNode Input)> Input =>
            new List<(IList<IList<int>> Output, TreeNode Input)>()
            {
                (new List<IList<int>>()
                {
                    new List<int>() { 3 },
                    new List<int>() { 9, 20 },
                    new List<int>() { 15, 7 },
                }, new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))))
            };
    }
}