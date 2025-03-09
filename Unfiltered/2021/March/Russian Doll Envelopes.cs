using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2021.March
{
    class Russian_Doll_Envelopes
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            if (envelopes == null || envelopes.Length == 0)
            {
                return 0;
            }
            else
            {
                int[] results = new int[envelopes.Length];

                var recs = envelopes.OrderBy(x => x[0])
                    .ThenBy(x => x[1])
                    .ToArray();

                for (int i = 0; i < results.Length; i++)
                {
                    var env = recs[i];
                    results[i]++;
                    for (int j = i + 1; j < results.Length; j++)
                    {
                        var nxt = recs[j];
                        if (env[0] < nxt[0]
                            && env[1] < nxt[1])
                        {
                            results[j]++;
                        }
                    }
                }

                return results.Max();
            }
        }

        [Test(Description = "https://leetcode.com/problems/russian-doll-envelopes/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Russian Doll Envelopes")]
        [TestCaseSource(nameof(Input))]
        [Ignore("Incomplete implementation")]
        public void Test1((int Output, int[][] Input) item)
        {
            var response = MaxEnvelopes(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[][] Input)> Input
        {
            get
            {
                return new List<(int Output, int[][] Input)>()
                {
                    (4, new int[][]
                    {
                        new int[]{4,5},
                        new int[]{4,6},
                        new int[]{6,7},
                        new int[]{2,3},
                        new int[]{1,1},
                    }),
                    (3, new int[][]
                    {
                        new int[]{5,4},
                        new int[]{6,4},
                        new int[]{6,7},
                        new int[]{2,3},
                    }),
                };
            }
        }
    }
}
