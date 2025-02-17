using LeetCode.SharedUtils;

namespace LeetCode.EasyProblems;

public class RemoveDuplicatesFromSortedList
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        if (head != null)
        {
            if (head.val == head.next?.val)
            {
                head = DeleteDuplicates(head.next);
            }
            else
            {
                head.next = DeleteDuplicates(head.next);
            }
        
        }
        
        return head;
    }
    
    [Test(Description = "https://leetcode.com/problems/remove-duplicates-from-sorted-list/")]
    [Category("Easy")]
    [Category("LeetCode")]
    [Category("Remove duplicates fro sorted list")]
    [TestCaseSource("Input")]
    public void Test1((ListNode Output, ListNode Input) item)
    {
        var response = DeleteDuplicates(item.Input);
        //ClassicAssert.AreEqual(item.Output, response);
    }

    public static IEnumerable<(ListNode Output, ListNode Input)> Input
    {
        get
        {
            return new List<(ListNode Output, ListNode Input)>()
            {
                (new ListNode(1, new ListNode(3)),
                    new ListNode(1, new ListNode(1, new ListNode(1, new ListNode(3, new ListNode(3)))))),
                
                (new ListNode(1, new ListNode(2, new ListNode(3))),
                    new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(3)))))),
            };
        }
    }

}