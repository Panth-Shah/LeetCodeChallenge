﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day23_3SumWithMultiplicity
    {
        //Time: O(N^2)
        //Space: O(N)
        public int ThreeSumMulti(int[] A, int target)
        {
            int MOD = 1_000_000_007;

            // Initializing as long saves us the trouble of
            // managing count[x] * count[y] * count[z] overflowing later.
            long[] count = new long[101];
            int uniq = 0;
            foreach(int x in A)
            {
                count[x]++;
                if (count[x] == 1)
                    uniq++;
            }

            int[] keys = new int[uniq];
            int t = 0;
            for (int i = 0; i <= 100; ++i)
                if (count[i] > 0)
                    keys[t++] = i;

            long ans = 0;
            // Now, let's do a 3sum on "keys", for i <= j <= k.
            // We will use count to add the correct contribution to ans.

            for (int i = 0; i < keys.Length; ++i)
            {
                int x = keys[i];
                int T = target - x;
                int j = i, k = keys.Length - 1;
                while (j <= k)
                {
                    int y = keys[j], z = keys[k];
                    if (y + z < T)
                    {
                        j++;
                    }
                    else if (y + z > T)
                    {
                        k--;
                    }
                    else
                    {  // # x+y+z == T, now calc the size of the contribution
                        if (i < j && j < k)
                        {
                            ans += count[x] * count[y] * count[z];
                        }
                        else if (i == j && j < k)
                        {
                            ans += count[x] * (count[x] - 1) / 2 * count[z];
                        }
                        else if (i < j && j == k)
                        {
                            ans += count[x] * count[y] * (count[y] - 1) / 2;
                        }
                        else
                        {  // i == j == k
                            ans += count[x] * (count[x] - 1) * (count[x] - 2) / 6;
                        }

                        ans %= MOD;
                        j++;
                        k--;
                    }
                }
            }

            return (int)ans;
        }
    }
}