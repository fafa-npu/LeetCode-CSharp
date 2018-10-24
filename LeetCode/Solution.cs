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
            if (numRows == 1)
            {
                return s;
            }

            string result = string.Empty;
            int distance = (numRows - 1) * 2;

            for (int row = 0; row < numRows; row++)
            {
                for (int step = row; step < s.Length; step += distance)
                {
                    result += s[step];

                    if (row != 0 && row != numRows - 1 && step + distance - row * 2 < s.Length)
                    {
                        result += s[step + distance - row * 2];
                    }
                }
            }

            return result;
        }

        public int Reverse(int x)
        {
            if (x > 1000000000 && x % 10 > 2)
            {
                return 0;
            }

            int result = 0;
            bool isPos = true;
            int curNum = 0;
            int tempResult = 0;
            if (x < 0)
            {
                isPos = false;
                x = -x;
            }

            while (x != 0)
            {
                curNum = x % 10;
                tempResult = curNum + result * 10;
                if ((tempResult - curNum) / 10 != result)
                {
                    return 0;
                }

                result = tempResult;
                x /= 10;
            }

            if(!isPos && result > 0)
            {
                result = -result;
            }

            return result;
        }

        public int MyAtoi(string str)
        {
            int result = 0;
            bool isPos = true;
            int index = 0;

            str = str.Trim();
            if (str == string.Empty)
            {
                return 0;
            }

            if (!char.IsDigit(str[0]) && str[0] != '+' && str[0] != '-')
            {
                return 0;
            }

            if (str[0] == '+')
            {
                isPos = true;
                index++;
            }
            else if (str[0] == '-')
            {
                isPos = false;
                index++;
            }

            while(index < str.Length && char.IsDigit(str[index]))
            {
                int curDigit = (int)(char.GetNumericValue(str[index]));

                // For multiply operation, divide the multiplier to verify overflow
                // For add operation, check if it is overflow through the symbol sign(+/-)
                if (result * 10 / 10 == result && result * 10 + curDigit >= result * 10)  
                {
                    result = result * 10 + curDigit;
                    index++;
                }
                else
                {
                    if (isPos)
                    {
                        return int.MaxValue;
                    }
                    else
                    {
                        return int.MinValue;
                    }
                }
            }

            return isPos ? result : -result;
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            int length = 0;

            while (x / (int)Math.Pow(10, length) != 0)
            {
                length++;
            }

            int leftSide = x / (int)(Math.Pow(10, (length + 1) / 2));
            int rightSide = x % (int)(Math.Pow(10, length / 2));

            int reverseRight = 0;
            for (int i = 0; i < length / 2; i++)
            {
                reverseRight = reverseRight * 10 + rightSide % 10;
                rightSide /= 10;
            }

            return leftSide == reverseRight;
        }
    }
}
