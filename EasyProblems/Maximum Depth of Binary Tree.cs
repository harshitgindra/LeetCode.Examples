using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
{
    class Maximum_Depth_of_Binary_Tree
    {
        public int MaxDepth(TreeNode root)
        {
            int max = Check(root, 0, 0);
            return max;
        }


        private int Check(TreeNode node, int level, int maxLevel)
        {
            if (node == null)
            {
                return Math.Max(level, maxLevel);
            }
            else
            {
                maxLevel = Check(node.left, level + 1, maxLevel);

                maxLevel = Check(node.right, level + 1, maxLevel);

                return maxLevel;
            }
        }
        
        [Test(Description = "https://leetcode.com/problems/maximum-depth-of-binary-tree/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Maximum Depth of Binary Tree")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int?[] Input) item)
        {
            var response = MaxDepth(item.Input.ToTreeNode());
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int?[] Input)> Input =>
            new List<(int Output, int?[] Input)>()
            {

                (3, [3,9,20,null,null,15,7]),
            };
    }
}
