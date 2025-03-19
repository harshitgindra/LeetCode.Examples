using LeetCode.SharedUtils;


namespace LeetCode.MediumProblems
{
    class Sum_Root_to_Leaf_Numbers
    {
        public int SumNumbers(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                List<int> val = new List<int>();
                val = Sum(root, $"0", val);
                return val.Sum();
            }
        }

        private List<int> Sum(TreeNode node, string num, List<int> val)
        {
            if (node == null)
            {
                return val;
            }
            if (node.left == null && node.right == null)
            {
                var newVal = $"{num}{node.val}";
                val.Add(Convert.ToInt32(newVal));
            }
            else
            {
                var newVal = $"{num}{node.val}";
                val = Sum(node.left, newVal, val);
                val = Sum(node.right, newVal, val);
            }

            return val;
        }

        [Test(Description = "https://leetcode.com/problems/sum-root-to-leaf-numbers/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Sum Root to Leaf Numbers")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, TreeNode Input) item)
        {
            var response = this.SumNumbers(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(int Output, TreeNode Input)>()
                {
                     (40,
                    new TreeNode(2, new TreeNode(0), new TreeNode(0))),
                    (25,
                    new TreeNode(1, new TreeNode(2), new TreeNode(3))),
                     (10,
                    new TreeNode(1, new TreeNode(0)))
                };
            }
        }
    }
}
