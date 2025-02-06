using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Repeated_DNA_Sequences
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            IDictionary<string, int> dict = new Dictionary<string, int>();

            if (s.Length > 10)
            {
                var sample = s.Substring(0, 10);
                dict.Add(sample, 1);

                for (int i = 10; i < s.Length; i++)
                {
                    sample = sample.Remove(0, 1);
                    sample += s[i];

                    if (dict.ContainsKey(sample))
                    {
                        dict[sample]++;
                    }
                    else
                    {
                        dict.Add(sample, 1);
                    }
                }
            }

            return dict.Where(x => x.Value > 1)
                .Select(x => x.Key)
                .ToList();
        }

        [Test(Description = "https://leetcode.com/problems/repeated-dna-sequences/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Repeated DNA Sequences")]
        [TestCaseSource("Input")]
        public void Test1((List<string> Output, string Input) item)
        {
            var response = FindRepeatedDnaSequences(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(List<string> Output, string Input)> Input
        {
            get
            {
                return new List<(List<string> Output, string Input)>()
                {
                    (new List<string>{"AAAAACCCCC","CCCCCAAAAA" },
                    "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"),
                };
            }
        }
    }
}
