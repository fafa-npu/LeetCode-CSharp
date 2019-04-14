namespace LeetCode
{
    public partial class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            string result = string.Empty;
            int distance = (numRows - 1) * 2;

            for (int row = 0; row < numRows; row++)
            {
                for (int step = row; step < s.Length; step += distance)
                {
                    result += s[step];

                    if (row != 0 && row != numRows - 1 && step + distance - row * 2 < s.Length)
                    {
                        result += s[step + distance - row * 2];
                    }
                }
            }

            return result;
        }
    }
}