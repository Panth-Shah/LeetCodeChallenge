using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_October
{
    public class Day2_DungeonGame
    {
        public static int CalculateMinimumHP(int[][] dungeon)
        {
            #region Remove
            //int rows = dungeon.Length;
            //int columns = dungeon[0].Length;
            //int health = dungeon[0][0] <= 0 ? dungeon[0][0]*-1 + 1 :  ;
            //int row = 0;
            //int column = 0;
            //bool isNegative = false;
            //if (rows == 1 && columns == 1 && health > 0)
            //{
            //    return 1;
            //}

            //while (row != rows - 1 || column != columns-1)
            //{
            //    if (!isNegative && health < 0)
            //        isNegative = true;

            //    int right = column < columns - 1 ? health + dungeon[row][column + 1] : int.MinValue;
            //    int down = row < rows - 1 ? health + dungeon[row + 1][column] : int.MinValue;

            //    if (right > down)
            //    {
            //        health = right;
            //        column++;
            //    }
            //    else if (right < down)
            //    {
            //        health = down;
            //        row++;
            //    }
            //}
            //return health <= 0 ? health * -1 + 1 : isNegative ? health : 1;
            #endregion

            #region Remove
            //int rows = dungeon.Length;
            //int columns = dungeon[0].Length;

            //int row = 0;
            //int column = 0;
            //int health = dungeon[0][0] < 0 ? dungeon[0][0] * -1 + 1 : 1;
            //while (row != rows - 1 || column != columns - 1)
            //{
            //    int current = dungeon[row][column];
            //    int carry = health + current;
            //    int right = column < columns - 1 ? carry + dungeon[row][column + 1] : int.MinValue;
            //    int down = row < rows - 1 ? carry + dungeon[row + 1][column] : int.MinValue;

            //    if (right > down)
            //    {
            //        if(right <= 0)
            //        {
            //            health = ((dungeon[row][column + 1])*-1 + 1) - carry;
            //        }
            //        column++;
            //    }
            //    else if (right < down)
            //    {
            //        if (down <= 0)
            //        {
            //            health = ((dungeon[row + 1][column]) * -1 + 1) - carry;
            //        }
            //        row++;
            //    }
            //}

            //return health;
            #endregion

            #region DP Solution
            //int rows = dungeon.Length;
            //int columns = dungeon[0].Length;
            //int[,] dp = new int[rows, columns];

            ////Fill the last cell
            //dp[rows - 1, columns - 1] = dungeon[rows - 1][columns - 1] > 0 ? 1 : -dungeon[rows - 1][columns - 1] + 1;

            ////Fill last column cells only
            //for (int i = rows - 2; i >= 0; i--)
            //{
            //    dp[i, columns - 1] = Math.Max(1, dp[i + 1, columns - 1] - dungeon[i][columns - 1]);
            //}

            ////Fill last row cells only
            //for (int j = columns- 2; j >= 0; j--)
            //{
            //    dp[rows - 1, j] = Math.Max(1, dp[rows - 1, j + 1] - dungeon[rows - 1][j]);
            //}

            ////Fill remaining blocks
            //for (int i = rows - 2; i >= 0; i--)
            //{
            //    for (int j = columns - 2; j >= 0; j--)
            //    {
            //        dp[i, j] = Math.Max(1, Math.Min(dp[i + 1,j] - dungeon[i][j], dp[i, j+1] - dungeon[i][j]));
            //    }
            //}

            //return dp[0, 0];
            #endregion

            #region DP Faster
            var rows = dungeon.Length;
            var cols = dungeon[0].Length;
            var dp = new int[rows, cols];
            for (int r = rows - 1; r >= 0; r--)
            {
                for (int c = cols - 1; c >= 0; c--)
                {
                    if (r == rows - 1 && c == cols - 1)
                    {
                        dp[r, c] = dungeon[r][c];
                        continue;
                    }

                    var down = r + 1 < rows ? dp[r + 1, c] : int.MinValue;
                    var right = c + 1 < cols ? dp[r, c + 1] : int.MinValue;

                    var best = Math.Max(down, right);

                    dp[r, c] = Math.Min(dungeon[r][c] + best, dungeon[r][c]);
                }
            }

            if (dp[0, 0] >= 0)
            {
                return 1;
            }

            return -dp[0, 0] + 1;
        }
        #endregion

    }
}
