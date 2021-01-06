using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day6_KthMissingPositiveNumber
    {
        public int FindKthPositive(int[] arr, int k)
        {
            int low = 0;
            int high = arr.Length;
            while (low < high)
            {
                int mid = (high - low) / 2 + low;
                if (arr[mid] - (mid + 1) >= k)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return low + k;
        }
    }
}
