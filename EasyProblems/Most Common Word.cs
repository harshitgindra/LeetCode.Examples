namespace LeetCode.EasyProblems
{
    class Most_Common_Word
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var grp = paragraph.Replace("!", " ")
                .Replace("!", " ")
                .Replace("?", " ")
                .Replace("'", " ")
                .Replace(",", " ")
                .Replace(";", " ")
                .Replace(".", " ")
                .Trim()
                .ToLower()
                .Split(" ")
                .Where(x => !string.IsNullOrEmpty(x)
                    && !banned.Contains(x))
                .GroupBy(x => x)
                .Select(x => new
                {
                    txt = x.Key,
                    count = x.Count()
                })
                .OrderByDescending(x => x.count)
                .First();

            return grp.txt;
        }
    }
}
