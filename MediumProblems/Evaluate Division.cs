

namespace LeetCode.MediumProblems
{
    class Evaluate_Division
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            IDictionary<string, IDictionary<string, double>> combinations = new Dictionary<string, IDictionary<string, double>>();

            for (int i = 0; i < equations.Count; i++)
            {
                var item = equations[i];

                AddEntry(item[0], item[1], combinations, values[i]);
                AddEntry(item[1], item[0], combinations, 1 / values[i]);
            }

            double[] returnValue = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                returnValue[i] = Dfs(queries[i][0], queries[i][1], combinations);
            }

            return returnValue;
        }

        private double Dfs(string item1, string item2, IDictionary<string, IDictionary<string, double>> combinations)
        {
            if (!combinations.ContainsKey(item1) || !combinations.ContainsKey(item2))
            {
                return -1;
            }
            if (item1 == item2)
            {
                return 1.0;
            }
            else
            {
                double result = -1;
                var items = combinations[item1];

                combinations.Remove(item1);

                foreach (var item in items.Keys)
                {
                    result = Dfs(item, item2, combinations);

                    if (result != -1)
                    {
                        result *= items[item];
                        break;
                    }
                }

                combinations.Add(item1, items);

                return result;
            }
        }

        private void AddEntry(string firstItem, string secondItem, IDictionary<string, IDictionary<string, double>> combinations, double value)
        {
            if (!combinations.ContainsKey(firstItem))
            {
                combinations.Add(firstItem, new Dictionary<string, double>());
            }

            if (!combinations[firstItem].ContainsKey(secondItem))
            {
                combinations[firstItem].Add(secondItem, value);
            }
        }

        [Test(Description = "https://leetcode.com/problems/evaluate-division/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Evaluate Division")]
        [TestCaseSource(nameof(Input))]
        public void Test1((double[] Output, (IList<IList<string>>, double[], IList<IList<string>>) Input) item)
        {
            var response = CalcEquation(item.Input.Item1, item.Input.Item2, item.Input.Item3);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(double[] Output, (IList<IList<string>>, double[], IList<IList<string>>) Input)> Input
        {
            get
            {
                return new List<(double[] Output, (IList<IList<string>>, double[], IList<IList<string>>) Input)>()
                {

                    (new double[]{0.50000,2.00000,-1.00000,-1.00000 }, (new List<IList<string>>{new List<string>{ "a","b"},  }, new double[]{ 0.5},
                    new List<IList<string>>{new List<string>{ "a","b"},
                    new List<string>{ "b","a"},
                    new List<string>{ "a","c"},
                    new List<string>{ "x","x"} }
                    )),

                    (new double[]{3.75000,0.40000,5.00000,0.20000 }, (new List<IList<string>>{new List<string>{ "a","b"}, new List<string> { "b","c"}, new List<string> { "bc","cd"},  }, new double[]{ 1.5,2.5,5.0},
                    new List<IList<string>>{new List<string>{ "a","c"},
                    new List<string>{ "c","b"},
                    new List<string>{ "bc","cd"},
                    new List<string>{ "cd","bc"} }
                    ))
                };
            }
        }
    }
}
