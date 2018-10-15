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
                sln.MyAtoi("-6147483648");
            sln.MyAtoi("42");
            sln.MyAtoi("2147483648");
            sln.MyAtoi(" -91283472332");
        }
    }
}
