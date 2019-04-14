using System;

namespace LeetCode
{
    public partial class Solution
    {
        public int MaxArea(int[] height)
        {
            int maxContainer = 0;
            int l = 0;
            int r = height.Length - 1;

            while (l < r)
            {
                maxContainer = Math.Max(maxContainer, (r - l) * Math.Min(height[l], height[r]));

                if (height[l] < height[r])
                {
                    l++;
                }else
                {
                    r--;
                }
            }

            return maxContainer;
        }
    }
}
