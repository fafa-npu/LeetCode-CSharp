using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> valuePosPairs = new Dictionary<int, int>();

            for(int pos = 0; pos < nums.Length; pos++)
            {
                if (valuePosPairs.ContainsKey(target - nums[pos]))
                {
                    return new int[] {valuePosPairs[target - nums[pos]], pos};
                }
                else if (!valuePosPairs.ContainsKey(nums[pos]))
                {
                    valuePosPairs.Add(nums[pos], pos);
                }
            }

            return new int[] { };
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            ListNode head = result;
            int carry = 0;

            while(l1 != null || l2 != null)
            {
                var current = carry;
                if (l1 != null)
                {
                    current += l1.val;
                    l1 = l1.next;
                }

                if( l2 != null)
                {
                    current += l2.val;
                    l2 = l2.next;
                }

                if (current >= 10)
                {
                    current -= 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }

                result.next = new ListNode(current);

                result = result.next;
            }

            if(carry == 1)
            {
                result.next = new ListNode(1);
            }

            return head.next;
        }

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

        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
            {
                return string.Empty;
            }

            if (s.Length == 1)
            {
                return s;
            }

            string result = string.Empty;
            int step = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (step = 0; i - step >= 0 && i + step < s.Length; step++)
                {
                    if (s[i-step] != s[i + step])
                    {
                        break;
                    }
                }

                if (step * 2 - 1 > result.Length)
                {
                    result = s.Substring(i - (step - 1), step * 2 - 1);
                }

                for (step = 0; i - step >= 0 && i + step + 1< s.Length; step++)
                {
                    if (s[i - step] != s[i + step + 1])
                    {
                        break;
                    }
                }

                if (step * 2 > result.Length)
                {
                    result = s.Substring(i - step + 1, step * 2);
                }
            }

            return result;
        }

        public string Convert(string s, int numRows)
        {
            string result = string.Empty;

            if (numRows == 1)
            {
                return s;
            }

            int[] pos = new int[s.Length];

            int point = 0;
            int distance = (numRows - 1) * 2;

            for (int row = 0; row < numRows; row++)
            {
                for (int step = row; step < s.Length; step += distance)
                {
                    pos[point++] = step;

                    if (row != 0 && row != numRows - 1 && step + distance - row * 2 < s.Length)
                    {
                        pos[point++] = step + distance - row * 2;
                    }
                }
            }

            foreach(var index in pos)
            {
                result += s[index];
            }

            return result;
        }
    }
}
