using LeetCode.SharedUtils;



namespace LeetCode.EasyProblems
{
    class Intersection_of_Two_Linked_Lists
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
            ListNode a = headA;
            ListNode b = headB;
        
            // continue until a and b are equal.
            while(a != b)
            {
                // If one reaches end first then move a|b to the head of b|a
                // This handles case if both have different lengths. No need to
                // count length of A and B. If there is no overlap both A and B ends with null.
                a = a != null? a.next:headB;
                b = b != null? b.next:headA;
            }
        
            return a;
        }

        [Test(Description = "https://leetcode.com/problems/intersection-of-two-linked-lists/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Intersection of Two Linked Lists")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, (int[], int[]) Input) item)
        {
            var inputListNode1 = ListNodeBuilder.BuildListNode(item.Input.Item1);
            var inputListNode2 = ListNodeBuilder.BuildListNode(item.Input.Item2);
            var response = GetIntersectionNode(inputListNode1, inputListNode2);
            ListNodeBuilder.AssertListNode(response, item.Output);
        }

        public static IEnumerable<(int[] Output, (int[], int[]) Input)> Input
        {
            get
            {
                return new List<(int[] Output, (int[], int[]) Input)>()
                {
                    (new int[]{2,4}, (new int[]{4,1,8,4,5}, new int[] {5,6,1,8,4,5})),
                };
            }
        }
    }
}
