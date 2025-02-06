using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
{
    class Search_in_a_Binary_Search_Tree
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return default;
            }

            if (root.val == val)
            {
                return root;
            }

            var response = SearchBST(root.left, val);
            if (response == null)
            {
                response = SearchBST(root.right, val);
            }

            return response;
        }

    }
}
