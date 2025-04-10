namespace Code
{
    /// <summary>
    /// 2999. Count the Number of Powerful Integers
    /// 2999. 统计强大整数的数目
    /// 
    /// You are given three integers start, finish, and limit. You are also given a 0-indexed string s representing a positive integer.
    /// 给你三个整数 start ，finish 和 limit 。同时给你一个下标从 0 开始的字符串 s ，表示一个 正 整数。
    /// 
    /// A positive integer x is called powerful if it ends with s (in other words, s is a suffix of x) and each digit in x is at most limit.
    /// 如果一个 正 整数 x 末尾部分是 s （换句话说，s 是 x 的 后缀），且 x 中的每个数位至多是 limit ，那么我们称 x 是 强大的 。
    /// 
    /// Return the total number of powerful integers in the range [start..finish].
    /// 请你返回区间 [start..finish] 内强大整数的 总数目 。
    /// 
    /// A string x is a suffix of a string y if and only if x is a substring of y that starts from some index (including 0) in y and extends to the index y.length - 1. For example, 25 is a suffix of 5125 whereas 512 is not.
    /// 如果一个字符串 x 是 y 中某个下标开始（包括 0 ），到下标为 y.length - 1 结束的子字符串，那么我们称 x 是 y 的一个后缀。比方说，25 是 5125 的一个后缀，但不是 512 的后缀。
    /// 
    /// </summary>
    public class Count_the_Number_of_Powerful_Integers
    {
        /// <summary>
        /// 组合数学
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="limit"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            string start_ = (start - 1).ToString();
            string finish_ = finish.ToString();
            return Calculate(finish_, s, limit) - Calculate(start_, s, limit);
        }

        /// <summary>
        /// 计算小于等于 x 的满足 limit 的数字数量
        /// </summary>
        /// <param name="x"></param>
        /// <param name="s"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private long Calculate(string x, string s, int limit)
        {
            if (x.Length < s.Length)
            {
                return 0;
            }
            if (x.Length == s.Length)
            {
                return string.Compare(x, s) >= 0 ? 1 : 0;
            }

            string suffix = x.Substring(x.Length - s.Length);
            long count = 0;
            int preLen = x.Length - s.Length;

            for (int i = 0; i < preLen; i++)
            {
                int digit = x[i] - '0';
                if (limit < digit)
                {
                    count += (long)Math.Pow(limit + 1, preLen - i);
                    return count;
                }
                count += (long)digit * (long)Math.Pow(limit + 1, preLen - 1 - i);
            }
            if (string.Compare(suffix, s) >= 0)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// 数位动态规划
        /// </summary>
        /// <param name="start"></param>
        /// <param name="finish"></param>
        /// <param name="limit"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public long NumberOfPowerfulInt2(long start, long finish, int limit, string s)
        {
            string low = start.ToString();
            string high = finish.ToString();
            int n = high.Length;
            low = low.PadLeft(n, '0'); // 对齐位数
            int pre_len = n - s.Length; // 前缀长度
            long[] memo = new long[n];
            Array.Fill(memo, -1);

            return Dfs(0, true, true, low, high, limit, s, pre_len, memo);
        }

        private long Dfs(int i, bool limitLow, bool limitHigh,
                    string low, string high, int limit, string s,
                    int preLen, long[] memo)
        {
            // 递归边界
            if (i == low.Length)
            {
                return 1;
            }
            if (!limitLow && !limitHigh && memo[i] != -1)
            {
                return memo[i];
            }
            int lo = limitLow ? low[i] - '0' : 0;
            int hi = limitHigh ? high[i] - '0' : 9;
            long res = 0;
            if (i < preLen)
            {
                for (int digit = lo; digit <= Math.Min(hi, limit); digit++)
                {
                    res += Dfs(i + 1, limitLow && digit == lo,
                              limitHigh && digit == hi,
                              low, high, limit, s, preLen, memo);
                }
            }
            else
            {
                int x = s[i - preLen] - '0';
                if (lo <= x && x <= Math.Min(hi, limit))
                {
                    res = Dfs(i + 1, limitLow && x == lo,
                             limitHigh && x == hi,
                             low, high, limit, s, preLen, memo);
                }
            }

            if (!limitLow && !limitHigh)
            {
                memo[i] = res;
            }
            return res;
        }
    }
}
