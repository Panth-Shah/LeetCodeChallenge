using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day18_MaxNumberOfKSumPair
    {
        public int MaxOperations(int[] nums, int k)
        {
            int result = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int ele in nums)
            {
                if (map.ContainsKey(k - ele))
                {
                    int freq = map[k - ele];
                    if (freq == 1)
                    {
                        map.Remove(k - ele);
                    }
                    else
                    {
                        map[k - ele] = freq - 1;
                    }
                    result++;
                }
                else
                {
                    if (map.ContainsKey(ele))
                    {
                        map[ele] += 1;
                    }
                    else
                    {
                        map.Add(ele, 1);
                    }
                }
            }
            return result;
        }
    }
}
