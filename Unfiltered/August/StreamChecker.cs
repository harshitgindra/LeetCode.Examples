namespace LeetCode.August
{
    public class StreamChecker
    {
        private HashSet<string> _words;
        private string _lastQuery;

        public StreamChecker(string[] words)
        {
            _words = words.ToHashSet();
            _lastQuery = default;
        }

        public bool Query(char letter)
        {
            _lastQuery += letter;
            if (_words.Contains($"{letter}"))
            {
                return true;
            }
            else
            {
                for (int i = _lastQuery.Length - 2; i > 0; i--)
                {
                    var newWord = _lastQuery.Substring(i);
                    if (_words.Any(x=>x.EndsWith(newWord)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
