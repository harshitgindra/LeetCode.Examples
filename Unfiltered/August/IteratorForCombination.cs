using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode.August
{
    public class CombinationIterator
    {
        private string _characters;
        private int _combinationLength;
        private IDictionary<int, string> _combinations;
        private int _lookupCounter;

        public CombinationIterator(string characters, int combinationLength)
        {
            _characters = characters;
            _combinationLength = combinationLength;
            _combinations = new Dictionary<int, string>();
            _RetrieveAllCombination();
            _lookupCounter = 0;
        }

        private void _RetrieveAllCombination()
        {
            int counter = 0;
            int startIndex = 0;
            while (startIndex <= _characters.Length - _combinationLength)
            {
                for (int i = 0; i <= _characters.Length - _combinationLength; i++)
                {
                    if (i == 0)
                    {
                        var str = _characters.Substring(startIndex, _combinationLength);
                        _combinations.Add(counter, str);
                        counter++;
                    }
                    else
                    {
                        var str = _characters[startIndex] + _characters.Substring(i + 1, _combinationLength - 1);

                        if (!_combinations.Any(x => x.Value == str))
                        {
                            _combinations.Add(counter, str);
                            counter++;
                        }
                    }
                }

                startIndex++;
            }
        }

        public string Next()
        {
            return _combinations[_lookupCounter++];
        }

        public bool HasNext()
        {
            return _lookupCounter < _combinations.Count;
        }
    }
}
