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
    }
}
