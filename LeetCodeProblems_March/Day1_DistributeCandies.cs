using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day1_DistributeCandies
    {
        public int DistributeCandies(int[] candyType)
        {
            int len = candyType.Length;
            int candiesAllowedToEat = len / 2;
            int type = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < len; i++)
            {
                if (type == len/2)
                {
                    break;
                }
                if (!dict.ContainsKey(candyType[i]))
                {
                    dict.Add(candyType[i], 0);
                    type++;
                }
                dict[candyType[i]] += 1;
            }

            return type;
        }
    }
}
