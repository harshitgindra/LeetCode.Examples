using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Easy
{
    class Path_Sum2
    {

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return new List<IList<int>>();
            }
            else
            {
                return Add(new List<IList<int>>(), new List<int>() { root.val }, root, sum);
            }
        }

        private IList<IList<int>> Add(IList<IList<int>> results, IList<int> currentNums,
            TreeNode node, int sum)
        {
            if (node.left == null && node.right == null)
            {
                if (sum == currentNums.Sum())
                {
                    results.Add(currentNums.ToList());
                }
            }
            else
            {
                if (node.left != null)
                {
                    currentNums.Add(node.left.val);
                    results = Add(results, currentNums, node.left, sum);
                    currentNums.RemoveAt(currentNums.Count - 1);
                }

                if (node.right != null)
                {
                    currentNums.Add(node.right.val);
                    results = Add(results, currentNums, node.right, sum);
                    currentNums.RemoveAt(currentNums.Count - 1);
                }
            }

            return results;
        }
    }
}
