using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day11_CoinChange
    {
        #region DP Soltion
        public int CoinChangeDP(int[] coins, int amount)
        {
            //Build DP array
            int[] dp = new int[amount + 1];
            //Fill array with Amount + 1
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = amount + 1;
            }
            //Base case
            dp[0] = 0;

            //Outer loop is for coins
            foreach (int coin in coins)
            {
                //Iterate over DP array to find how many coins needed to form that total of amount
                //Start from the denomination of coin as it's not possible to make total less than the denomination with this coin
                for (int i = coin; i <= amount; i++)
                {
                    //Update the DP array with minimum number of coins needed to make this total
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
            }
            //Catch condition where if its not possible to form total with given coins return -1
            return dp[amount] <= amount ? dp[amount] : -1;
        }
        #endregion

        #region DFS Solution | Fastest
        public int CoinChangeDFS(int[] coins, int amount)
        {
            int result = int.MaxValue;
            Array.Sort(coins, (a, b) => b.CompareTo(a));
            for (int i = 0; i < coins.Length; i++)
                dfs(i, amount, 0, coins, ref result);

            return result == int.MaxValue ? -1 : result;
        }
        private void dfs(int pos, int rem, int count, int[] coins, ref int result)
        {
            if (rem == 0)
            {
                result = Math.Min(result, count);
                return;
            }

            for (int i = pos; i < coins.Length; i++)
            {
                if (coins[i] <= rem && (count + rem / coins[i] < result))
                    dfs(i, rem - coins[i], count + 1, coins, ref result);
            }
        }
        #endregion
    }
}
