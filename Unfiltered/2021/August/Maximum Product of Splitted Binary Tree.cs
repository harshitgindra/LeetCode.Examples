using LeetCode.SharedUtils;


namespace LeetCode.Problems._2021.August
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/
    /// </summary>
    class Maximum_Product_of_Splitted_Binary_Tree
    {
        private long _maximum = 0;

        public int MaxProduct(TreeNode root)
        {
            _maximum = 0;
            //***
            //*** Build a new tree node with sums of sub-trees
            //***
            var newNode = BuildSumTree(root);
            //***
            //*** Calculate the maximum product
            //***
            CalculateMaxProduct(newNode, newNode.val);
            return (int)(_maximum % 1000000007);
        }

        private void CalculateMaxProduct(TreeNode node, int total)
        {
            if (node != null)
            {
                //***
                //*** Calculate the max product
                //*** First num: New node's value
                //*** Second num: Total tree's total - new node's value
                //***
                var num1 = (long)node.val;
                var num2 = total - num1;
                _maximum = Math.Max(num1 * num2, _maximum);
                //***
                //*** Continue the iteration to find maximum product
                //***
                CalculateMaxProduct(node.left, total);
                CalculateMaxProduct(node.right, total);
            }
        }

        private TreeNode? BuildSumTree(TreeNode node)
        {
            //***
            //*** verify if node is not null
            //***
            if (node != null)
            {
                //***
                //*** Initialize a new node to hold sum values of sub trees
                //***
                var newNode = new TreeNode();
                //***
                //*** Continue the iteration through the child trees - left and right
                //***
                newNode.left = BuildSumTree(node.left);
                newNode.right = BuildSumTree(node.right);
                //***
                //*** Update the node value
                //*** Formula: curr node value + new node's left tree total + new node's right tree total
                //***
                newNode.val = node.val
                    + (newNode.left != null ? newNode.left.val : 0)
                    + (newNode.right != null ? newNode.right.val : 0);
                return newNode;
            }
            else
            {
                return default;
            }
        }

        [Test(Description = "https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Maximum Product of Splitted Binary Tree")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, TreeNode Input) item)
        {
            var response = this.MaxProduct(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(int Output, TreeNode Input)>()
                {
                    (110,
                    new TreeNode(1,new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6))))
                };
            }
        }
    }
}
