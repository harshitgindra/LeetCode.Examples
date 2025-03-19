

namespace LeetCode.HardProblems
{
    class Arithmetic_Slices_II___Subsequence
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            int result = 0;
            //***
            //*** Initialization
            //*** 
            IDictionary<int, IDictionary<long, int>> map = new Dictionary<int, IDictionary<long, int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                map.Add(i, new Dictionary<long, int>());
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var diff = (long)nums[j] - (long)nums[i];
                    int combos = 0;
                    //***
                    //*** Check if the diff exists in the inner pointer
                    //*** 
                    if (map[j].ContainsKey(diff))
                    {
                        combos = map[j][diff];
                    }
                    //**
                    //** Add the combos calculated from inner pointer to the outer pointer and increement by 1
                    //**
                    if (!map[i].ContainsKey(diff))
                    {
                        map[i].Add(diff, 0);
                    }
                    map[i][diff] += combos + 1;

                    result += combos;
                }
            }

            return result;
        }

        [Test(Description = "https://leetcode.com/problems/arithmetic-slices-ii-subsequence/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Arithmetic Slices II - Subsequence")]
        [TestCaseSource(nameof(Input))]
        [Ignore("")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = NumberOfArithmeticSlices(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (16, new int[]{0,2000000000,-294967296}),
                    (16, new int[]{7,7,7,7,7}),
                    (11, new int[]{ 1,1,2,3,4,5}),
                };
            }
        }
    }
}
