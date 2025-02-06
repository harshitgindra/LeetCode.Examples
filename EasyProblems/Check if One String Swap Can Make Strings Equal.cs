using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Check_if_One_String_Swap_Can_Make_Strings_Equal
    {
        public bool AreAlmostEqual(string s1, string s2)
        {
            bool returnValue = false;

            int diff = 0;
            char s1c = default;
            char s2c = default;

            for (int i = 0; i < s1.Length; i++)
            {
                //***
                //*** Check if characters are not same
                //***
                if (s1[i] != s2[i])
                {
                    diff++;
                    if (diff == 1)
                    {
                        //***
                        //*** Save the characters to the variable
                        //***
                        s1c = s1[i];
                        s2c = s2[i];
                    }
                    else if (diff == 2)
                    {
                        //***
                        //*** Compare the characters with the old saved characters
                        //***
                        if (s1c == s2[i] && s2c == s1[i])
                        {
                            returnValue = true;
                        }
                        else
                        {
                            returnValue = false;
                            break;
                        }
                    }
                    else
                    {
                        //***
                        //*** Difference is greater than 2; break the loop and return false
                        //***
                        returnValue = false;
                        break;
                    }
                }
            }

            if (diff == 0)
            {
                returnValue = true;
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Check if One String Swap Can Make Strings Equal")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (string, string) Input) item)
        {
            var response = AreAlmostEqual(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (string, string) Input)> Input
        {
            get
            {
                return new List<(bool Output, (string, string) Input)>()
                {
                    (false, ("attack", "defend")),
                    (true, ("bank", "kanb")),
                };
            }
        }
    }
}
