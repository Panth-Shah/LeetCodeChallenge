using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_June
{
    //Time Complaxity: O(N)
    //Space Complaxity: O(N)
    public class Day6_LongestConsecutiveSequence
    {
        public int LongestConsecutive(int[] nums)
        {
            //Build HashSet for existing numbers
            HashSet<int> num_set = new HashSet<int>();
            foreach (int num in nums)
            {
                num_set.Add(num);
            }

            int longestSteak = 0;
            foreach (int num in num_set)
            {
                if (!num_set.Contains(num-1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (num_set.Contains(currentNum + 1))
                    {
                        currentNum += 1;
                        currentStreak += 1;
                    }

                    longestSteak = Math.Max(longestSteak, currentStreak);
                }
            }

            return longestSteak;
        }
    }
}
