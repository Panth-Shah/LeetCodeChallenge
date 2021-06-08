using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_June
{
    public class Day7_MinCostClimbingStairs
    {
        //Time Complaxity: O(N)
        //Space Complaxity: O(N)
        public int minCostClimbingStairs(int[] cost)
        {
            // The array's length should be 1 longer than the length of cost
            // This is because we can treat the "top floor" as a step to reach
            int[] minimumCost = new int[cost.Length + 1];

            // Start iteration from step 2, since the minimum cost of reaching
            // step 0 and step 1 is 0
            for (int i = 2; i < minimumCost.Length; i++)
            {
                int takeOneStep = minimumCost[i - 1] + cost[i - 1];
                int takeTwoSteps = minimumCost[i - 2] + cost[i - 2];
                minimumCost[i] = Math.Min(takeOneStep, takeTwoSteps);
            }

            // The final element in minimumCost refers to the top floor
            return minimumCost[minimumCost.Length - 1];
        }
    }
}
