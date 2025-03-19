using LeetCode.SharedUtils;

namespace LeetCode.HardProblems
{
    class Reverse_Nodes_in_k_Group
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var nums = Read(head, new List<int>());

            int index = nums.Count;

            ListNode currentNode = default, nextNode;

            for (int i = nums.Count - 1; i >= nums.Count - nums.Count % k; i--)
            {
                nextNode = new ListNode(nums[i], currentNode);
                currentNode = nextNode;
                index--;
            }

            while (index > 0)
            {
                for (int i = index - k; i < index; i++)
                {
                    nextNode = new ListNode(nums[i], currentNode);
                    currentNode = nextNode;
                }

                index = index - k;
            }

            return currentNode;
        }

        private List<int> Read(ListNode node, List<int> nums)
        {
            if (node != null)
            {
                nums.Add(node.val);

                nums = Read(node.next, nums);
            }

            return nums;
        }

        [Test(Description = "https://leetcode.com/problems/reverse-nodes-in-k-group/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Reverse Nodes in k-Group")]
        [TestCaseSource(nameof(Input))]
        [Ignore("")]
        public void Test1((ListNode Output, (ListNode, int) Input) item)
        {
            var response = ReverseKGroup(item.Input.Item1, item.Input.Item2);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(ListNode Output, (ListNode, int) Input)> Input =>
            new List<(ListNode Output, (ListNode, int) Input)>()
            {
                (null, (new ListNode(1, new ListNode(2, new ListNode(3
                    , new ListNode(4, new ListNode(5))))), 2)),
            };
    }
}