using LeetCode.SharedUtils;

namespace LeetCode.Problems._2022.January
{
    /// <summary>
    /// https://leetcode.com/problems/all-elements-in-two-binary-search-trees/
    /// </summary>
    public class All_Elements_in_Two_Binary_Search_Trees
    {
        private IList<int> _nums;
        public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            _nums = new List<int>();
            _Helper(root1);
            _Helper(root2);

            return _nums
                .OrderBy(x=>x)
                .ToList();
        }

        private void _Helper(TreeNode node)
        {
            if (node != null)
            {
                _nums.Add(node.val);
                _Helper(node.left);
                _Helper(node.right);
            }
        }
    }
}