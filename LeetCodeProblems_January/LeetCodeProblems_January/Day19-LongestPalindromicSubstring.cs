using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day19_LongestPalindromicSubstring
    {
        public string longestPalindrome(string s)
        {
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int odd = expand(s, i, i);
                int even = expand(s, i, i + 1);
                int len = Math.Max(odd, even);
                if (len > end - start)
                {
                    //Even len (6)-> 2 start --> i-2, end -> i+3
                    //Odd len (5) -> 2 start i-2, end -> i+2
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }
            return s.Substring(start, end + 1);
        }
        int expand(string s, int left, int right)
        {
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left - 1;
        }
    }
}
