using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public partial class Solution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);

            int result = 0;
            int currentDistance = int.MaxValue;

            for(int i = 0; i < nums.Length - 2; i++)
            {
                int pLeft = i + 1;
                int pRight = nums.Length - 1;

                while (pLeft < pRight)
                {
                    int sum = nums[i] + nums[pLeft] + nums[pRight];
                    if (sum == target)
                    {
                        return target;
                    }

                    int dis = Math.Abs(sum - target);
                    if (dis < currentDistance)
                    {
                        currentDistance = dis;
                        result = sum;
                    }

                    if (sum > target)
                    {
                        pRight--;
                    }
                    else
                    {
                        pLeft++;
                    }
                }
            }

            return result;
        }
    }
}
