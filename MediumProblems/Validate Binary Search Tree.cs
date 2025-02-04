using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Legacy;

namespace LeetCode.Medium
{
    class Validate_Binary_Search_Tree
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            else
            {
                if (root.left != null)
                {
                    if (root.val <= root.left.val)
                    {
                        return false;
                    }
                    else
                    {
                        if (!IsValidBST(root.left))
                        {
                            return false;
                        }
                    }
                }

                if (root.right != null)
                {
                    if (root.val >= root.right.val)
                    {
                        return false;
                    }
                    else
                    {
                        if (!IsValidBST(root.right))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        [Test(Description = "https://leetcode.com/problems/validate-binary-search-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Validate Binary Search Tree")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, TreeNode Input) item)
        {
            var response = this.IsValidBST(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, TreeNode Input)> Input
        {
            get
            {
                return new List<(bool Output, TreeNode Input)>()
                {
                    (true, new TreeNode(2, new TreeNode(1), new TreeNode(3)))
                };
            }
        }
    }
}
