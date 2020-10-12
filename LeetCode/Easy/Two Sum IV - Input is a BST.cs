using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
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
}
