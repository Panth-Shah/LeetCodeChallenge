using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day19_KeysAndRooms
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            //BFS Solution
            int len = rooms.Count;
            bool[] visited = new bool[len];
            //Maintain all the key records for the room
            Queue<int> q = new Queue<int>();

            //Push room 0 which is already open
            q.Enqueue(0);

            while (q.Count != 0)
            {
                //Look up for the room key available in this room
                int roomIdx = q.Peek();
                q.Dequeue();
                //Mark room visited if you found key at this Index
                visited[roomIdx] = true;

                //Mark all the rooms visited for the keys available at current room
                foreach (var adjRooms in rooms[roomIdx])
                {
                    //adjRooms is a list of all the visible rooms from this room
                    if (!visited[adjRooms])
                    {
                        q.Enqueue(adjRooms);
                    }
                }
            }

            foreach (bool rVisited in visited)
            {
                if (!rVisited)
                    return false;
            }

            return true;
        }
    }
}
