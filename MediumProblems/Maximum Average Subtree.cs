using LeetCode.SharedUtils;

namespace LeetCode.MediumProblems
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-average-subtree/
    /// </summary>
    public class Maximum_Average_Subtree
    {
        public double MaximumAverageSubtree(TreeNode root)
        {
            var response = Check(root);
            return response.Average;
        }

        private (int Total, double Count, double Average) Check(TreeNode node)
        {
            if (node != null)
            {
                var responseLeft = Check(node.left);
                var responseRight = Check(node.right);
                
                //***
                //*** Calc average
                //***
                var newTotal = (responseLeft.Total + responseRight.Total + node.val);
                var newCount = (responseLeft.Count + responseRight.Count + 1.0);
                var newAvg = Math.Max(Math.Max(responseLeft.Average, responseRight.Average), newTotal /newCount);

                return (newTotal, newCount, newAvg);
            }
            else
            {
                return (0, 0.0, 0.0);
            }
        }
    }
}