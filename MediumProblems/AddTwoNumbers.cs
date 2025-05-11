namespace LeetCode.MediumProblems;

public class AddTwoNumbersSolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var node = DfsTraversal(l1, l2, 0);
        return node;
    }

    private ListNode DfsTraversal(ListNode l1, ListNode l2, int carry)
    {
        int sum = carry;
        if (l1 == null && l2 == null)
        {
            if (sum != 0)
            {
                return new ListNode(1);
            }
            else
            {
                return null;
            }
        }

        if (l1 != null)
        {
            sum += l1.val;
        }

        if (l2 != null)
        {
            sum += l2.val;
        }

        var node = new ListNode(sum % 10);
        node.next = DfsTraversal(l1?.next, l2?.next, sum / 10);
        return node;
    }

    [Test(Description = "https://leetcode.com/problems/add-two-numbers/")]
    [Category("Medium")]
    [Category("LeetCode")]
    [Category("Add Two Numbers")]
    [TestCaseSource(nameof(Input))]
    public void Test1((int[] Output, (int[], int[]) Input) item)
    {
        var response = AddTwoNumbers(item.Input.Item1.ToListNode(), item.Input.Item2.ToListNode());
        Assert.That(item.Output, Is.EqualTo(response.ToArray()));
    }

    public static IEnumerable<(int[] Output, (int[], int[]) Input)> Input =>
        new List<(int[] Output, (int[], int[]) Input)>()
        {
            ([7, 0, 8], ([2, 4, 3], [5, 6, 4])),
        };
}