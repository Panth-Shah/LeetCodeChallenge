using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_June
{
    public class Day3_MaxAreaOfPieceOfCake
    {
        //Time Complaxity: O(N * log(N) + M * log(M)) where N is the length of hc and M is the length of vc
        //Space Complaxity: O(1); ignoring the space required for sorting
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            //Sort both the cut array
            Array.Sort(horizontalCuts);
            Array.Sort(verticalCuts);

            //Identify first and last cut distance from start and end
            int maxh = Math.Max(horizontalCuts[0], h - horizontalCuts[horizontalCuts.Length -1]);
            int maxw = Math.Max(verticalCuts[0], w - verticalCuts[verticalCuts.Length - 1]);

            //Find the max distance between two cuts horizontally
            for (int i = 1; i < horizontalCuts.Length; i++)
            {
                maxh = Math.Max(maxh, horizontalCuts[i] - horizontalCuts[i-1]);
            }

            //Find the max distance between two cuts vertically
            for (int  i = 1; i < verticalCuts.Length; i++)
            {
                maxw = Math.Max(maxw, verticalCuts[i] - verticalCuts[i-1]);
            }

            //Return area between two max distance of cuts
            int mod = (int)Math.Pow(10, 9) + 7;
            return (int)((maxh * maxw) % mod);
        }
    }
}
