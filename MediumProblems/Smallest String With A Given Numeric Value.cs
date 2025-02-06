namespace LeetCode.MediumProblems
{
    public class Smallest_String_With_A_Given_Numeric_Value
    {
        public string GetSmallestString(int n, int k)
        {
            Dictionary<int, char> dict = new Dictionary<int, char>()
            {
                {1, 'a'},
                {2, 'b'},
                {3, 'c'},
                {4, 'd'},
                {5, 'e'},
                {6, 'f'},
                {7, 'g'},
                {8, 'h'},
                {9, 'i'},
                {10, 'j'},
                {11, 'k'},
                {12, 'l'},
                {13, 'm'},
                {14, 'n'},
                {15, 'o'},
                {16, 'p'},
                {17, 'q'},
                {18, 'r'},
                {19, 's'},
                {20, 't'},
                {21, 'u'},
                {22, 'v'},
                {23, 'w'},
                {24, 'x'},
                {25, 'y'},
                {26, 'z'},
            };

            var result = Check(n, k, new List<char>(), new List<string>(), dict);

            var returnval = result.OrderBy(x => x)
                .FirstOrDefault();

            return returnval;
        }

        private List<string> Check(int remainingBit, int k, List<char> val, List<string> result,
            Dictionary<int, char> dict)
        {
            if (k == 0 && remainingBit == 0)
            {
                result.Add(new string(val.ToArray()));
            }
            else if (remainingBit == 0 || k<= 0)
            {
            }
            else if (remainingBit == 1)
            {
                if (k < 27)
                {
                    val.Insert(0, dict[k]);
                    result = Check(0, 0, val, result, dict);
                    val.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < remainingBit; i++)
                {
                    foreach (var item in dict.Where(x => x.Key <= k))
                    {
                        val.Insert(0, item.Value);
                        result = Check(remainingBit - 1, k - item.Key, val, result, dict);
                        val.RemoveAt(0);
                    }
                }
            }

            return result;
        }
    }
}