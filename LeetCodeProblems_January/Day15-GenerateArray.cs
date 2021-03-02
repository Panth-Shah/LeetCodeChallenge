using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day15_GenerateArray
    {
        public int GetMaximumGenerated(int n)
        {
            if (n < 2)
                return n;

            int[] nums = new int[n + 1];
            nums[0] = 0;
            nums[1] = 1;

            int max = 0;
            for (int i = 2; i <= n; i++)
            {
                nums[i] = nums[i / 2];
                if (i % 2 == 1)
                {
                    nums[i] += nums[i / 2 + 1];
                }
                max = Math.Max(max, nums[i]);
            }
            return max;
        }
    }
}
