

namespace LeetCode.EasyProblems
{
    class ReverseWordsStringIII
    {
        public string ReverseWords(string s)
        {
            var arry = s.Split(" ");
            for (int i = 0; i < arry.Length; i++)
            {
                var word = arry[i].ToCharArray();

                int startIndex = 0;
                int endIndex = word.Length - 1;
                while (startIndex < endIndex)
                {
                    var temp = word[startIndex];
                    word[startIndex++] = word[endIndex];
                    word[endIndex--] = temp;
                }

                arry[i] = new string(word);
            }

            return string.Join(" ", arry);
        }

        [Test(Description = "https://leetcode.com/problems/reverse-words-in-a-string-iii/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Reverse Words in a String III")]
        [TestCaseSource(nameof(Input))]
        public void Test1((string Output, string Input) item)
        {
            var response = ReverseWords(item.Input);
            Assert.That(response, Is.EqualTo(item.Output));
        }

        public static IEnumerable<(string Output, string Input)> Input =>
            new List<(string Output, string Input)>()
            {
                ("s'teL ekat edoCteeL tsetnoc", "Let's take LeetCode contest"),
            };
    }
}