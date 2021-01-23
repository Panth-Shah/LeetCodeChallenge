using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day21_MostCompetitiveSubsequence
    {
        public int[] MostCompetitive(int[] nums, int k)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (stack.Count > 0)
                {
                    while (stack.Count + (nums.Length - i) > k && stack.Count > 0 && stack.Peek() > nums[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Count < k)
                    {
                        stack.Push(nums[i]);
                    }
                }
                else
                {
                    stack.Push(nums[i]);
                }
            }

            return stack.Reverse().ToArray();
        }
}
}
