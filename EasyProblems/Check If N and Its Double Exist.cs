

namespace LeetCode.EasyProblems
{
    class Check_If_N_and_Its_Double_Exist
    {
        public bool CheckIfExist(int[] arr)
        {
            //Array.Sort(arr);
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var doubleItem = arr[i] * 2;
                var divItem = arr[i] / 2;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == doubleItem || (arr[i] % 2 == 0 && arr[j] == divItem))
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        [Test(Description = "https://leetcode.com/problems/check-if-n-and-its-double-exist/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Check If N and Its Double Exist")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, int[] Input) item)
        {
            var response = CheckIfExist(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(bool Output, int[] Input)> Input
        {
            get
            {
                return new List<(bool Output, int[] Input)>()
                {

                    (true, ( [10,2,5,3])),
                    (false, ( [3,1,7,11])),
                    (false, ( [-2,0,10,-19,4,6,-8])),
                };
            }
        }
    }
}
