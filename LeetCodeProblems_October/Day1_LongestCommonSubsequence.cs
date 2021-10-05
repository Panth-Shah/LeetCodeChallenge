using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_October
{
    public class Day1_LongestCommonSubsequence
    {
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            int m = text1.Length;
            int n = text2.Length;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if(i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i -1, j], dp[i, j-1]);
                    }
                }
            }

            return dp[m, n];
        }
    }
}
