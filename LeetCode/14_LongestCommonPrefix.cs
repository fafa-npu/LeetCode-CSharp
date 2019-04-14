namespace LeetCode {

using System;

    public partial class Solution {
        public string LongestCommonPrefix (string[] strs) {
            string comPrefix = string.Empty;

            if (strs.Length == 0) {
                return comPrefix;
            }

            comPrefix = strs[0];

            foreach (var str in strs) {
                var minLengthOfComparedStr = Math.Min (str.Length, comPrefix.Length);
                int comPreFixLength = 0;

                for (int index = 0; index < minLengthOfComparedStr;) {
                    if (str[index] == comPrefix[index]) {
                        comPreFixLength++;
                        index++;
                    } else {
                        break;
                    }
                }

                comPrefix = comPrefix.Substring (0, comPreFixLength);

                if (comPreFixLength == 0) {
                    break;
                }
            }

            return comPrefix;
        }
    }
}