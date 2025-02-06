using NUnit.Framework.Legacy;

namespace LeetCode.Contest
{
    public class Minimum_Deletions_to_Make_Character_Frequencies_Unique
    {
        public int MinDeletions(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            var arry = s.ToLower().ToCharArray();
            
            Array.Sort(arry);
            
            List<int> entries = new List<int>();

            var char1 = arry[0];
            int count = 1;
            for (int i = 1; i < arry.Length; i++)
            {

                if (arry[i] == char1)
                {
                    count++;
                }
                else
                {
                    entries.Add(count);
                    char1 = arry[i];
                    count = 1;
                }
            }
            
            entries.Add(count);

            int ret = 0;

            if (entries.Count == entries.ToHashSet().Count)
            {
                return 0;
            }
            else
            {
                var ary = entries.OrderByDescending(x => x).ToList();

                for(int i = 0; i< ary.Count; i++)
                {
                    var t = ary[i];
                    ary.RemoveAt(i);

                    while (t>=0)
                    {
                        if (t > 0 && ary.Contains(t))
                        {
                            
                            t--;
                            ret++;
                        }
                        else
                        {
                                ary.Insert(i, t);
                            break;
                        }
                    }
                }
            }

            return ret;

        }
        
        [Test(Description = "https://leetcode.com/problems/binary-watch/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Binary Watch")]
        [TestCaseSource("Input")]
        public void Test1((int Output, string Input) item)
        {
            var response = MinDeletions(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {

                    (2, "adec"),
                };
            }
        }
    }
}