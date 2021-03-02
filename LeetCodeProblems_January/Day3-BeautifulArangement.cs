using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day3_BeautifulArangement
    {
        int result = 0;
        public Day3_BeautifulArangement()
        {

        }
        public int CountArrangement(int n)
        {    
            int[,] matrix = new int[n + 1,n + 1];
            //Mark all the valid blocks to 1
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (i%j ==0 || j%i ==0)
                    {
                        matrix[i,j] = 1;
                    }
                }
            }

            for (int x = 1; x < n+1; x++)
            {
                int row = x;
                int ind = 1;
                int[] nums = new int[n + 1];

                while (ind < n + 1)
                {
                    if (matrix[row, ind] == 1 && ind <= n)
                    {
                        nums[ind] = row;
                        ind++;
                        if(row < n)
                        {
                            row++;
                        }
                        else
                        {
                            row = row - 1;
                        }
                    }
                    else if(row == n)
                    {
                        row = row - 1;
                    }
                    else
                    {
                        row++;
                    }
                }
            }

            return result;
        }
    }
}
