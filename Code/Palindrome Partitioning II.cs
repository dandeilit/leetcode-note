namespace Code
{
    /// <summary>
    /// 132. Palindrome Partitioning II
    /// 
    /// Given a string s, partition s such that every substring of the partition is a palindrome.
    /// 给定一个字符串 s，对 s 进行分区，使得分区的每个子字符串都是回文。
    /// 
    /// Return the minimum cuts needed for a palindrome partitioning of s.
    /// 返回对 s 进行回文分区所需的最小切割数。
    /// 
    /// </summary>
    public class Palindrome_Partitioning_II
    {
        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinCut(string s)
        {
            var n = s.Length;
            var f = new bool[n][];
            for (var i = 0; i < n; i++)
            {
                f[i] = new bool[n];
                Array.Fill(f[i], true);
            }

            for (var i = n - 1; i >= 0; --i)
            {
                for (var j = i + 1; j < n; ++j)
                {
                    f[i][j] = (s[i] == s[j]) && f[i + 1][j - 1];
                }
            }

            int[] ans = new int[n];
            Array.Fill(ans, int.MaxValue);
            for (int i = 0; i < n; ++i)
            {
                if (f[0][i])
                {
                    ans[i] = 0;
                }
                else
                {
                    for (int j = 0; j < i; ++j)
                    {
                        if (f[j + 1][i])
                        {
                            ans[i] = Math.Min(ans[i], ans[j] + 1);
                        }
                    }
                }
            }

            return ans[n - 1];
        }
    }
}
