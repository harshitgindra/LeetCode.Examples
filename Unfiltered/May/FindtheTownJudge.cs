namespace LeetCode.May
{
    class FindtheTownJudge
    {
        public int FindJudge(int N, int[][] trust)
        {
            if (trust.Length == 1)
            {
                return trust[0][1];
            }

            HashSet<int> notJudgeList = new HashSet<int>();

            int judgeId = -1;
            foreach (var item in trust)
            {
                notJudgeList.Add(item[0]);
            }

            if (notJudgeList.Count == N
                || notJudgeList.Count < N - 1)
            {
                return -1;
            }
            else
            {
                for (int i = 1; i <= N; i++)
                {
                    if (!notJudgeList.Contains(i))
                    {
                        judgeId = i;
                        break;
                    }
                }
            }

            foreach (var item in trust)
            {
                if (!notJudgeList.Contains(item[1]))
                {
                    if (judgeId == item[1])
                    {
                        judgeId = item[1];
                    }
                }
            }

            return judgeId;
        }
    }
}
