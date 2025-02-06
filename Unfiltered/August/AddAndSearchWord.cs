namespace LeetCode.August
{
    public class WordDictionary
    {
        private readonly Dictionary<int, List<string>> _wordsMap;

        public WordDictionary()
        {
            _wordsMap = new Dictionary<int, List<string>>();
        }

        public void AddWord(string word)
        {
            int length = word.Length;
            if (!_wordsMap.ContainsKey(length))
            {
                _wordsMap.Add(length, new List<string>());
            }

            _wordsMap[length].Add(word);
        }

        public bool Search(string pattern)
        {
            if (!_wordsMap.ContainsKey(pattern.Length))
            {
                return false;
            }

            return _wordsMap[pattern.Length]
                .Any(x => _IsMatch(x, pattern));
        }

        private bool _IsMatch(string word, string pattern)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (pattern[i] != word[i] && pattern[i] != '.')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
