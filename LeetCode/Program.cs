using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sln = new Solution();
            string[] strs = {"dog","racecar","car"};
            int[] nums = { -1,0,1,2,-1,-4    };

            var results = sln.ThreeSum(nums);
            Console.WriteLine("hello world");
        }
    }
}