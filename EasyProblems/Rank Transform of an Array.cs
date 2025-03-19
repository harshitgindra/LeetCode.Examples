

namespace LeetCode.EasyProblems
{
    class Rank_Transform_of_an_Array
    {

        public int[] ArrayRankTransform(int[] arr)
        {
            var sortedArr = arr.Distinct().ToArray();
            Array.Sort(sortedArr);

            int i = 1;
            var hashset = sortedArr.ToDictionary(x => x, y => i++);

            int[] returnvalue = new int[arr.Length];

            for (int j = 0; j < arr.Length; j++)
            {
                returnvalue[j] = hashset[arr[j]];
            }
            return returnvalue;
        }


        [Test(Description = "https://leetcode.com/problems/rank-transform-of-an-array/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Rank Transform of an Array")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int[] Output, int[] Input) item)
        {
            var response = ArrayRankTransform(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int[] Output, int[] Input)> Input =>
            new List<(int[] Output, int[] Input)>()
            {

                ([4,1,2,3], [40,10,20,30]),
                ([1,1,1], [100,100,100]),
                ([5,3,4,2,8,6,7,1,3], [37,12,28,9,100,56,80,5,12])
            };
    }
}
