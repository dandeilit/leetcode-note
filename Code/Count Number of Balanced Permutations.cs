namespace Code
{
    /// <summary>
    /// 3343. Count Number of Balanced Permutations
    /// 3343. 统计平衡排列的数目
    /// 
    /// You are given a string num. A string of digits is called balanced if the sum of the digits at even indices is equal to the sum of the digits at odd indices.
    /// 给你一个字符串 num 。如果一个数字字符串的奇数位下标的数字之和与偶数位下标的数字之和相等，那么我们称这个数字字符串是 平衡的 。
    /// 
    /// Return the number of distinct permutations of num that are balanced.
    /// 请你返回 num 不同排列 中，平衡 字符串的数目。
    /// 
    /// Since the answer may be very large, return it modulo Math.Pow(10,9) + 7.
    /// 由于答案可能很大，请你将答案对 Math.Pow(10,9) + 7 取余 后返回。
    /// 
    /// A permutation is a rearrangement of all the characters of a string.
    /// 一个字符串的 排列 指的是将字符串中的字符打乱顺序后连接得到的字符串。
    /// 
    /// </summary>
    public class Count_Number_of_Balanced_Permutations
    {
        private const long MOD = 1_000_000_007;
        private long[,,] memo;
        private int[] cnt;
        private int[] psum;
        private int target;
        private long[,] comb;

        /// <summary>
        /// 记忆化搜索
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int CountBalancedPermutations(string num)
        {
            int tot = 0, n = num.Length;
            cnt = new int[10];
            foreach (char ch in num)
            {
                int d = ch - '0';
                cnt[d]++;
                tot += d;
            }
            if (tot % 2 != 0)
            {
                return 0;
            }

            target = tot / 2;
            int maxOdd = (n + 1) / 2;

            /* 预计算组合数 */
            comb = new long[maxOdd + 1, maxOdd + 1];
            for (int i = 0; i <= maxOdd; i++)
            {
                comb[i, i] = comb[i, 0] = 1;
                for (int j = 1; j < i; j++)
                {
                    comb[i, j] = (comb[i - 1, j] + comb[i - 1, j - 1]) % MOD;
                }
            }

            psum = new int[11];
            for (int i = 9; i >= 0; i--)
            {
                psum[i] = psum[i + 1] + cnt[i];
            }

            memo = new long[10, target + 1, maxOdd + 1];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= target; j++)
                {
                    for (int k = 0; k <= maxOdd; k++)
                    {
                        memo[i, j, k] = -1;
                    }
                }
            }

            return (int)Dfs(0, 0, maxOdd);
        }

        private long Dfs(int pos, int curr, int oddCnt)
        {
            /* 如果剩余位置无法合法填充，或者当前奇数位置元素和大于目标值 */
            if (oddCnt < 0 || psum[pos] < oddCnt || curr > target)
            {
                return 0;
            }
            if (pos > 9)
            {
                return (curr == target && oddCnt == 0) ? 1 : 0;
            }
            if (memo[pos, curr, oddCnt] != -1)
            {
                return memo[pos, curr, oddCnt];
            }
            /* 偶数位剩余需要填充的位数 */
            int evenCnt = psum[pos] - oddCnt;
            long res = 0;
            for (int i = Math.Max(0, cnt[pos] - evenCnt); i <= Math.Min(cnt[pos], oddCnt); i++)
            {
                /* 当前数字在奇数位填充 i 位，偶数位填充 cnt[pos] - i 位 */
                long ways = comb[oddCnt, i] * comb[evenCnt, cnt[pos] - i] % MOD;
                res = (res + ways * Dfs(pos + 1, curr + i * pos, oddCnt - i) % MOD) % MOD;
            }
            memo[pos, curr, oddCnt] = res;
            return res;
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int CountBalancedPermutations2(string num)
        {
            int tot = 0, n = num.Length;
            int[] cnt = new int[10];
            foreach (char ch in num)
            {
                int d = ch - '0';
                cnt[d]++;
                tot += d;
            }
            if (tot % 2 != 0)
            {
                return 0;
            }

            int target = tot / 2;
            int maxOdd = (n + 1) / 2;
            long[,] comb = new long[maxOdd + 1, maxOdd + 1];
            long[,] f = new long[target + 1, maxOdd + 1];

            for (int i = 0; i <= maxOdd; i++)
            {
                comb[i, i] = comb[i, 0] = 1;
                for (int j = 1; j < i; j++)
                {
                    comb[i, j] = (comb[i - 1, j] + comb[i - 1, j - 1]) % MOD;
                }
            }

            f[0, 0] = 1;
            int psum = 0, totSum = 0;
            for (int i = 0; i <= 9; i++)
            {
                /* 前 i 个数字的数目之和 */
                psum += cnt[i];
                /* 前 i 个数字的元素之和 */
                totSum += i * cnt[i];
                for (int oddCnt = Math.Min(psum, maxOdd); oddCnt >= Math.Max(0, psum - (n - maxOdd)); oddCnt--)
                {
                    /* 偶数位需要填充的位数 */
                    int evenCnt = psum - oddCnt;
                    for (int curr = Math.Min(totSum, target); curr >= Math.Max(0, totSum - target); curr--)
                    {
                        long res = 0;
                        for (int j = Math.Max(0, cnt[i] - evenCnt); j <= Math.Min(cnt[i], oddCnt) && i * j <= curr; j++)
                        {
                            /* 当前数字在奇数位填充 j 位，偶数位填充 cnt[i] - j 位 */
                            long ways = comb[oddCnt, j] * comb[evenCnt, cnt[i] - j] % MOD;
                            res = (res + ways * f[curr - i * j, oddCnt - j] % MOD) % MOD;
                        }
                        f[curr, oddCnt] = res % MOD;
                    }
                }
            }

            return (int)f[target, maxOdd];
        }
    }
}
