using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_June
{
    //N - number of engineers
    //K - size of the team
    //Time complexity: O(N Log(N))
    //Space complexity: O(K)
    public class Day5_MaxPerformanceOfTeam
    {
        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            int mod = 1000000007;
            var engineers = new List<Engineer>();
            for (int i = 0; i < n; i++)
                engineers.Add(new Engineer(speed[i], efficiency[i]));

            engineers.Sort((x, y) => y.efficiency.CompareTo(x.efficiency));

            var minHeap = new MinHeap();
            long maxperformance = long.MinValue;
            long teamspeed = 0;
            foreach (Engineer engineer in engineers)
            {
                if (minHeap.Count == k)
                {
                    Engineer lowest = minHeap.Poll();
                    teamspeed -= lowest.speed;
                }
                minHeap.Insert(engineer);
                teamspeed += engineer.speed;
                maxperformance = Math.Max(maxperformance, teamspeed * engineer.efficiency);
            }

            return (int)(maxperformance % mod);
        }

        public class Engineer
        {
            public int speed;
            public int efficiency;
            public Engineer(int speed, int efficiency)
            {
                this.speed = speed;
                this.efficiency = efficiency;
            }
        }

        public class MinHeap
        {
            private List<Engineer> A;
            public int Count => A.Count - 1;
            public MinHeap()
            {
                A = new List<Engineer>();
                A.Add(default(Engineer));
            }

            public void Heapify(int i)
            {
                int l = i * 2;
                int r = i * 2 + 1;
                int largest = i;
                if (l <= Count && A[l].speed < A[largest].speed)
                    largest = l;
                if (r <= Count && A[r].speed < A[largest].speed)
                    largest = r;
                if (largest != i)
                {
                    Swap(i, largest);
                    Heapify(largest);
                }
            }

            public void Insert(Engineer engineer)
            {
                A.Add(engineer);
                A[Count] = engineer;
                int i = Count;
                while (i > 1 && A[i].speed < A[i / 2].speed)
                {
                    Swap(i, i / 2);
                    i = i / 2;
                }
            }

            public Engineer Peek()
            {
                return A[1];
            }

            public Engineer Poll()
            {
                Engineer top = A[1];
                A[1] = A[Count];
                A.RemoveAt(Count);
                Heapify(1);
                return top;
            }

            private void Swap(int i, int j)
            {
                Engineer t = A[i];
                A[i] = A[j];
                A[j] = t;
            }
        }
    }
}
