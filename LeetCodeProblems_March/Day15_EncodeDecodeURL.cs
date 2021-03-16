using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems_March
{
    public class Day15_EncodeDecodeURL
    {
        //535. Encode and Decode TinyURL
        public class Codec
        {
            Dictionary<int, string> dic;
            const string baseURL = "http://tinyurl.com/";

            public Codec()
            {
                this.dic = new Dictionary<int, string>();
            }
            // Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                var key = longUrl.GetHashCode();
                dic.Add(key, longUrl);
                return baseURL + key;
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                var url = shortUrl.Replace(baseURL, "");
                var urlKey = int.Parse(url);
                return dic[urlKey];
            }
        }
    }
}
