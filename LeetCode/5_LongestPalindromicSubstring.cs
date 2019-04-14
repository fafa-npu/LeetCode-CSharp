namespace LeetCode
{
    public partial class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0)
            {
                return string.Empty;
            }

            if (s.Length == 1)
            {
                return s;
            }

            string result = string.Empty;
            int step = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (step = 0; i - step >= 0 && i + step < s.Length; step++)
                {
                    if (s[i-step] != s[i + step])
                    {
                        break;
                    }
                }

                if (step * 2 - 1 > result.Length)
                {
                    result = s.Substring(i - (step - 1), step * 2 - 1);
                }

                for (step = 0; i - step >= 0 && i + step + 1< s.Length; step++)
                {
                    if (s[i - step] != s[i + step + 1])
                    {
                        break;
                    }
                }

                if (step * 2 > result.Length)
                {
                    result = s.Substring(i - step + 1, step * 2);
                }
            }

            return result;
        }
    }
}