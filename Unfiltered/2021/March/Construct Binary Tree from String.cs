using LeetCode.SharedUtils;

namespace LeetCode.Problems._2021.March
{
    class Construct_Binary_Tree_from_String
    {
        public TreeNode Str2tree(string s)
        {
            var response = _Build(s, 0);
            return response.Node;
        }

        private (TreeNode Node, int Index) _Build(string s, int index)
        {
            int i = index;
            string str = "";
            while (i < s.Length)
            {
                var letter = s[i];
                switch (letter)
                {
                    case '(':
                        //***
                        //*** Opening parentheses means a new node needs to be built
                        //***
                        if (!string.IsNullOrEmpty(str))
                        {
                            //***
                            //*** We start with building the primary node based on 
                            //*** previous saved number
                            //***
                            var node = new TreeNode(Convert.ToInt32(str));
                            //***
                            //*** Now we get it's left node
                            //***
                            var response = _Build(s, i + 1);
                            node.left = response.Node;

                            //***
                            //*** Based on where the left node ends, we increment the index
                            //*** and fetch the right node
                            //***
                            response = _Build(s, response.Index + 1);
                            node.right = response.Node;

                            if (node.right != null)
                            {
                                response.Index++;
                            }
                            return (node, response.Index);
                        }
                        break;
                    case ')':
                        if (!string.IsNullOrEmpty(str))
                        {
                            //***
                            //*** Closing parentheses means that the node is complete
                            //*** Build the node and return it
                            //***
                            return (new TreeNode(Convert.ToInt32(str)), i);
                        }
                        else
                        {
                            return (default, i);
                        }
                    default:
                        //***
                        //*** Build the number(including negative signs)
                        //***
                        str += letter;
                        break;
                }
                i++;
            }

            if (!string.IsNullOrEmpty(str))
            {
                return (new TreeNode(Convert.ToInt32(str)), i);
            }
            else
            {
                return (default, i);
            }
        }

        [Test(Description = "https://leetcode.com/problems/construct-binary-tree-from-string/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Construct Binary Tree from String")]
        [TestCaseSource(nameof(Input))]
        public void Test1((TreeNode Output, string Input) item)
        {
            var response = Str2tree(item.Input);
        }

        public static IEnumerable<(TreeNode Output, string Input)> Input
        {
            get
            {
                return new List<(TreeNode Output, string Input)>()
                {
                    (default, "1(2(3(4(5(6(7(8)))))))(9(10(11(12(13(14(15)))))))"),
                    //(default, "1(2(3(4(5(6(7(8)))))))"),
                    //(default, "4"),
                    //(default, "4(2(3))(6(5)(7))"),
                    (default, "4(2(3)(1))(6(5))"),
                };
            }
        }

    }
}
