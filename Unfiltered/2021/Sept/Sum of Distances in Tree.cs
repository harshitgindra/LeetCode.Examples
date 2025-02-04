using NUnit.Framework;
using System.Collections.Generic;
using NUnit.Framework.Legacy;

namespace Leetcode.Problems._2021.Sept
{
    /// <summary>
    /// https://leetcode.com/problems/sum-of-distances-in-tree/
    /// </summary>
    class Sum_of_Distances_in_Tree
    {
        private int[] nodeCount;
        private int[] returnValue;
        private List<HashSet<int>> graph;

        public int[] SumOfDistancesInTree(int n, int[][] edges)
        {
            nodeCount = new int[n];
            returnValue = new int[n];
            graph = new List<HashSet<int>>();

            for (int i = 0; i < n; i++)
            {
                graph.Add(new HashSet<int>());
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            SubnodeIteration(0, -1);
            ParentNodeIteration(0, -1);

            return returnValue;
        }

        private void SubnodeIteration(int root, int prev)
        {
            foreach (var node in graph[root])
            {
               //***
               //*** Reading through all the subnodes 
               //***
                if (node != prev)
                {
                    SubnodeIteration(node, root);
                    nodeCount[root] += nodeCount[node];
                    returnValue[root] += returnValue[node] + nodeCount[node];
                }
            }
            nodeCount[root]++;
        }

        private void ParentNodeIteration(int root, int prev)
        {
            foreach (var node in graph[root])
            {
                if (node != prev)
                {
                    returnValue[node] = returnValue[root] - nodeCount[node] + nodeCount.Length - nodeCount[node];
                    ParentNodeIteration(node, root);
                }
            }
        }

        [Test(Description = "https://leetcode.com/problems/sum-of-distances-in-tree/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Sum of Distances in Tree")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int, int[][]) Input) item)
        {
            var response = SumOfDistancesInTree(item.Input.Item1, item.Input.Item2);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int[][]) Input)> Input
        {
            get
            {
                return new List<(int Output, (int, int[][]) Input)>()
                {
                      (1, (3,new int[][]{
                            new int[]{2,0 },
                        new int[]{1,0 }})),

                    (1, (6,new int[][]{
                        new int[]{0,1 },
                        new int[]{0,2 },
                        new int[]{2,3 },
                        new int[]{2,4 },
                        new int[]{2,5 }})),

                    (1, (2,new int[][]{
                        new int[]{1,0 }})),
                };
            }
        }
    }
}
