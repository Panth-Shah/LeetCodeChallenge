using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day18_WiggleSubsequence
    {
        //Greedy Approach
        //Time: O(N)
        //Space: O(1)

        //Note: Here, we are maintaining prevDiff to identify if the next wiggle should be incresing or decreasing.
        //If prevDiff >= 0; means diff should be decreasing and so should be < 0
        //If prevDiff <= 0; means diff should be increasing and so should be > 0
        //Base case: prevDiff = i[1] - i[0]; diff = i[2] - i[1] => Subsequence : 0 -> 1 -> 2
        public int WiggleMaxLength(int[] nums)
        {
            int len = nums.Length;
            if (len < 2) return len;
            int prevDiff = nums[1] - nums[0];
            int count = prevDiff != 0 ? 2 : 1;

            for (int i = 2; i < len; i++)
            {
                int diff = nums[i] - nums[i - 1];
                if ((diff > 0 && prevDiff <= 0) || (diff < 0 && prevDiff >= 0))
                {
                    count++;
                    prevDiff = diff;
                }
            }
            return count;
        }
    }
}
