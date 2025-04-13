namespace Code
{
    /// <summary>
    /// 1922. Count Good Numbers
    /// 1922. 统计好数字的数目
    /// 
    /// A digit string is good if the digits (0-indexed) at even indices are even and the digits at odd indices are prime (2, 3, 5, or 7).
    /// 我们称一个数字字符串是 好数字 当它满足（下标从 0 开始）偶数 下标处的数字为 偶数 且 奇数 下标处的数字为 质数 （2，3，5 或 7）。
    /// 
    /// * For example, "2582" is good because the digits (2 and 8) at even positions are even and the digits (5 and 2) at odd positions are prime. However, "3245" is not good because 3 is at an even index but is not even.
    /// * 比方说，"2582" 是好数字，因为偶数下标处的数字（2 和 8）是偶数且奇数下标处的数字（5 和 2）为质数。但 "3245" 不是 好数字，因为 3 在偶数下标处但不是偶数。
    /// 
    /// Given an integer n, return the total number of good digit strings of length n. Since the answer may be large, return it modulo Math.Pow(10,9) + 7.
    /// 给你一个整数 n ，请你返回长度为 n 且为好数字的数字字符串 总数 。由于答案可能会很大，请你将它对 Math.Pow(10,9) + 7 取余后返回 。
    /// 
    /// A digit string is a string consisting of digits 0 through 9 that may contain leading zeros.
    /// 一个 数字字符串 是每一位都由 0 到 9 组成的字符串，且可能包含前导 0 。
    /// 
    /// </summary>
    public class Count_Good_Numbers
    {
        long mod = 1000000007;

        /// <summary>
        /// 快速幂
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountGoodNumbers(long n)
        {
            return (int)(Quickmul(5, (n + 1) / 2) * Quickmul(4, n / 2) % mod);
        }

        // 快速幂求出 x^y % mod
        private long Quickmul(int x, long y)
        {
            long ret = 1;
            long mul = x;
            while (y > 0)
            {
                if (y % 2 == 1)
                {
                    ret = ret * mul % mod;
                }
                mul = mul * mul % mod;
                y /= 2;
            }

            return ret;
        }
    }
}
