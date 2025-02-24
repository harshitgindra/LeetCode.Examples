using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    class Valid_Palindrome_II
    {
        public bool ValidPalindrome(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                int sIndex = 0;
                int eIndex = s.Length - 1;
                bool alreadyswitched = false;

                int prevSwitchedStart = 0, prevSwitchedEnd = 0;
                bool redo = false;
                while (sIndex < eIndex)
                {
                    if (s[sIndex] != s[eIndex])
                    {
                        if (alreadyswitched && redo)
                        {
                            return false;
                        }
                        if (alreadyswitched)
                        {
                            if (!redo)
                            {
                                sIndex = prevSwitchedStart;
                                eIndex = prevSwitchedEnd;
                                redo = true;
                                if (s[sIndex] == s[eIndex - 1])
                                {
                                    sIndex++;
                                    eIndex -= 2;
                                    alreadyswitched = true;
                                }
                                else if (s[sIndex + 1] == s[eIndex])
                                {
                                    prevSwitchedStart = sIndex;
                                    prevSwitchedEnd = eIndex;
                                    sIndex = sIndex + 2;
                                    eIndex--;
                                    alreadyswitched = true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!alreadyswitched && s[sIndex + 1] == s[eIndex])
                            {
                                prevSwitchedStart = sIndex;
                                prevSwitchedEnd = eIndex;
                                sIndex = sIndex + 2;
                                eIndex--;
                                alreadyswitched = true;
                            }
                            else if (!alreadyswitched && s[sIndex] == s[eIndex - 1])
                            {
                                prevSwitchedStart = sIndex;
                                prevSwitchedEnd = eIndex;
                                sIndex++;
                                eIndex -= 2;
                                alreadyswitched = true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        sIndex++;
                        eIndex--;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        [Test(Description = "https://leetcode.com/problems/valid-palindrome-ii/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Valid Palindrome II")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, string Input) item)
        {
            var response = ValidPalindrome(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, string Input)> Input
        {
            get
            {
                return new List<(bool Output, string Input)>()
                {
                    (true, "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga"),
                };
            }
        }
    }
}
