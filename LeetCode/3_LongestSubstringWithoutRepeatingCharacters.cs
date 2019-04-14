using System.Collections.Generic;

namespace LeetCode
{
    public partial class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> charPosPairs = new Dictionary<char, int>();

            int maxLength = 0;

            int p1 = 0, p2 = 0;

            List<char> removeKeys = new List<char>();
            
            while(p2 < s.Length)
            {
                if(!charPosPairs.ContainsKey(s[p2]) || charPosPairs[s[p2]] == -1)
                {
                    charPosPairs[s[p2]] = p2;
                    if (p2 - p1 + 1 > maxLength)
                    {
                        maxLength = p2 - p1 + 1;
                    }

                    p2++;
                }
                else
                {
                    removeKeys.Clear();
                    foreach(var key in charPosPairs.Keys)
                    {
                        if(charPosPairs[key] <= p1)
                        {
                            removeKeys.Add(key);
                        }
                    }

                    foreach(var key in removeKeys)
                    {
                        charPosPairs[key] = -1;
                    }

                    p1++;
                }
            }

            return maxLength;
        }
    }
}