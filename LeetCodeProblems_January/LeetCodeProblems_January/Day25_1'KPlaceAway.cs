using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day25_1_KPlaceAway
    {
        public bool KLengthApart(int[] nums, int k)
        {
            int count = k;
            foreach (int num in nums)
            {
                if (num == 1)
                {
                    if (count < k)
                    {
                        return false;
                    }
                    count = 0;
                }
                else
                {
                    count++;
                }
            }
            return true;
        }
    }
}
