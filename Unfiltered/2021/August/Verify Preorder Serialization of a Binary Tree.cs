using LeetCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace Leetcode.Problems._2021.August
{
    /// <summary>
    /// https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/
    /// </summary>
    class Verify_Preorder_Serialization_of_a_Binary_Tree
    {
        public bool IsValidSerialization(string preorder)
        {
            int count = 1;
            foreach (var item in preorder.Split(','))
            {
                count--;
                //***
                //*** If count is less than 0, pre order string is invalid
                //*** Return false
                //***
                if (count < 0)
                {
                    return false;
                }

                //***
                //*** If the node is a number, increement the count by 2
                //***
                if (item != "#")
                {
                    count += 2;
                }
            }
            //***
            //*** If all nodes are provided in the input
            //*** Count will be 0 after iteration
            //***
            return count == 0;
        }

        [Test(Description = "https://leetcode.com/problems/verify-preorder-serialization-of-a-binary-tree/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Verify Preorder Serialization of a Binary Tree")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, string Input) item)
        {
            var response = IsValidSerialization(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, string Input)> Input
        {
            get
            {
                return new List<(bool Output, string Input)>()
                {
                    (true, "9,3,4,#,#,1,#,#,2,#,6,#,#"),
                };
            }
        }
    }
}
