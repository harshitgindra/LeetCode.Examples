using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NUnit.Framework;

namespace LeetCode.Hard
{
    public class Cut_Off_Trees_for_Golf_Event
    {
        int x = 0;
        int y = 0;
        int H;
        int W;
        IList<IList<int>> forest;

        Queue<(int x, int y)> queue;

        bool[,] visited;

        bool Valid((int x, int y) p)
        {
            return !(p.x < 0 || p.y < 0 || p.x >= H || p.y >= W);
        }

        void Add((int x, int y) p)
        {
            if (Valid(p) && !visited[p.x, p.y])
            {
                visited[p.x, p.y] = true;
                queue.Enqueue(p);
            }
        }

        int Cutoff(int tree)
        {
            queue = new Queue<(int x, int y)>();
            visited = new bool[H, W];
            Add((x, y));

            int k = 0;

            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int z = 0; z < size; z++)
                {
                    var p = queue.Dequeue();

                    if (forest[p.x][p.y] == tree)
                    {
                        x = p.x;
                        y = p.y;
                        return k;
                    }
                    else if (forest[p.x][p.y] > 0)
                    {
                        Add((p.x, p.y + 1));
                        Add((p.x, p.y - 1));
                        Add((p.x + 1, p.y));
                        Add((p.x - 1, p.y));
                    }
                }

                k++;
            }

            return -1;
        }

        public int CutOffTree(IList<IList<int>> forest)
        {
            var trees = new List<int>();

            H = forest.Count;
            W = forest[0].Count;

            this.forest = forest;

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    var height = forest[i][j];

                    if (height > 1)
                    {
                        trees.Add(height);
                    }
                }
            }

            trees.Sort();

            int dist = 0;

            foreach (var tree in trees)
            {
                var d = Cutoff(tree);
                if (d == -1) return -1;
                dist += d;
            }

            return dist;
        }


        [Test(Description = "https://leetcode.com/problems/cut-off-trees-for-golf-event/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("maximal rectangle")]
        [TestCaseSource("Input")]
        public void Test1((int Output, IList<IList<int>> Input) item)
        {
            var response = CutOffTree(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, IList<IList<int>> Input)> Input
        {
            get
            {
                return new List<(int Output, IList<IList<int>> Input)>()
                {
                    (6, new List<IList<int>>()
                    {
                        new List<int>() {1, 2, 3},
                        new List<int>() {0, 0, 0},
                        new List<int>() {7, 6, 5},
                    }),
                    (6, new List<IList<int>>()
                    {
                        new List<int>() {1, 2, 3},
                        new List<int>() {0, 0, 4},
                        new List<int>() {7, 6, 5},
                    }),
                };
            }
        }
    }
}