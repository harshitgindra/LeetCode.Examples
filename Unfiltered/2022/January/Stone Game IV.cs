using NUnit.Framework.Legacy;

namespace LeetCode.Problems._2022.January
{
    /// <summary>
    /// https://leetcode.com/problems/stone-game-iv/
    /// </summary>
    public class Stone_Game_IV
    {
        private bool?[] _dp;
        public bool WinnerSquareGame(int n)
        {
            _dp = new bool?[n+1];
            return Helper(n);
        }

        private bool Helper(int n)
        {
            //***
            //*** Remaining stones are 0 or less than 0
            //*** Player cannot make any move, Hence return false
            if (n <= 0)
            {
                return false;
            }
            //***
            //*** Checking dp if the combination has already been explored
            //***
            if (_dp[n].HasValue)
            {
                return _dp[n].Value;
            }
            
            for (int i = 1; i * i <= n; i++)
            {
                //***
                //*** If Helper returns false, it means the next player lost and current player won
                //***
                if (!Helper(n - (i * i)))
                {
                    _dp[n] = true;
                    return true;
                }
            }

            //***
            //*** Setting dp[n] to false as player can't win with this value of n
            //***
            _dp[n] = false;
            return false;
        }
        
        [Test(Description = "https://leetcode.com/problems/stone-game-iv/")]
        [Category("Hard")]
        [Category("LeetCode")]
        [Category("Stone Game II")]
        [TestCaseSource(nameof(Input))]
        public void Test1((bool Output, int Input) item)
        {
            var response = WinnerSquareGame(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(bool Output, int Input)> Input
        {
            get
            {
                return new List<(bool Output, int Input)>()
                {

                    (true, 4),
                    (false, 2),
                };
            }
        }
    }
}