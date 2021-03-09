using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    //Design a HashMap without using any BuiltIn hash table libraries
    //put(key, value): Insert a (key,value) pair into the Hashmap. If the value already exist in the HashMap, update the value
    //get(key): Return the value to which the specified key is mapped, or -1 if this map containes no mapping for the key
    //remove(key): Remove the mapping for the value key if the map contains the mapping for the key
    public class MyHashMap
    {
        private string[] names;

        /** Initialize your data structure here. */
        public MyHashMap()
        {
            names = new string[10007];
        }
        private void betterHash(string s)
        {
            long tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            byte[] asciiBytes = Encoding.ASCII.GetBytes(cname);

            //for (int i = 0; i <= cname.GetUpperBound(0); i++)
            //    tot += (int)cname[i];
            foreach (byte val in asciiBytes)
            {
                tot += 37 * tot + val;
            }
            tot = tot % names.Length;
            if (tot < 0)
            {
                tot += names.Length;
            }
            int hashValue = (int)tot;
            names[hashValue] = s;
        }

        ///** value will always be non-negative. */
        //public void Put(int key, int value)
        //{

        //}

        ///** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        //public int Get(int key)
        //{

        //}

        ///** Removes the mapping of the specified value key if this map contains a mapping for the key */
        //public void Remove(int key)
        //{

        //}
    }
}
