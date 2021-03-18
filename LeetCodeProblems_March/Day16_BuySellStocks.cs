using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day16_BuySellStocks
    {
        public int MaxProfit(int[] prices, int fee)
        {
            int cash = 0, hold = -prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                cash = Math.Max(cash, hold + prices[i] - fee);
                hold = Math.Max(hold, cash - prices[i]);
            }
            return cash;
        }
    }
}
