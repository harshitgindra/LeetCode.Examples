namespace LeetCode
{
    public class WordBreak
    {
        public WordBreak()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Arranging Coins");
            Console.WriteLine("----------------------------------------------------------");
        }

        private static Random rng = new Random();

        public IList<string> Start(string s, IList<string> wordDict)
        {
            var dictWords = wordDict;
            List<string> finallist = new List<string>();

            for (int j = 0; j < wordDict.Count; j++)
            {
                string tempWords = s;
                string wordsFound = "";

                for (int i = 0; i < wordDict.Count; i++)
                {
                    foreach (var item in dictWords)
                    {
                        for (int k = 0; k < tempWords.Length / item.Length; k++)
                        {
                            if (tempWords.Length >= item.Length && tempWords.Substring(0, item.Length) == item)
                            {
                                tempWords = tempWords.Substring(item.Length);
                                wordsFound = wordsFound + " " + item;
                            }
                        }
                    }

                    if (tempWords.Length == 0)
                    {
                        if (!finallist.Contains(wordsFound))
                        {
                            finallist.Add(wordsFound);
                        }
                        break;
                    }
                }

                dictWords = ShuffleList(dictWords);
            }

            return finallist.Select(x => x.Trim()).ToList();
        }

        public IList<string> ShuffleList(IList<string> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}
