using LeetCode.SharedUtils;

namespace LeetCode.MediumProblems
{
    class Insert_into_a_Binary_Search_Tree
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            root = Process(root, val);
            return root;
        }

        private TreeNode Process(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }
            else
            {
                if (node.val > value)
                {
                    node.left = Process(node.left, value);
                }
                else
                {
                    node.right = Process(node.right, value);
                }
            }

            return node;
        }

        [Test(Description = "https://leetcode.com/problems/insert-into-a-binary-search-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Insert into a Binary Search Tree")]
        [TestCaseSource("Input")]
        public void Test1((TreeNode Output, (TreeNode, int) Input) item)
        {
            var response = this.InsertIntoBST(item.Input.Item1, item.Input.Item2);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(TreeNode Output, (TreeNode, int) Input)> Input
        {
            get
            {
                return new List<(TreeNode Output, (TreeNode, int) Input)>()
                {
                    (null,
                    (new TreeNode(4,new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7)), 5))
                };
            }
        }
    }
}
