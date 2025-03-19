

namespace LeetCode.MediumProblems
{
    class Flip_String_to_Monotone_Increasing
    {
        public int MinFlipsMonoIncr(string S)
        {
            return 0;
        }


        [Test(Description = "https://leetcode.com/problems/flip-string-to-monotone-increasing/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Flip String to Monotone Increasing")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, string Input) item)
        {
            var response = MinFlipsMonoIncr(item.Input);
            // Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(int Output, string Input)> Input
        {
            get
            {
                return new List<(int Output, string Input)>()
                {

                    (1,"00110"),
                };
            }
        }
    }
}
