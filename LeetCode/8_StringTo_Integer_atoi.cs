namespace LeetCode
{
    public partial class Solution
    {
        public int MyAtoi(string str)
        {
            int result = 0;
            bool isPos = true;
            int index = 0;

            str = str.Trim();
            if (str == string.Empty)
            {
                return 0;
            }

            if (!char.IsDigit(str[0]) && str[0] != '+' && str[0] != '-')
            {
                return 0;
            }

            if (str[0] == '+')
            {
                isPos = true;
                index++;
            }
            else if (str[0] == '-')
            {
                isPos = false;
                index++;
            }

            while(index < str.Length && char.IsDigit(str[index]))
            {
                int curDigit = (int)(char.GetNumericValue(str[index]));

                // For multiply operation, divide the multiplier to verify overflow
                // For add operation, check if it is overflow through the symbol sign(+/-)
                if (result * 10 / 10 == result && result * 10 + curDigit >= result * 10)  
                {
                    result = result * 10 + curDigit;
                    index++;
                }
                else
                {
                    if (isPos)
                    {
                        return int.MaxValue;
                    }
                    else
                    {
                        return int.MinValue;
                    }
                }
            }

            return isPos ? result : -result;
        }
    }
}