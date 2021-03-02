using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day14_ReduceVariableTo0
    {
        public int MinOperations(int[] nums, int x)
        {
            int target = -x;
            foreach (int num in nums)
            {
                target += num;
            }
            if (target == 0) return nums.Length;
            if (target < 0) return -1;

            int result = -1, sum = 0, left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while (sum > target)
                {
                    sum -= nums[left++];
                }
                if (sum == target)
                {
                    result = Math.Max(result, right - left + 1);
                }

            }
            return result == -1 ? -1 : nums.Length - result;
        }
    }
}
