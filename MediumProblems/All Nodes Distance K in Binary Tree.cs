using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    public class All_Nodes_Distance_K_in_Binary_Tree
    {
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            List<int> response = new List<int>();

            if (root != null)
            {
                var result = ReadLeft(root.left, -1, new Dictionary<int, List<int>>());
                result = ReadRight(root.left, 1, result);
                result.Add(0, new List<int>() { root.val });

                var entry = result.FirstOrDefault(x => x.Value.Contains(target.val));

                foreach (var item in result
                             .Where(x => x.Key == entry.Key + K || x.Key == entry.Key - K))
                {
                    response.AddRange(item.Value);
                }
            }

            return response;
        }

        private Dictionary<int, List<int>> ReadLeft(TreeNode node, int level, Dictionary<int, List<int>> result)
        {
            if (node != null)
            {
                if (result.ContainsKey(level))
                {
                    result[level].Add(node.val);
                }
                else
                {
                    result.Add(level, new List<int>() { node.val });
                }

                result = ReadLeft(node.left, level - 1, result);
                result = ReadLeft(node.right, level - 1, result);
            }

            return result;
        }

        private Dictionary<int, List<int>> ReadRight(TreeNode node, int level, Dictionary<int, List<int>> result)
        {
            if (node != null)
            {
                if (result.ContainsKey(level))
                {
                    result[level].Add(node.val);
                }
                else
                {
                    result.Add(level, new List<int>() { node.val });
                }

                result = ReadRight(node.left, level + 1, result);
                result = ReadRight(node.right, level + 1, result);
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/all-nodes-distance-k-in-binary-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("All Nodes Distance K in Binary Tree")]
        [TestCaseSource(nameof(Input))]
        public void Test1((List<int> Output, (int?[], int?[], int) Input) item)
        {
            var response = DistanceK(item.Input.Item1.ToTreeNode(),
                item.Input.Item2.ToTreeNode(),
                item.Input.Item3);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(List<int> Output, (int?[], int?[], int) Input)> Input =>
            new List<(List<int> Output, (int?[], int?[], int) Input)>()
            {
                ([7,4,1], ([3,5,1,6,2,0,8,null,null,7,4], [5], 2))
            };
    }
}