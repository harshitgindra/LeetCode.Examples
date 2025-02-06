using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.Mock.Microsoft
{
    class MockTest1
    {
        /// <summary>
        /// Merge Sorted Array
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var list = nums1.ToList();
            int fNum = list[0];
            int i = 0, j = 0;
            while (i < nums1.Length && j < n)
            {
                if (nums2[j] > fNum && i < m)
                {
                    fNum = nums1[++i];
                }
                else
                {
                    list.Insert(i + j, nums2[j++]);
                }
            }

            for (int k = 0; k < m + n; k++)
            {
                nums1[k] = list[k];
            }
        }


        [Test(Description = "https://leetcode.com/problems/combination-sum/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Mock Test")]
        [Category("Combination Sum")]
        [TestCaseSource("Input")]
        public void Test1((int[] Output, (int[], int, int[], int) Input) item)
        {
            Merge(item.Input.Item1, item.Input.Item2, item.Input.Item3, item.Input.Item4);
            ClassicAssert.AreEqual(item.Output, item.Input.Item1);
        }

        public static IEnumerable<(int[] Output, (int[], int, int[], int) Input)> Input
        {
            get
            {
                return new List<(int[] Output, (int[], int, int[], int) Input)>()
                {

                    (new int[]{ -1,0,0,1,2,2,3,3,3}, (new int[] {-1,0,0,3,3,3,0,0,0},6, new int[]{ 1,2,2}, 3)),
                    (new int[]{ 1,2,2,3,5,6}, (new int[] {1,2,3,0,0,0},3, new int[]{ 2,5,6}, 3)),
                };
            }
        }


        /// <summary>
        /// Inorder Successor in BST
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            SortedDictionary<int, TreeNode> result = new SortedDictionary<int, TreeNode>();
            result = Read(root, result);

            if (result.ContainsKey(p.val) || result.Last().Key != p.val)
            {
                bool found = false;
                foreach (var item in result)
                {
                    if (found)
                    {
                        return item.Value;
                    }
                    else if (item.Key == p.val)
                    {
                        found = true;
                    }
                }
            }
            return null;
        }

        public SortedDictionary<int, TreeNode> Read(TreeNode root, SortedDictionary<int, TreeNode> result)
        {
            if (root != null)
            {
                result = Read(root.left, result);
                result.Add(root.val, root);
                result = Read(root.right, result);
            }
            return result;
        }


        public TreeNode InorderSuccessor2(TreeNode root, TreeNode p)
        {
            if (root != null)
            {
                if (root.left == p)
                {
                    return root;
                }
                else if (root == p)
                {
                    return root.right;
                }
                else
                {
                    var resp = InorderSuccessor(root.left, p);
                    if (resp == null)
                    {
                        resp = InorderSuccessor(root.right, p);
                        if (resp == null)
                        {
                            return null;
                        }
                        else
                        {
                            return resp;
                        }
                    }
                    else
                    {
                        return resp;
                    }
                }
            }
            else
            {
                return null;
            }
        }
    }
}
