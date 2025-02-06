using NUnit.Framework.Legacy;

namespace LeetCode.MediumProblems
{
    class Longest_Mountain_in_Array
    {
        public int LongestMountain(int[] A)
        {
            int returnValue = 0;

            if (A != null && A.Length > 2)
            {
                int i = 0;
                while (i < A.Length)
                {
                    int rangeCounter = 0;
                    //***
                    //*** Counting upward
                    //***
                    int fElement = A[i];
                    int nxtPt = i + 1;
                    bool upward = false;
                    for (; nxtPt < A.Length; nxtPt++)
                    {
                        rangeCounter++;
                        if (fElement < A[nxtPt])
                        {
                            fElement = A[nxtPt];
                            upward = true;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (upward)
                    {
                        bool downward = false;
                        for (; nxtPt < A.Length; nxtPt++)
                        {
                            if (fElement > A[nxtPt])
                            {
                                rangeCounter++;
                                fElement = A[nxtPt];
                                downward = true;
                            }
                            else
                            {
                                nxtPt--;
                                break;
                            }
                        }

                        if (downward)
                        {
                            returnValue = Math.Max(returnValue, rangeCounter);
                        }
                    }

                    i = nxtPt;
                }
            }

            return returnValue;
        }

        [Test(Description = "https://leetcode.com/problems/longest-mountain-in-array/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Longest Mountain in Array")]
        [TestCaseSource("Input")]
        public void Test1((int Output, int[] Input) item)
        {
            var response = LongestMountain(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (0, new int[]{2,2,2}),
                    (5, new int[]{2,1,4,7,3,2,5}),
                    (7, new int[]{2,1,4,7,2,2,5, 1,2,4,7,5,2,1})
                };
            }
        }
    }
}
