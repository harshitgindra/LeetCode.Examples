using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Medium
{
    public class Lowest_Common_Ancestor_of_a_Binary_Tree_IV
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes)
        {
            var result = Read(root, new List<int>(), new List<List<int>>());

            var filteredResult = new List<List<int>>();

            foreach (var node in nodes)
            {
                
            }

            return null;
        }

        private List<List<int>> Read(TreeNode node, List<int> entry, List<List<int>> result)
        {
            if (node != null)
            {
                entry.Add(node.val);

                result = Read(node.left, entry, result);
                result = Read(node.right, entry, result);
            }
            else
            {
                result.Add(entry.ToList());
            }

            return result;
        }
    }
}