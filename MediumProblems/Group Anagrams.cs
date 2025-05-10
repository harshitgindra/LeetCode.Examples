using System.Text;

namespace LeetCode.MediumProblems
{
    class GroupAnagramsSolution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs) 
        {
            // Dictionary to hold groups of anagrams
            Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();
        
            foreach (string str in strs)
            {
                string key = GenerateAnagramKey(str);
            
                // Create new group or add to existing
                if (!anagramGroups.TryGetValue(key, out List<string> group))
                {
                    group = new List<string>();
                    anagramGroups[key] = group;
                }
                group.Add(str);
            }
        
            return new List<IList<string>>(anagramGroups.Values);
        }
    
        private string GenerateAnagramKey(string s)
        {
            int[] charCounts = new int[26];
            // Count character frequencies
            foreach (char c in s)
            {
                charCounts[c - 'a']++;
            }
        
            // Build unique key from counts
            StringBuilder keyBuilder = new StringBuilder();
            foreach (int count in charCounts)
            {
                keyBuilder.Append(count).Append('#');
            }
        
            return keyBuilder.ToString();
        }
        
        [Test(Description = "https://leetcode.com/problems/group-anagrams/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("Group Anagrams")]
        [TestCaseSource(nameof(Input))]
        public void Test1((IList<IList<string>> Output, string[] Input) item)
        {
            var response = GroupAnagrams(item.Input);
            // Normalize both actual and expected results
            var normalizedResponse = NormalizeAnagramGroups(response);
            var normalizedExpected = NormalizeAnagramGroups(item.Output);
    
            Assert.That(normalizedResponse, Is.EqualTo(normalizedExpected));
        }
        
        private IList<List<string>> NormalizeAnagramGroups(IList<IList<string>> groups)
        {
            return groups
                .Select(group => 
                        group.OrderBy(s => s).ToList() // Sort individual anagrams
                )
                .OrderBy(group => 
                        group.FirstOrDefault() // Sort groups by first element
                )
                .ToList();
        }

        public static IEnumerable<(IList<IList<string>> Output, string[] Input)> Input =>
            new List<(IList<IList<string>> Output, string[] Input)>()
            {
                ( [["bat"],["nat","tan"],["ate","eat","tea"]], ["eat","tea","tan","ate","nat","bat"]),
            };
    }
}
