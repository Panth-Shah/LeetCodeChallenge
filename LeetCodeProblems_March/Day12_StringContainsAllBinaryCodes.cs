using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    //Problem: 1461
    public class Day12_StringContainsAllBinaryCodes
    {
        public bool HasAllCodes(string s, int k)
        {
            int n = 1 << k;//1000
            int bitmask = n - 1;//111
            int hashValue = 0;
            bool[] found = new bool[n];

            for (int i = 0; i < s.Length; i++)
            {
                //current bit
                int bit = s[i] - '0';

                //remove last bit
                //shift left by 1
                hashValue <<= 1;
                hashValue = hashValue & bitmask;

                hashValue = hashValue | bit;

                if (i >= k - 1 && !found[hashValue])
                {
                    found[hashValue] = true;
                    n--;

                    if (n == 0)
                        return true;
                }
            }
            return false;
        }
    }
}
