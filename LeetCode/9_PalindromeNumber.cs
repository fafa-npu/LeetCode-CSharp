using System;

namespace LeetCode
{
    public partial class Solution
    {
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