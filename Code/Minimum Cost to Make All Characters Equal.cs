namespace Code
{
    /// <summary>
    /// 2712. Minimum Cost to Make All Characters Equal
    /// 2712. 使所有字符相等的最小成本
    /// 
    /// You are given a 0-indexed binary string s of length n on which you can apply two types of operations:
    /// 给你一个下标从 0 开始、长度为 n 的二进制字符串 s ，你可以对其执行两种操作：
    /// 
    /// * Choose an index i and invert all characters from index 0 to index i (both inclusive), with a cost of i + 1
    /// * 选中一个下标 i 并且反转从下标 0 到下标 i（包括下标 0 和下标 i ）的所有字符，成本为 i + 1 。
    /// 
    /// * Choose an index i and invert all characters from index i to index n - 1 (both inclusive), with a cost of n - i
    /// * 选中一个下标 i 并且反转从下标 i 到下标 n - 1（包括下标 i 和下标 n - 1 ）的所有字符，成本为 n - i 。
    /// 
    /// Return the minimum cost to make all characters of the string equal.
    /// 返回使字符串内所有字符 相等 需要的 最小成本 。
    /// 
    /// Invert a character means if its value is '0' it becomes '1' and vice-versa.
    /// 反转 字符意味着：如果原来的值是 '0' ，则反转后值变为 '1' ，反之亦然。
    /// 
    /// </summary>
    public class Minimum_Cost_to_Make_All_Characters_Equal
    {
        public long MinimumCost(string s)
        {
            int n = s.Length;
            int m = s.Length >> 1;
            char l = s[0];
            char r = s[n - 1];
            long ans = 0;
            for (var i = 1; i < m; i++)
            {
                if (s[i] != l)
                {
                    ans += i;
                    l = s[i];
                }
            }

            for (var i = n - 2; i >= n - m; i--)
            {
                if (s[i] != r)
                {
                    ans += n - i - 1;
                    r = s[i];
                }
            }

            if (n % 2 == 1)
            {
                if (s[m] != l) ans += m;
                if (s[m] != r) ans += m;
            }
            else
            {
                if (l != r) ans += m;
            }

            return ans;
        }


        /// <summary>
        /// 动态规划
        /// suf[i][0] 表示从第 i 个字符开始的后缀全部变成 0 所需要的最小成本，pre类似
        /// suf[i][1] 表示从第 i 个字符的后缀全部变成 1 所需的最小成本，pre类似
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long MinimumCost2(string s)
        {
            int n = s.Length;
            long[,] suf = new long[n + 1, 2];
            for (int i = n - 1; i >= 0; i--)
            {
                if (s[i] == '1')
                {
                    suf[i, 1] = suf[i + 1, 1];
                    suf[i, 0] = suf[i + 1, 1] + (n - i);
                }
                else
                {
                    suf[i, 1] = suf[i + 1, 0] + (n - i);
                    suf[i, 0] = suf[i + 1, 0];
                }
            }

            long[] pre = new long[2];
            long res = long.MaxValue;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '1')
                {
                    pre[0] = pre[1] + i + 1;
                }
                else
                {
                    pre[1] = pre[0] + i + 1;
                }
                res = Math.Min(res, Math.Min(pre[0] + suf[i + 1, 0], pre[1] + suf[i + 1, 1]));
            }
            return res;
        }
    }
}
