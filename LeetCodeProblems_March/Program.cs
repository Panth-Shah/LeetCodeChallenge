using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1_DistributeCandies d1 = new Day1_DistributeCandies();
            //d1.DistributeCandies(new int[] { 1,1,2,2,3,3});

            //Day6_ShortEncodingOfWords d6 = new Day6_ShortEncodingOfWords();
            //d6.Trie_MinimumLengthEncoding(new string[] { "time","me","bell"});

            //Day8_RemovePalindromicSubsequence d8 = new Day8_RemovePalindromicSubsequence();
            //d8.RemovePalindromeSub("aaaaabaaaab");

            //Day12_StringContainsAllBinaryCodes d12 = new Day12_StringContainsAllBinaryCodes();
            //d12.HasAllCodes("00110011",3);

            Day20_DesignUndergroundSystem undergroundSystem = new Day20_DesignUndergroundSystem();
            undergroundSystem.CheckIn(10, "Leyton", 3);
            undergroundSystem.CheckOut(10, "Paradise", 8);
            undergroundSystem.GetAverageTime("Leyton", "Paradise"); // return 5.00000
            undergroundSystem.CheckIn(5, "Leyton", 10);
            undergroundSystem.CheckOut(5, "Paradise", 16);
            undergroundSystem.GetAverageTime("Leyton", "Paradise"); // return 5.50000
            undergroundSystem.CheckIn(2, "Leyton", 21);
            undergroundSystem.CheckOut(2, "Paradise", 30);
            undergroundSystem.GetAverageTime("Leyton", "Paradise"); // return 6.66667
        }
    }
}
