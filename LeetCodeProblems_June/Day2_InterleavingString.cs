using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_June
{
    public class Day2_InterleavingString
    {
        //Using 2D dynamic programming
        //Time Complaxity: O(m*n), dp of size m*n filled
        //Space Complaxity: O(m*n), 2D dp of size (m+1)(n+1) where m and n are length of s1 and s2
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s3.Length != s2.Length + s1.Length)
                return false;
            bool[,] dp = new bool[s1.Length + 1, s2.Length + 1];
            for(int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = true;
                    }else if (i == 0)
                    {
                        //s1: aabcc s2: dbbca s3:aasbbcbcac => parse through s2 first
                        dp[i, j] = dp[i, j - 1] && s2[j - 1] == s3[i + j - 1];
                    }else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] && s1[i - 1] == s3[i + j - 1];
                    }
                    else
                    {
                        dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || 
                            (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                    }
                }
            }
            return dp[s1.Length, s2.Length];
        }
    }
}
