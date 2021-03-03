using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    //Time: O(n)
    //Space: O(1)
    public class Day2_SetMismatch
    {
        public int[] FindErrorNums(int[] nums)
        {
            int len = nums.Length;
            int dup = -1, missing = 1;
            foreach (int num in nums)
            {
                if (nums[Math.Abs(num) - 1] < 1)
                {
                    dup = Math.Abs(num);
                }
                else
                {
                    nums[Math.Abs(num) - 1] *= -1;
                }
            }

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    missing = i + 1;
            }
            return new int[] { dup, missing };
        }
    }
}
