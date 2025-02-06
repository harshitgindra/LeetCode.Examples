namespace LeetCode.May
{
    public class FirstUniqueCharacterinAString
    {
        public int FirstUniqChar(string s)
        {
            var temp = s.GroupBy(x => x)
                .FirstOrDefault(x => x.Count() == 1);

            if (temp == null)
            {
                return -1;
            }
            else
            {
                return s.IndexOf(temp.Key);
            }
        }
    }
}
