using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2021.Nov
{
    public class Largest_Component_Size_by_Common_Factor
    {
        public int LargestComponentSize(int[] nums)
        {
            int returnValue = 1;
            List<List<int>> sets = new List<List<int>>();

            foreach (var num in nums)
            {
                sets.Add(new List<int>(){num});
            }

            for (int i = 1; i < nums.Length; i++)
            {
                var num = nums[i];
                
                for (int j = 0; j < i; j++)
                {
                    bool factorFound = false;
                    foreach (var item in sets[j])
                    {
                        if (CommonFactor(num, item))
                        {
                            factorFound = true;
                            break;
                        }
                    }

                    if (factorFound)
                    {
                        sets[i].AddRange(sets[j]);
                        sets[j].Clear();
                        returnValue = Math.Max(returnValue, sets[i].Count);
                    }
                }
            }
            
            return returnValue;
        }
        
        public bool CommonFactor(int x, int y)
        {
            int temp;
            if (x < y)
            {
                temp = y;
                y = x;
                x = temp;
            }
            while(x > y && x!=1 && y!=1)
            {
                x = x%y; 
                if (x == 0)
                    return true;
                if (x == 1)
                    return false;
                if (x < y)
                {
                    temp = y;
                    y = x;
                    x = temp;
                }
            }
            return (y!=1);
        }
        
        [Test(Description = "https://leetcode.com/problems/largest-component-size-by-common-factor/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Largest Component Size by Common Factor")]
        [TestCaseSource(nameof(Input))]
        public void Test1((int Output, int[] Input) item)
        {
            var response = LargestComponentSize(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(int Output, int[] Input)> Input
        {
            get
            {
                return new List<(int Output, int[] Input)>()
                {
                    (8, new []{2,3,6,7,4,12,21,39}),
                };
            }
        }
    }
}