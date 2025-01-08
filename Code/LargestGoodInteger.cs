namespace Code
{
    /// <summary>
    /// 2264. Largest 3-Same-Digit Number in String
    /// 
    /// You are given a string num representing a large integer. An integer is good if it meets the following conditions:
    /// 给定一个表示大整数的字符串num 。如果满足以下条件，则整数是正确的：
    /// 
    /// It is a substring of num with length 3.
    /// 它是num的子字符串，长度为3 。
    /// 
    /// It consists of only one unique digit.
    /// 它仅由一个唯一的数字组成。
    /// 
    /// Return the maximum good integer as a string or an empty string "" if no such integer exists.
    /// 返回最大的正确整数作为字符串，如果不存在这样的整数，返回空字符串。
    /// 
    /// Note: 笔记：
    /// 
    /// A substring is a contiguous sequence of characters within a string.
    /// 子字符串是字符串中连续的字符序列。
    /// 
    /// There may be leading zeroes in num or a good integer.
    /// num中可能有前导零或一个好的整数。
    /// 
    /// </summary>
    public class LargestGoodInteger
    {
        /// <summary>
        /// 遍历字符串，统计数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string Solution(string num)
        {
            int n = 0;
            string ans = "";

            for (var i = 1; i < num.Length; i++)
            {
                if (num[i] == num[i - 1])
                {
                    n++;
                    if (n == 2)
                    {
                        if (ans == "" || ans[0] < num[i])
                        {
                            ans = num.Substring(i - 2, 3);
                        }
                    }
                }
                else
                {
                    n = 0;
                }
            }

            return ans;
        }

        /// <summary>
        /// 遍历字符串，直接查询连续三个相同的字符
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string Solution2(string num)
        {
            char max = '\0';
            for (int i = 0; i < num.Length - 2; i++)
            {
                if (num[i] == num[i + 1] && num[i] == num[i + 2] && max < num[i])
                    max = num[i];
            }
            if (max == 0)
                return "";
            else
                return $"{max}{max}{max}";
        }
    }
}
