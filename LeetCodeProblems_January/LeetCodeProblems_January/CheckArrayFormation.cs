using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    //Problem Statement:
    //You are given an array of distinct integers arr and an array of integer arrays pieces, where the integers in pieces are distinct.Your goal is to form arr by concatenating the arrays in pieces in any order.However, you are not allowed to reorder the integers in each array pieces[i].
    //Return true if it is possible to form the array arr from pieces. Otherwise, return false.
    public class CheckArrayFormation
    {
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            int n = arr.Length;
            Dictionary<int, int[]> map = new Dictionary<int, int[]>();
            foreach(var element in pieces)
            {
                map.Add(element[0], element);
            }
            int i = 0;
            for (; i < n; i++)
            {
                if (map.ContainsKey(arr[i]))
                {
                    int[] piece = map[arr[i]];
                    foreach(int ele in piece)
                    {
                        if (ele == arr[i] && i < n)
                        {
                            i++;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                i--;
            }
            return true;
        }
    }
}
