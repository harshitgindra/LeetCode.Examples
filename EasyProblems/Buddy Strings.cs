namespace LeetCode.EasyProblems
{
    class Buddy_Strings
    {
        public bool BuddyStrings(string a, string b)
        {
            if (a.Length != b.Length) return false;


            List<char> adiff = new List<char>();
            List<char> bdiff = new List<char>();

            int[] ccount = new int[26];
            int dubCount = 0;

            for (int i = 0; i < a.Length; i++)
            {
                ccount[a[i] - 'a'] += 1;
                if (ccount[a[i] - 'a'] > 1) dubCount = 1;
                if (a[i] != b[i])
                {
                    adiff.Add(a[i]);
                    bdiff.Add(b[i]);
                }
                if (adiff.Count > 2) return false;
            }

            if ((adiff.Count == 0) && (dubCount == 1))
            {
                return true;
            }

            if (adiff.Count == 1) return false;

            if ((adiff.Count == 2) && (adiff[0] == bdiff[1]) && (adiff[1] == bdiff[0]))
            {
                return true;
            }
            return false;
        }
    }
}
