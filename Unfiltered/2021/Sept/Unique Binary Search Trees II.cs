using LeetCode;
using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace Leetcode.Problems._2021.Sept
{
    class Unique_Binary_Search_Trees_II
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
            {
                return new List<TreeNode>();
            }

            return DFS(1, n);
        }

        private IList<TreeNode> DFS(int start, int end)
        {
            //***
            //*** Return list with null if start is greater than end
            //***
            if (start > end)
            {
                return new List<TreeNode>() { null };
            }
            var result = new List<TreeNode>();

            //***
            //*** iterate through all combinations between start and end
            //***
            for (int i = start; i <= end; i++)
            {
                //***
                //*** Building up list of nodes for left and right legs
                //***
                var leftList = DFS(start, i - 1);
                var rightList = DFS(i + 1, end);
                //***
                //*** Iterate through all combinations for right and left legs
                //*** And build up a new Tree Node
                //***
                foreach (var left in leftList)
                {
                    foreach (var right in rightList)
                    {
                        var root = new TreeNode(i);
                        root.left = left;
                        root.right = right;
                        result.Add(root);
                    }
                }
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/unique-binary-search-trees-ii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Unique Binary Search Trees II")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int Input) item)
        {
            var response = GenerateTrees(item.Input);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int Input)> Input
        {
            get
            {
                return new List<(int Output, int Input)>()
                {
                    (1, 4),
                };
            }
        }
    }
}
