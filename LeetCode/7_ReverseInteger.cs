namespace LeetCode
{
    public partial class Solution
    {
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
    }
}