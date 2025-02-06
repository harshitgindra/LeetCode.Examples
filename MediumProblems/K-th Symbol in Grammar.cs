using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class K_th_Symbol_in_Grammar
    {
        public int KthGrammar(int N, int K)
        {
            if (N == 1)
                return 0;
            if (N == 2 && K == 1)
                return 0;
            if (N == 2 && K == 2)
                return 1;

            if (K % 2 == 0)
                return KthGrammar(N - 1, K / 2) == 0 ? 1 : 0;
            else
                return KthGrammar(N - 1, (K + 1) / 2) == 0 ? 0 : 1;
        }

        [Test(Description = "https://leetcode.com/problems/k-th-symbol-in-grammar/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("K-th Symbol in Grammar")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int, int) Input) item)
        {
            var response = this.KthGrammar(item.Input.Item1, item.Input.Item2);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int, int) Input)>()
                {

                    (1, (4,5)),
                };
            }
        }
    }
}
