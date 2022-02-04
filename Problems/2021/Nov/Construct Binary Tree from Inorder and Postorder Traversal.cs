using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode;
using LeetCode.Easy;
using NUnit.Framework;

namespace Leetcode.Problems._2021.Nov
{
    public class Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            int root = postorder[postorder.Length - 1];
            var returnValue = new TreeNode(root);

            var dict = new Dictionary<int, int>();
            var postOrderList = postorder.ToList();
            foreach (var item in inorder)
            {
                dict.Add(item, postOrderList.IndexOf(item));
            }

            Helper(inorder.ToList(), postOrderList, returnValue, dict);

            return null;
        }

        private void Helper(List<int> inorder, List<int> postorder, TreeNode node,
            Dictionary<int, int> postOrderIndexes)
        {
            if (node != null)
            {
                var inOrderIndexRootNode = inorder.IndexOf(node.val);
                inorder.Remove(node.val);
                postOrderIndexes.Remove(node.val);

                if (inOrderIndexRootNode != 0)
                {
                    int leftNodeIndex = 0;
                    for (int i = 0; i < inOrderIndexRootNode; i++)
                    {
                        leftNodeIndex = Math.Max(leftNodeIndex, postOrderIndexes[inorder[i]]);
                    }

                    node.left = new TreeNode(inorder[leftNodeIndex]);
                }

                if (inOrderIndexRootNode < inorder.Count)
                {
                    int rightNodeIndex = 0;
                    for (int i = inOrderIndexRootNode; i < inorder.Count; i++)
                    {
                        rightNodeIndex = Math.Max(rightNodeIndex, postOrderIndexes[inorder[i]]);
                    }

                    node.right = new TreeNode(postorder[rightNodeIndex]);
                }

                Helper(inorder, postorder, node?.left, postOrderIndexes);
                Helper(inorder, postorder, node?.right, postOrderIndexes);
            }
        }


        [Test(Description =
            "https://leetcode.com/problems/maximum-length-of-a-concatenated-string-with-unique-characters/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Maximum Length of a Concatenated String with Unique Characters")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int[] inorder, int[] postorder) Input) item)
        {
            var response = BuildTree(item.Input.inorder, item.Input.postorder);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int[] inorder, int[] postorder) Input)> Input
        {
            get
            {
                return new List<(int Output, (int[] inorder, int[] postorder) Input)>()
                {
                    (6, (new int[] {9, 3, 15, 20, 7}, new[] {9, 15, 7, 20, 3})),
                };
            }
        }
    }
}