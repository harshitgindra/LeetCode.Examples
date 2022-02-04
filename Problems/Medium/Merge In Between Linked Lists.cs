using System.Collections.Generic;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class Merge_In_Between_Linked_Lists
    {
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            var endNode = End(list1, b);
            list2 = MapEnd(list2, endNode);

            list1 = Start(list1, a, list2);
            return list1;
        }

        private ListNode Start(ListNode list1, int a, ListNode list2)
        {
            if (list1 != null)
            {
                if (list1.val == a)
                {
                    list1 = list2;
                }
                else
                {
                    list1.next = Start(list1.next, a, list2);
                }
            }

            return list1;
        }

        private ListNode MapEnd(ListNode list2, ListNode end)
        {
            if (list2 == null)
            {
                return end;
            }
            else
            {
                list2.next = MapEnd(list2.next, end);
            }

            return list2;
        }

        private ListNode End(ListNode list1, int b)
        {
            if (list1 != null)
            {
                if (list1.val == b)
                {
                    return list1.next;
                }
                else
                {
                    return End(list1.next, b);
                }
            }

            return list1;
        }

        [Test(Description = "https://leetcode.com/problems/meeting-scheduler/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Meeting Scheduler")]
        [TestCaseSource("Input")]
        public void Test1((List<int> Output, (ListNode list1, int a, int b, ListNode list2) Input) item)
        {
            var response = MergeInBetween(item.Input.list1, item.Input.a, item.Input.b, item.Input.list2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(List<int> Output, (ListNode list1, int a, int b, ListNode list2) Input)> Input
        {
            get
            {
                return new List<(List<int> Output, (ListNode list1, int a, int b, ListNode list2) Input)>()
                {
                    (null, (
                        new ListNode(0,
                            new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))))),
                        3, 4, new ListNode(100, new ListNode(101, new ListNode(102)))))
                };
            }
        }
    }
}