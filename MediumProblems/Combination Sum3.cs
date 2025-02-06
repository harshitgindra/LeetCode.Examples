namespace LeetCode.MediumProblems
{
    public class Combination_Sum3
    {
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> comb = new List<int>(k);
            result = CombinationSum3(k, n, 1, comb, result);
            return result;
        }

        private List<IList<int>> CombinationSum3(int k, int n, int start, List<int> comb, List<IList<int>> result)
        {
            if (k == 0 && n == 0)
            {
                result.Add(comb.ToArray());
            }
            else if (k > 0 && n > 0)
            {
                for (int i = start; i <= 9; i++)
                {
                    comb.Add(i);
                    result = CombinationSum3(k - 1, n - i, i + 1, comb, result);
                    comb.Remove(i);
                }
            }

            return result;
        }



        [Test(Description = "https://leetcode.com/problems/combination-sum-iii/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Combination Sum III")]
        [TestCaseSource("Input")]
        public void Test1((int Output, (int, int) Input) item)
        {
            var response = CombinationSum3(item.Input.Item1, item.Input.Item2);
            //ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, (int, int) Input)> Input
        {
            get
            {
                return new List<(int Output, (int, int) Input)>()
                {
                    (1, (3,7)),
                    (6, (3, 9)),
                };
            }
        }
    }
}
