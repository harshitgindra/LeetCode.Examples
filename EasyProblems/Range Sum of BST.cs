using LeetCode.SharedUtils;


namespace LeetCode.EasyProblems
{
    class Range_Sum_of_BST
    {
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            return Add(root, low, high, 0);
        }

        public int Add(TreeNode root, int low, int high, int sum)
        {
            if (root != null)
            {
                if (root.val >= low && root.val <= high)
                {
                    sum += root.val;
                }

                sum = Add(root.left, low, high, sum);
                sum = Add(root.right, low, high, sum);
            }

            return sum;
        }


        [Test(Description = "https://leetcode.com/problems/repeated-substring-pattern/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Repeated Substring Pattern")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, TreeNode Input) item)
        {
            var response = RangeSumBST(item.Input, 7, 15);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, TreeNode Input)> Input =>
            new List<(int Output, TreeNode Input)>()
            {
                (32, new TreeNode(10,
                    new TreeNode(5, new TreeNode(3), new TreeNode(7)),
                    new TreeNode(15, new TreeNode(18)))),
            };
    }
}
