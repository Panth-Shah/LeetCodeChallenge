using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day10_IntToRoman
    {
        private static int[] val = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static String[] rom = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public string intToRoman(int N)
        {
            StringBuilder ans = new StringBuilder();
            for (int i = 0; N > 0; i++)
                while (N >= val[i])
                {
                    ans.Append(rom[i]);
                    N -= val[i];
                }
            return ans.ToString();
        }
    }
}
