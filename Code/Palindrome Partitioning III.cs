namespace Code
{
    /// <summary>
    /// 1278. Palindrome Partitioning III
    /// 
    /// You are given a string s containing lowercase letters and an integer k. You need to :
    /// 给定一个包含小写字母的字符串 s 和一个整数 k。你需要：
    /// 
    /// * First, change some characters of s to other lowercase English letters.
    /// * 首先，将 s 中的一些字符更改为其他小写英文字母。
    /// 
    /// * Then divide s into k non-empty disjoint substrings such that each substring is a palindrome.
    /// * 然后将 s 分成 k 个非空的不相交子字符串，使得每个子字符串都是回文。
    /// 
    /// Return the minimal number of characters that you need to change to divide the string.
    /// 返回划分字符串所需更改的最少字符数。
    /// 
    /// </summary>
    public class Palindrome_Partitioning_III
    {

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int PalindromePartition(string s, int k)
        {
            int n = s.Length;

            // f[i,j] 表示对于字符串 S 的前 i 个字符，将它分割成 j 个非空且不相交的回文串，最少需要修改的字符数。
            int[,] f = new int[n + 1, k + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= k; j++)
                {
                    f[i, j] = int.MaxValue;
                }
            }
            f[0, 0] = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= Math.Min(k, i); j++)
                {
                    if (j == 1)
                    {
                        f[i, j] = Cost(0, i - 1, s);
                    }
                    else
                    {
                        for (int i0 = j - 1; i0 < i; i0++)
                        {
                            // 状态转移方程
                            f[i, j] = Math.Min(f[i, j], f[i0, j - 1] + Cost(i0, i - 1, s));
                        }
                    }
                }
            }

            return f[n, k];
        }

        /// <summary>
        /// 将 S 的第 l 个到第 r 个字符组成的子串变成回文串，最少需要修改的字符数
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private int Cost(int l, int r, string s)
        {
            int ret = 0;
            int i = l, j = r;
            while (i < j)
            {
                ret += (s[i] == s[j] ? 0 : 1);
                i++;
                j--;
            }
            return ret;
        }

        /// <summary>
        /// 动态规划 + 预处理
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int PalindromePartition2(string s, int k)
        {
            int n = s.Length;

            // cost[i,j] 表示将 S 的第 i 个到第 j 个字符组成的子串变成回文串，最少需要修改的字符数
            int[,] cost = new int[n, n];
            for (int span = 2; span <= n; ++span)
            {
                for (int i = 0; i <= n - span; ++i)
                {
                    int j = i + span - 1;
                    cost[i, j] = cost[i + 1, j - 1] + (s[i] == s[j] ? 0 : 1);
                }
            }

            // f[i,j] 表示对于字符串 S 的前 i 个字符，将它分割成 j 个非空且不相交的回文串，最少需要修改的字符数。
            int[,] f = new int[n + 1, k + 1];
            for (int i = 0; i <= n; ++i)
            {
                for (int j = 0; j <= k; ++j)
                {
                    f[i, j] = int.MaxValue;
                }
            }
            f[0, 0] = 0;
            for (int i = 1; i <= n; ++i)
            {
                for (int j = 1; j <= Math.Min(k, i); ++j)
                {
                    if (j == 1)
                    {
                        f[i, j] = cost[0, i - 1];
                    }
                    else
                    {
                        for (int i0 = j - 1; i0 < i; ++i0)
                        {
                            // 状态转移方程
                            f[i, j] = Math.Min(f[i, j], f[i0, j - 1] + cost[i0, i - 1]);
                        }
                    }
                }
            }
            return f[n, k];
        }
    }
}
