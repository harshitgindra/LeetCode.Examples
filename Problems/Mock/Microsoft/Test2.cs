using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Mock.Microsoft
{
    class MockTest2
    {
        /// <summary>
        /// Flipping an image
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                var item = A[i];
                int endIndex = item.Length - 1;
                int j = 0;
                while (endIndex >= j)
                {
                    var fElement = item[j];
                    item[j++] = 1 - item[endIndex];
                    item[endIndex--] = 1 - fElement;
                }
            }

            return A;
        }


        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource("Input")]
        public void Test1((int[][] Output, int[][] Input) item)
        {
            var response = FlipAndInvertImage(item.Input);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int[][] Output, int[][] Input)> Input
        {
            get
            {
                return new List<(int[][] Output, int[][] Input)>()
                {
                     (null, new int[][]{
                        new int[]{1,1,0,0 },
                        new int[]{1,0,0,1 },
                        new int[]{0,1,1,1 },
                        new int[]{1,0,1,0 },
                    }),

                    (null, new int[][]{
                        new int[]{1,1,0 },
                        new int[]{1,0,1 },
                        new int[]{0,0,0 },
                    }),
                };
            }
        }

        /// <summary>
        /// Leaf-Similar Trees
        /// </summary>
        /// <param name="root1"></param>
        /// <param name="root2"></param>
        /// <returns></returns>
        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            List<int> list1 = Read(root1, new List<int>());
            List<int> list2 = Read(root2, new List<int>());

            if (list1.Count == list2.Count)
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i] != list2[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            return false;
        }

        private List<int> Read(TreeNode node, List<int> result)
        {
            if (node != null)
            {
                if (node.left == null && node.right == null)
                {
                    result.Add(node.val);
                }
                else
                {
                    result = Read(node.left, result);
                    result = Read(node.right, result);
                }
            }
            return result;
        }
    }
}
