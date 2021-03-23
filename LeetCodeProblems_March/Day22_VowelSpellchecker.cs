using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day22_VowelSpellchecker
    {
        //Time: O(WordLists + Queries)
        //Space: O(WordLists + Queries)
        public string[] spellchecker(string[] wordlist, string[] queries)
        {
            HashSet<string> exact = new HashSet<string>();
            Dictionary<string, string> caseInsensitive = new Dictionary<string, string>();
            Dictionary<string, string> consonant = new Dictionary<string, string>();
            string[] result = new string[queries.Length];


            foreach (string word in wordlist)
            {
                exact.Add(word);
                if (!caseInsensitive.ContainsKey(word.ToLower()))
                {
                    caseInsensitive.Add(word.ToLower(), word);
                }
                if (!consonant.ContainsKey(deVowel(word.ToLower())))
                {
                    consonant.Add(deVowel(word.ToLower()), word);
                }
            }
            int i = 0;
            foreach (string query in queries)
            {
                if (exact.Contains(query))
                    result[i] = query;
                else if (caseInsensitive.ContainsKey(query.ToLower()))
                    result[i] = caseInsensitive[query.ToLower()];
                else if (consonant.ContainsKey(deVowel(query.ToLower())))
                    result[i] = consonant[deVowel(query.ToLower())];
                else
                    result[i] = "";
                i++;
            }

            return result;
        }
        public string deVowel(string word)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in word.ToCharArray())
            {
                sb.Append(isVowel(c) ? '*' : c);
            }
            return sb.ToString();
        }

        public bool isVowel(char c)
        {
            return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
        }
    }
}
