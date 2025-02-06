using NUnit.Framework.Legacy;

namespace LeetCode.EasyProblems
{
    /// <summary>
    /// https://leetcode.com/problems/unique-number-of-occurrences/
    /// </summary>
    public class Unique_Number_of_Occurrences
    {
        public bool UniqueOccurrences(int[] arr)
        {
            bool[] counts = new bool[1000];
            var dict = new Dictionary<int, int>();
            foreach (var item in arr)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }

                dict[item]++;
            }

            foreach (var item in dict)
            {
                if (counts[item.Value])
                {
                    return false;
                }

                counts[item.Value] = true;
            }

            return true;
        }

        [Test(Description = "https://leetcode.com/problems/unique-number-of-occurrences/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Unique Number of Occurrences")]
        [TestCaseSource("Input")]
        public void Test1((bool Output, int[] Input) item)
        {
            var response = UniqueOccurrences(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, int[] Input)> Input
        {
            get
            {
                return new List<(bool Output, int[] Input)>()
                {
                    (true, new int[] {1, 2, 2, 1, 1, 3}),
                    (true, new int[] {-3,0,1,-3,1,1,1,-3,10,0}),
                    (false, new int[] {1,2}),
                };
            }
        }
    }
}