using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace Leetcode.Problems._2021.Sept
{
    class Find_Winner_on_a_Tic_Tac_Toe_Game
    {
        public string Tictactoe(int[][] moves)
        {
            int[] rows = new int[3];
            int[] colums = new int[3];
            int diag = 0;
            int reverseDiag = 0;
            string winner;
            //***
            //*** If moves are less than 9, it means game is Pending
            //***
            if (moves.Length < 9)
            {
                winner = "Pending";
            }
            //***
            //*** Else it's a Draw
            //***
            else
            {
                winner = "Draw";
            }

            for (int i = 0; i < moves.Length; i++)
            {
                var move = moves[i];
                if (i % 2 == 0)
                {
                    //***
                    //*** Player A turn
                    //*** Spot is determined by incrementing corresponding indexes in rows and columns
                    //*** diagonal and reverse diagonal
                    //***
                    rows[move[0]]++;
                    colums[move[1]]++;
                    //***
                    //*** x and y axis are same, update the diagonal counter
                    //***
                    if (move[0] == move[1])
                    {
                        diag++;
                    }
                    //***
                    //*** Update reverse diagonal counter based on specific xy coordinates
                    //***
                    if ((move[0] == 0 && move[1] == 2)
                        || (move[0] == 2 && move[1] == 0)
                        || (move[0] == 1 && move[1] == 1))
                    {
                        reverseDiag++;
                    }
                }
                else
                {
                    //***
                    //*** Player B turn                    
                    //*** Spot is determined by decrementing corresponding indexes in rows and columns
                    //*** diagonal and reverse diagonal
                    //***
                    rows[move[0]]--;
                    colums[move[1]]--;
                    //***
                    //*** x and y axis are same, update the diagonal counter
                    //***
                    if (move[0] == move[1])
                    {
                        diag--;
                    }
                    //***
                    //*** Update reverse diagonal counter based on specific xy coordinates
                    //***
                    if ((move[0] == 0 && move[1] == 2)
                                           || (move[0] == 2 && move[1] == 0)
                                           || (move[0] == 1 && move[1] == 1))
                    {
                        reverseDiag--;
                    }
                }
                //***
                //*** If any row, col, diag or reverse diag val is 3
                //*** It means player A won as the turn was determined by incrementing the counters
                //***
                if (rows[move[0]] == 3 || colums[move[1]] == 3
                    || diag == 3 || reverseDiag == 3)
                {
                    winner = "A";
                }
                //***
                //*** If any row, col, diag or reverse diag val is -3
                //*** It means player A won as the turn was determined by decrementing the counters
                //***
                else if (rows[move[0]] == -3 || colums[move[1]] == -3
                    || diag == -3 || reverseDiag == -3)
                {
                    winner = "B";
                }
            }

            return winner;
        }

        [Test(Description = "https://leetcode.com/problems/find-winner-on-a-tic-tac-toe-game/")]
        [Category("Easy")]
        [Category("LeetCode")]
        [Category("Find Winner on a Tic Tac Toe Game")]
        [TestCaseSource("Input")]
        public void Test1((string Output, int[][] Input) item)
        {
            var response = Tictactoe(item.Input);
            ClassicAssert.AreEqual(item.Output, response);
        }

        public static IEnumerable<(string Output, int[][] Input)> Input
        {
            get
            {
                return new List<(string Output, int[][] Input)>()
                {
                    ("A", new int[][]{
                        new int[]{ 0,0},
                        new int[]{ 1,1},
                        new int[]{ 0,1},
                        new int[]{ 0,2},
                        new int[]{ 1,0},
                        new int[]{ 2,0},
                        }),
                };
            }
        }
    }
}
