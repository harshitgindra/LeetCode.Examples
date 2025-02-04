using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Problems._2021.March
{
    class Keys_and_Rooms
    {
        /// <summary>
        /// https://leetcode.com/problems/keys-and-rooms/solution/
        /// </summary>
        /// <param name="rooms"></param>
        /// <returns></returns>
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            //***
            //*** Create a new array of bool to store room opened status
            //***
            bool[] visited = new bool[rooms.Count];
            visited[0] = true;
            //***
            //*** As room 0 is already open, push it to the stack
            //***
            Stack<int> s = new Stack<int>();
            s.Push(0);
            //***
            //*** Iterate through the stack until it is empty
            //***
            while (s.Count != 0)
            {
                //***
                //*** Pop the last entry from the stack and mark it visited
                //***
                int i = s.Pop();
                visited[i] = true;

                foreach (int r in rooms[i])
                {
                    //***
                    //*** If the room is not visited, push it to the stack
                    //***
                    if (!visited[r])
                    {
                        s.Push(r);
                    }
                }
            }
            //***
            //*** Return true if all entries in the array are true
            //***
            return visited.All(v => v);
        }
    }
}
