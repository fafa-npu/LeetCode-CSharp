using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace LeetCode
{
    /**************************************************************************************************************************
     * 
     Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
            Notice that the solution set must not contain duplicate triplets.

        Example 1:

        Input: nums = [-1, 0, 1, 2, -1, -4]
            Output: [[-1,-1,2], [-1,0,1]]
        Example 2:

        Input: nums = []
            Output: []
            Example 3:

        Input: nums = [0]
            Output: []


            Constraints:

        0 <= nums.length <= 3000
        -105 <= nums[i] <= 105
        Accepted
    **************************************************************************/
    public partial class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var results = new List<IList<int>>();
            Array.Sort(nums);

            for(int i = 0; i < nums.Length - 2; i++)
            {
                int pLeft = i + 1;
                int pRight = nums.Length - 1;

                int target = -nums[i];

                while (pLeft < pRight)
                {
                    if (nums[pLeft] + nums[pRight] > target)
                    {
                        pRight--;
                    }
                    else if (nums[pLeft] + nums[pRight] < target)
                    {
                        pLeft++;
                    }
                    else
                    {
                        results.Add(new[] { nums[i], nums[pLeft], nums[pRight] });
                        while (pRight > pLeft && nums[pRight] == nums[pRight - 1])
                        {
                            pRight--;
                        }
                        pRight--;
                        while (pLeft < pRight && nums[pLeft] == nums[pLeft + 1])
                        {
                            pLeft++;
                        }
                        pLeft++;
                    }
                }

                while (i < nums.Length - 2 && nums[i] == nums[i + 1])
                {
                    i++;
                }
            }

            return results;

            //Dictionary<int, int> dic = new Dictionary<int, int>();
            //foreach(int num in nums)
            //{
            //    if (dic.ContainsKey(num))
            //    {
            //        dic[num] += 1;
            //    }
            //    else
            //    {
            //        dic.Add(num, 1);
            //    }
            //}

            //if (dic.ContainsKey(0) && dic[0] >= 3)
            //{
            //    results.Add(new[] { 0, 0, 0 });
            //}

            //var uniqNums = dic.Keys.ToArray<int>();
            //if (uniqNums.Length >= 2)
            //{
            //    Array.Sort(uniqNums);
            //    for (int i = 0; i < uniqNums.Length - 1; i++)
            //    {
            //        if (uniqNums[i] == 0)
            //        {
            //            continue;
            //        }

            //        int j = dic[uniqNums[i]] > 1 ? i : i + 1;

            //        for (; j < uniqNums.Length; j++)
            //        {
            //            int target = -(uniqNums[i] + uniqNums[j]);
            //            if (dic.ContainsKey(target) && (target >= uniqNums[j]))
            //            {
            //                if (target != uniqNums[j] || (target == uniqNums[j] && dic[target] > 1))
            //                {
            //                    results.Add(new[] { uniqNums[i], uniqNums[j], target });
            //                }
            //            }
            //        }
            //    }

            //}

            return results.ToList();
        }
    }
}
