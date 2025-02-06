namespace LeetCode.May
{
    public class FirstBadVersionTest
    {
        public int FirstBadVersion(int n)
        {
            return _IsBad(1, n);
        }

        private int _IsBad(int start, int end)
        {
            if (start == end)
            {
                //***
                //*** Return start if start and end are equal
                //***
                return start;
            }
            if (end - start == 1)
            {
                //***
                //*** If difference between start and end is 1, check both and return correct version
                //***
                if (IsBadVersion(start))
                {
                    return start;
                }
                return end;
            }
            //***
            //*** Calculate the avg of two numbers
            //***
            var center = Convert.ToInt32((end / 2.0) + (start / 2.0));
            if (IsBadVersion(center))
            {
                //***
                //*** Center is bad version, we need to look at all numbers lower than center
                //***
                return _IsBad(start, center);
            }
            else
            {
                //***
                //*** Center is not bad version, we need to look at all numbers greater than center
                //***
                return _IsBad(center, end);
            }
        }

        bool IsBadVersion(int n)
        {
            return n >= 4;
        }
    }
}
