using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_January
{
    public class Day23_SortMatricDiagonally
    {
        public int[][] DiagonalSort(int[][] mat)
        {
            int rowCount = mat.Length;
            int columnCount = mat[0].Length;
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    int diagonalKey = i - j;
                    if (!map.ContainsKey(diagonalKey))
                    {
                        map.Add(diagonalKey, new List<int>());
                    }
                    map[diagonalKey].Add(mat[i][j]);
                }
            }

            foreach (var ele in map)
            {
                ele.Value.Sort();
            }

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    int diagonalKey = i - j;
                    mat[i][j] = map[i - j][0];
                    map[i - j].RemoveAt(0);
                }
            }

            return mat;
        }
    }
}
