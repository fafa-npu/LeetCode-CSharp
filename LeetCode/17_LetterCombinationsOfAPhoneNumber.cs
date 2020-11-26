using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    public partial class Solution
    {
        private readonly Dictionary<char, string> dics = new Dictionary<char, string>
        {
            {'2', "abc" },
            {'3', "def" },
            {'4', "ghi" },
            {'5', "jkl" },
            {'6', "mno" },
            {'7', "pqrs" },
            {'8', "tuv" },
            {'9', "wxyz"}
        };

        public IList<string> LetterCombinations(string digits)
        {
            var results = new List<string>();

            if (!string.IsNullOrEmpty(digits))
            {
                results.Add("");
            }

            foreach(char digit in digits)
            {
                var tmps = new List<string>();

                foreach (char ch in dics[digit])
                {
                    foreach(var result in results)
                    {
                        tmps.Add(result + ch);
                    }

                }
                results = tmps;

            }

            return results;
        }
    }
}
