using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace LeetCode.Medium
{
    public class Camelcase_Matching
    {
        public IList<bool> CamelMatch(string[] queries, string pattern)
        {
            IList<bool> result = new List<bool>();

            List<string> patterns = new List<string>();
            string v = "";
            int numOfUpperCases = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                if (char.IsUpper(pattern[i]) && !string.IsNullOrEmpty(v))
                {
                    patterns.Add(v);
                    v = $"{pattern[i]}";
                    numOfUpperCases++;
                }
                else
                {
                    v = $"{v}{pattern[i]}";
                }
            }
            patterns.Add(v);

            foreach (var item in queries)
            {
                //***
                //*** compare the numbr of upper cases
                //***
                bool found = true;
                foreach (var i in patterns)
                {
                    if (!item.Contains(i))
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    found = item.Count(x => char.IsUpper(x)) == numOfUpperCases;
                }
                
                result.Add(found);
            }

            return result;
        }
        
        [Test(Description = "https://leetcode.com/problems/car-pooling/")]
        [Category("Medium")]
        [Category("Leetcode")]
        [Category("Car Pooling")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, (string[], string) Input) item)
        {
            var response = CamelMatch(item.Input.Item1, item.Input.Item2);
            Assert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, (string[], string) Input)> Input
        {
            get
            {
                return new List<(bool Output, (string[], string) Input)>()
                {

                    (false, (new string[]{"CompetitiveProgramming","CounterPick","ControlPanel"}, "CooP")),
                };
            }
        }
    }
}