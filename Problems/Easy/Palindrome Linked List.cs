using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Easy
{
    class Palindrome_Linked_List
    {
        public bool IsPalindrome(ListNode head)
        {
            return Process(head, new List<int>(), 0).Result;
        }

        private (bool Result, int StartIndex, int EndIndex) Process(ListNode head, List<int> nums, int level)
        {
            if (head == null)
            {
                return (Verify(nums, 0, level - 1), 0, level - 1);
            }
            else
            {
                nums.Add(head.val);
                var (Result, StartIndex, EndIndex) = Process(head.next, nums, level + 1);
                if (Result)
                {
                    return (Verify(nums, StartIndex + 1, EndIndex - 1), StartIndex + 1, EndIndex - 1);
                }
                else
                {
                    return (false, 0, 0);
                }
            }
        }

        private bool Verify(List<int> nums, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
            {
                return true;
            }
            if (nums.Any())
            {
                return nums.ElementAt(startIndex) == nums.ElementAt(endIndex);
            }
            else
            {
                return true;
            }
        }

        [Test(Description = "https://leetcode.com/problems/palindrome-linked-list/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Palindrome Linked List")]
        [TestCaseSource("Input")]
        public void Test1((ListNode Output, ListNode Input) item)
        {
            var response = IsPalindrome(item.Input);
            //Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(ListNode Output, ListNode Input)> Input
        {
            get
            {
                return new List<(ListNode Output, ListNode Input)>()
                {

                    (new ListNode(1, new ListNode(3, new ListNode(2, new ListNode(1)))),
                    new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))))),
                };
            }
        }
    }
}
