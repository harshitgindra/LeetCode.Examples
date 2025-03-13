
namespace LeetCode.EasyProblems;

public class AverageLevelsOfBinaryTree
{
    public IList<double> AverageOfLevels(TreeNode root) {
        
        Dictionary<int, Tuple<int, long>> map = new Dictionary<int, Tuple<int, long>>();
        _dfs(root, 0, map);

        IList<double> result = new List<double>();
        foreach (var kvp in map)
        {
            result.Add((double)kvp.Value.Item2 / kvp.Value.Item1);
        }

        return result;
    }

    private void _dfs(TreeNode node, int depth, Dictionary<int, Tuple<int, long>> map)
    {
        if (node != null)
        {
            if (map.ContainsKey(depth))
            {
                var currentVal = map[depth];
                map[depth] = Tuple.Create(currentVal.Item1 + 1, currentVal.Item2 + node.val);
            }
            else
            {
                map[depth] = Tuple.Create(1, (long)node.val);
            }
            _dfs(node.left, depth + 1, map);
            _dfs(node.right, depth + 1, map);
        }
    }
    
    [Test(Description = "https://leetcode.com/problems/average-of-levels-in-binary-tree")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Average Of Levels in Binary Tree")]
    [TestCaseSource(nameof(Input))]
    public void Test1((IList<double> Output, int?[] Input) item)
    {
        var response = AverageOfLevels(item.Input.ToTreeNode());
        Assert.That(response, Is.EqualTo(item.Output));
    }

    public static IEnumerable<(IList<double> Output, int?[] Input)> Input =>
        new List<(IList<double> Output, int?[] Input)>()
        {
            ([3.00000,14.50000,11.00000], [3,9,20,null,null,15,7]),
            ([2147483647.00000,2147483647.00000], [2147483647,2147483647,2147483647]),
        };
}