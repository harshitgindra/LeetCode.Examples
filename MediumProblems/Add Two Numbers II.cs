using LeetCode.SharedUtils;
using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Add_Two_Numbers_II
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var l1Values = Read(l1, new List<int>());
            var l2Values = Read(l2, new List<int>());

            int maxLength = Math.Max(l1Values.Count, l2Values.Count);

            while (l1Values.Count < maxLength)
            {
                l1Values.Insert(0, 0);
            }

            while (l2Values.Count < maxLength)
            {
                l2Values.Insert(0, 0);
            }

            ListNode currNode = default, prevNode = default;
            int cof = 0;
            for (int i = maxLength - 1; i >= 0; i--)
            {
                int currSum = l1Values[i] + l2Values[i] + cof;
                if (currSum > 9)
                {
                    cof = 1;
                    currSum = currSum % 10;
                }
                else
                {
                    cof = 0;
                }

                prevNode = currNode;
                currNode = new ListNode(currSum, prevNode);
            }

            if (cof == 1)
            {
                prevNode = currNode;
                currNode = new ListNode(1, prevNode);
            }

            return currNode;
        }

        private List<int> Read(ListNode node, List<int> val)
        {
            if (node != null)
            {
                val.Add(node.val);
                val = Read(node.next, val);
            }
            return val;
        }

        [Test(Description = "https://leetcode.com/problems/add-two-numbers-ii/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Add Two Numbers II")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, (ListNode, ListNode) Input) item)
        {
            var response = AddTwoNumbers(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, (ListNode, ListNode) Input)> Input
        {
            get
            {
                return new List<(ListNode Output, (ListNode, ListNode) Input)>()
                {
                    (new ListNode(7, new ListNode(8, new ListNode(0, new ListNode(7)))),

                    (new ListNode(7, new ListNode(2, new ListNode(4, new ListNode(3)))),
                    new ListNode(5, new ListNode(6, new ListNode(4))))
                    )
                };
            }
        }
    }
}
