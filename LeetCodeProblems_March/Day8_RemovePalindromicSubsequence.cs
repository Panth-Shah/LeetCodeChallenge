using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day8_RemovePalindromicSubsequence
    {
        //Key Takeaway: It's Subsequence and not Substring or Subarray, with Subsequence you can skip characters
        //There can be basically 3 different answers for this problem:
            //We return 0, if string is already empty, we do not need to do anything.
            //If string is palindrome itself and it is not empty, we return 1.
            //Finally, if two previous cases are not true, we can first delete all letters a and then all letters b, so we return 2.
        public int RemovePalindromeSub(String s)
        {
            if (s.Length == 0)
            {
                return 0;
            }
            else if (checkPalindrome(s))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private bool checkPalindrome(String s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
