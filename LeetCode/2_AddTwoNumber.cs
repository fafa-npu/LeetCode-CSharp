namespace LeetCode
{
    public partial class Solution
    {
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