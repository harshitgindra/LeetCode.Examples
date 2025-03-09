using LeetCode.SharedUtils;


namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/merge-two-sorted-lists/
    /// </summary>
    class Merge_Two_Sorted_Lists
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var node = Merge(null, l1, l2);
            return node;
        }


        private ListNode Merge(ListNode result, ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {

            }
            else if (l1 == null || l1.val > l2?.val)
            {
                result = new ListNode(l2.val);
                result.next = Merge(result.next, l1, l2.next);
            }
            else if (l2 == null || l1?.val <= l2.val)
            {
                result = new ListNode(l1.val);
                result.next = Merge(result.next, l1.next, l2);
            }

            return result;
        }
        
        [Test(Description = "https://leetcode.com/problems/valid-parentheses/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Valid Parentheses")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, (int[], int[]) Input) item)
        {
            var l1 = ListNodeBuilder.BuildListNode(item.Input.Item1);
            var l2 = ListNodeBuilder.BuildListNode(item.Input.Item2);
            var response = MergeTwoLists(l1, l2);
            Assert.That(item.Output, Is.EqualTo(response.ToArray()));
        }

        public static IEnumerable<(int[] Output, (int[], int[]) Input)> Input =>
            new List<(int[] Output, (int[], int[]) Input)>()
            {
                ([1,1,2,3,4,4], ([1,2,4], [1,3,4])),
            };
    }
}
