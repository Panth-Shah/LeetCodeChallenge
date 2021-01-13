using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day13_BoatsToSavePeople
    {
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int p1 = 0, p2 = people.Length - 1, ans = 0;
            while (p1 <= p2)
            {
                if (people[p1] + people[p2] <= limit)
                {
                    p1 += 1;
                }
                ans += 1;
                p2 -= 1;
            }
            return ans;
        }
    }
}
