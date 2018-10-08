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
    }
}
