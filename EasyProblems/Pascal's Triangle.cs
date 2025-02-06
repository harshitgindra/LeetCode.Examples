namespace LeetCode.EasyProblems
{
    class Pascal_s_Triangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> results = new List<IList<int>>()
            {
            };

            if (numRows != 0)
            {
                var prev = new List<int>() { 1 };
                results.Add(prev);

                if (numRows > 1)
                {
                    while (true)
                    {
                        prev = Start(prev);
                        results.Add(prev);
                        if (prev.Count == numRows)
                        {
                            break;
                        }
                    }
                }

            }

            return results;
        }

        private List<int> Start(IList<int> nums)
        {
            int numLength = nums.Count;
            var tempList = nums.ToList();
            tempList.Add(nums[0]);

            for (int i = 0; i < numLength - 1; i++)
            {
                tempList[i + 1] = nums[i] + nums[i + 1];
            }

            return tempList;
        }
    }
}
