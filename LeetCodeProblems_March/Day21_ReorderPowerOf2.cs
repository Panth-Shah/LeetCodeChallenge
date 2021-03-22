using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day21_ReorderPowerOf2
    {
        public bool ReorderedPowerOf2(int N)
        {
            // Count N digits
            int[] ndig = new int[10];
            string strN = N.ToString();
            for (int j = 0; j < strN.Length; j++)
            {
                ndig[strN[j] - '0']++;
            }



            // Count Power of 2 digits
            int P = 1;
            for (int i = 0; i < 30; i++)
            {
                int[] dig = new int[10];
                for (int j = 0; j < 10; j++) dig[j] = ndig[j];

                if (i > 0) P = 2 * P;
                string strP = P.ToString();
                if (strP.Length != strN.Length) continue;
                bool isgood = true;
                for (int j = 0; j < strP.Length; j++)
                {
                    if (dig[strP[j] - '0'] > 0)
                    {
                        dig[strP[j] - '0']--;
                        // Console.WriteLine("dig " + strP[j] + " dig count " + dig[strP[j] - '0']);
                    }
                    else
                    {
                        isgood = false;
                    }
                }
                if (!isgood) continue;
                return true;
            }
            return false;
        }
    }
}
