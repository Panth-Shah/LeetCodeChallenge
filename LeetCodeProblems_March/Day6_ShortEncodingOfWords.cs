using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day6_ShortEncodingOfWords
    {
        //Approach1
        public int A1_MinimumLengthEncoding(string[] words)
        {
            Array.Sort(words, (string a, string b) => b.Length - a.Length);
            StringBuilder sb = new StringBuilder();
            foreach(string s in words)
            {
                if (sb.ToString().IndexOf(s+"#") == -1)
                {
                    sb.Append(s+"#");
                }
            }
            return sb.Length;
        }

        //Approach 2: Trie
        public int Trie_MinimumLengthEncoding(string[] words)
        {
            Trie root = new Trie();
            root.next = new Trie[26];
            int length = 0;
            foreach (string s in words)
            {
                length += TrieHelper(s, root);
            }
            return length;
        }

        private int TrieHelper(string s, Trie node)
        {
            //Either create new Branch or new level
            bool newBranch = false;
            //Find if new node is created
            int create = 0;
            //With every character from reverse, you need to find if it will create new branch or not
            //Start iterating from the end
            for (int i = s.Length - 1; i>=0; i--)
            {
                bool newLevel = false;
                //Index where to store this trie node in the array
                int id = s[i] - 'a';
                //Find if Level exist in the array
                if (node.next == null)
                {
                    newLevel = true;
                    node.next = new Trie[26];
                }
                //Find if character at the index exist in the array
                if (node.next[id] == null)
                {
                    //If new level is not created, new branching must have occured
                    if (newLevel == false) newBranch = true;
                    node.next[id] = new Trie();
                    create++;
                }
                node = node.next[id];
            }
            //Return length of new branch or number of branches created
            return newBranch ? s.Length + 1 : create;
        }
    }

    public class Trie
    {
        public Trie[] next = null;
    }
}
