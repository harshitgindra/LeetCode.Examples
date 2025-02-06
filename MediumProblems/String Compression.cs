using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class String_Compression
    {
        public int Compress(char[] chars)
        {

            string s = "";
            if (chars != null && chars.Length > 0)
            {

                char prev = default;
                int count = 0;

                for (int i = 0; i < chars.Length; i++)
                {

                    if (chars[i] == prev)
                    {
                        count++;
                    }
                    else
                    {
                        if (prev != default)
                        {
                            s += prev;

                            if (count > 1)
                            {
                                s += count;
                            }
                        }
                        prev = chars[i];
                        count = 1;
                    }

                }

                s += prev;

                if (count > 1)
                {
                    s += count;
                }
                for (int i = 0; i < s.Length; i++)
                {
                    chars[i] = s[i];
                }
                return s.Length;
            }
            else
            {
                return 0;
            }
        }


        [Test(Description = "https://leetcode.com/problems/string-compression/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("String Compression")]
        [TestCaseSource("Input")]
        public void Test1((int Output, char[] Input) item)
        {
            var response = Compress(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, char[] Input)> Input
        {
            get
            {
                return new List<(int Output, char[] Input)>()
                {

                    (6, (new char[] {'a','a','b','b','c','c','c'})),
                };
            }
        }
    }
}
