using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePacticeQuestions
{
    public class Array_AvoidFlood
    {
        public static int[] AvoidFlood(int[] rains)
        {
            //Identify size of array when it rained
            //If rain[i] > 0 -> out[i] = -1
            //Two pointer approach
            int rainDays = rains.Length;
            int p1 = 0; //track rainy days
            int p2 = 0; //track non-raindy days
            int[] result = new int[rainDays];
            int fullLakeCount = 0;
            int daysItRain = 0;

            while (p2 < rainDays)
            {
                if (rains[p2] != 0)
                {
                    if (rains[p1] == 0)
                    {
                        p1 = p2;
                    }
                    while (rains[p2] != 0)
                    {
                        result[p2] = -1;
                        if (p2 == rainDays -1)
                        {
                            daysItRain++;
                            fullLakeCount++;
                            if (fullLakeCount == 0 || daysItRain % fullLakeCount == 0)
                            {
                                return result;
                            }
                            else
                            {
                                return new int[rainDays];
                            }
                        }
                        p2++;
                        fullLakeCount++;
                        daysItRain++;
                    }
                    result[p2] = rains[p1];
                    fullLakeCount--;
                    p2++;
                    p1++;
                }
                else
                {
                    if (rains[p1] != 0)
                    {
                        result[p2] = rains[p1];
                        fullLakeCount--;
                    }
                    else
                    {
                        result[p2] = 1;
                    }
                    p2++;
                    p1++;
                }
            }
            return result;
        }
    }
}
