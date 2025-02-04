﻿using System;
using System.Collections.Generic;
using System.Text;
using SharedUtils;

namespace LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/submissions/
    /// </summary>
    class Convert_Binary_Number_in_a_Linked_List_to_Integer
    {
        public int GetDecimalValue(ListNode head)
        {
            string key = Read(head, "");

            return Convert.ToInt32(key, 2);
        }

        private string Read(ListNode node, string key)
        {
            if (node != null)
            {
                return Read(node.next, $"{key}{node.val}");
            }
            return key;
        }
    }
}
