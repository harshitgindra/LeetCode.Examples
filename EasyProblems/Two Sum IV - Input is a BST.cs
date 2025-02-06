using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems
{
    //https://leetcode.com/problems/two-sum-iv-input-is-a-bst/submissions/
    class Two_Sum_IV___Input_is_a_BST
    {
        public bool FindTarget(TreeNode root, int k)
        {
            List<int> result = new List<int>();
            Read(result, root);

            for (int i = 0; i < result.Count - 1; i++)
            {
                var diff = k - result[i];
                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[j] == diff)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void Read(List<int> nums, TreeNode node)
        {
            if (node != null)
            {
                nums.Add(node.val);
                Read(nums, node.left);
                Read(nums, node.right);
            }
        }
    }

    class Two_Sum_IV___Input_is_a_BST_2
    {
        public bool FindTarget(TreeNode root, int k)
        {
            bool returnValue = Read(new HashSet<int>(), root, k);
            return returnValue;
        }

        private bool Read(HashSet<int> nums, TreeNode node, int k)
        {
            if (node != null)
            {
                if (nums.Contains(k - node.val))
                {
                    return true;
                }
                else
                {
                    nums.Add(node.val);
                    if (Read(nums, node.left, k))
                    {
                        return true;
                    }
                    if (Read(nums, node.right, k))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
