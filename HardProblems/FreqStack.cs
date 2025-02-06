namespace LeetCode.Hard
{
    public class FreqStack
    {
        Dictionary<int, Stack<int>> bucket;
        SortedDictionary<int, int> valFreqMap;

        public FreqStack()
        {
            bucket = new Dictionary<int, Stack<int>>();
            valFreqMap = new SortedDictionary<int, int>();
        }

        public void Push(int x)
        {
            int newCnt = 0;
            if (!valFreqMap.ContainsKey(x))
            {
                valFreqMap[x] = 0;
            }

            valFreqMap[x]++;
            newCnt = valFreqMap[x];

            if (!bucket.ContainsKey(newCnt))
            {
                bucket[newCnt] = new Stack<int>();
            }

            bucket[newCnt].Push(x);
        }

        public int Pop()
        {
            var freq = bucket.Keys.Last();
            var popped = bucket[freq].Pop();
            valFreqMap[popped]--;
            if (bucket[freq].Count == 0)
            {
                bucket.Remove(freq);
            }

            return popped;
        }
    }

    public class Test
    {
        [Test(Description = "https://leetcode.com/problems/maximal-rectangle/")]
        [Category("Medium")]
        [Category("LeetCode")]
        [Category("maximal rectangle")]
        [TestCaseSource("Input")]
        public void Test1((int Output, char[][] Input) item)
        {
            FreqStack freqStack = new FreqStack();
            freqStack.Push(1);
            freqStack.Push(0);
            freqStack.Push(0);
            freqStack.Push(1);
            freqStack.Push(5);
            freqStack.Push(4);
            freqStack.Push(1);
            freqStack.Push(5);
            freqStack.Push(1);
            freqStack.Push(6);
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
            freqStack.Pop();
        }

        public static IEnumerable<(int Output, char[][] Input)> Input
        {
            get
            {
                return new List<(int Output, char[][] Input)>()
                {
                    (4, new char[][]
                    {
                        new char[] {'0', '1'},
                        new char[] {'1', '0'},
                    }),
                    (4, new char[][]
                    {
                        new char[] {'1', '0', '1', '0', '0'},
                        new char[] {'1', '0', '1', '1', '1'},
                        new char[] {'1', '1', '1', '1', '1'},
                        new char[] {'1', '0', '1', '0', '0'},
                        new char[] {'1', '0', '0', '1', '0'},
                    }),
                };
            }
        }
    }
}