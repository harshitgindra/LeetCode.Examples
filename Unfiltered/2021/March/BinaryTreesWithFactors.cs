

namespace LeetCode.March
{
    public class BinaryTreesWithFactors
    {
        public int NumFactoredBinaryTrees(int[] arr)
        {
            long returnValue = 0;
            Dictionary<long, long> dp = new Dictionary<long, long>(arr.Length);
            //***
            //*** Sort the array in ascending order
            //***
            Array.Sort(arr);

            for (var i = 0; i < arr.Length; i++)
            {
                long sum = 0;
                for (var j = 0; j < i; j++)
                {
                    //***
                    //*** Check if remainder will be zero
                    //***
                    if (arr[i] % arr[j] == 0)
                    {
                        var firstNum = arr[j];

                        if (dp.ContainsKey(firstNum))
                        {
                            //***
                            //*** Calculate the divisor and check if it exists in the dp
                            //***
                            var divisor = arr[i] / arr[j];

                            if (dp.ContainsKey(divisor))
                            {
                                //***
                                //*** Get the calculated nodes from dp, multiple those and add to the sum
                                //***
                                sum += dp[firstNum] * dp[divisor];
                            }
                        }
                    }
                }
                //***
                //*** Increment the sum as the num can be used to as a node without children
                //***
                sum++;

                dp.Add(arr[i], sum);
                returnValue += sum;
            }

            return (int)(returnValue % (1000000007));
        }

        [Test(Description = "https://leetcode.com/problems/binary-trees-with-factors/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Binary Trees With Factors")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = NumFactoredBinaryTrees(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {

                    (18, new int[]{ 2,4,5,10, 20}),
                };
            }
        }
    }
}
