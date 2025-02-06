using LeetCode.SharedUtils;

namespace LeetCode.MediumProblems
{
    public class Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            TreeNode root = new TreeNode(postorder[postorder.Length - 1]);
            root.left = BuildLeft(root.left, inorder[0], inorder.ToList(), postorder.ToList(), root.val);
            root.right = BuildRight(root.right, root.val, inorder.ToList(), postorder.ToList(), root.val);

            return root;
        }

        private TreeNode BuildLeft(TreeNode node, int nodeValue, List<int> inorder, List<int> postorder, int rootNode)
        {
            var start = inorder.IndexOf(nodeValue);
            var end = inorder.IndexOf(rootNode);

            List<int> leftValues = new List<int>();
            for (int i = start; i < end; i++)
            {
                leftValues.Add(inorder[i]);
            }

            if (leftValues.Any())
            {
                int? leftnode = null;
                for (int i = postorder.Count - 1; i >= 0; i--)
                {
                    if (leftValues.Contains(postorder[i]))
                    {
                        leftnode = postorder[i];
                        break;
                    }
                }

                if (leftnode.HasValue)
                {
                    node = new TreeNode(leftnode.Value);
                    //node.left = BuildLeft(node.left, leftnode.Value, inorder, postorder, rootNode);

                    node.right = BuildRight(node.right, leftnode.Value, inorder, postorder, rootNode);
                }
            }

            return node;
        }

        private TreeNode BuildRight(TreeNode node, int nodeValue, List<int> inorder, List<int> postorder, int rootvalue)
        {
            var start = inorder.IndexOf(nodeValue);

            List<int> rightValues = new List<int>();
            for (int i = start + 1; i < inorder.Count; i++)
            {
                rightValues.Add(inorder[i]);
            }

            if (rightValues.Any())
            {
                int? rightNode = null;
                for (int i = postorder.Count - 1; i >= 0; i--)
                {
                    if (rightValues.Contains(postorder[i]))
                    {
                        rightNode = postorder[i];
                        break;
                    }
                }

                if (rightNode.HasValue)
                {
                    node = new TreeNode(rightNode.Value);
                    node.left = BuildLeft(node.left, rightNode.Value, inorder, postorder, rootvalue);
                }
            }

            return node;
        }

        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Combination Sum")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[], int[]) Input) item)
        {
            var response = BuildTree(item.Input.Item1, item.Input.Item2);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[], int[]) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[], int[]) Input)>()
                {
                    (0, (new int[] {9, 3, 15, 20, 7}, new int[] {9, 15, 7, 20, 3})),
                };
            }
        }
    }
}