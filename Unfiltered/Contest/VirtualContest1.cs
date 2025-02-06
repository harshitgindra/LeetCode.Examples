namespace LeetCode.Contest
{
    class VirtualContest1
    {
        public double TrimMean(int[] arr)
        {
            if (arr == null || arr.Length < 1)
            {
                return 0.0;
            }
            else
            {
                var benchmark = (int)(arr.Length * 0.05);

                Array.Sort(arr);

                int sum = 0;
                var nums = 0.0;
                for (int i = benchmark + 1; i < arr.Length - benchmark - 1; i++)
                {
                    sum = sum + arr[i];
                    nums++;
                }

                return sum / nums;
            }
        }

    }

    public class Fancy
    {
        List<int> _nums;
        public Fancy()
        {
            _nums = new List<int>();
        }

        public void Append(int val)
        {
            _nums.Add(val);
        }

        public void AddAll(int inc)
        {
            for (int i = 0; i < _nums.Count; i++)
            {
                _nums[i] = _nums[i] + inc;
            }
        }

        public void MultAll(int m)
        {
            for (int i = 0; i < _nums.Count; i++)
            {
                var mult = _nums[i] * m;
                if (mult < 0)
                {
                    var val = _nums[i] % 1000000007;
                    val = val * m % 1000000007;
                    _nums[i] = val;
                }
                else
                {
                    _nums[i] = mult;
                }
            }
        }

        public int GetIndex(int idx)
        {
            if (idx >= _nums.Count)
            {
                return -1;
            }
            return _nums[idx];
        }
    }
}
