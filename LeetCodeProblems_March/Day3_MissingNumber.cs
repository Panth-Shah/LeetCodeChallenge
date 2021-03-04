using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day3_MissingNumber
    {
        //Time: O(N)
        //Space: O(N)
        public int MissingNumber(int[] nums)
        {
            int len = nums.Length;
            int[] arr = new int[len + 1];
            int result = -1;
            foreach (int num in nums)
            {
                arr[num] = 1;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    result = i;
                }
            }
            return result;
        }
    }
}
