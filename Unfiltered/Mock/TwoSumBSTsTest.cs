using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Mock
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum-bsts/
    /// </summary>
    class TwoSumBSTsTest
    {
        public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target)
        {
            //*** Read the first node
            var firstSet = Read(root1, new HashSet<int>());
            //***
            //*** Read and compare the first set with second set
            //***
            return ReadAndCompare(firstSet, target, root2, new HashSet<int>());
        }


        private bool ReadAndCompare(HashSet<int> firstSet, int target, TreeNode node, HashSet<int> nums)
        {
            if (node != null)
            {
                if (firstSet.Contains(target - node.val))
                {
                    return true;
                }
                else
                {
                    nums.Add(node.val);
                }

                if (ReadAndCompare(firstSet, target, node.right, nums))
                {
                    return true;
                }
                else
                {
                    if (ReadAndCompare(firstSet, target, node.left, nums))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private HashSet<int> Read(TreeNode node, HashSet<int> nums)
        {
            if (node != null)
            {
                nums.Add(node.val);
                nums = Read(node.right, nums);
                nums = Read(node.left, nums);
            }
            return nums;
        }
    }
}
