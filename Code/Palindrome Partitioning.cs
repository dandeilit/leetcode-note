namespace Code
{
    /// <summary>
    /// 131. Palindrome Partitioning
    /// 
    /// Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.
    /// 给定一个字符串，分区s使得分区的每个子字符串都是回文。返回S的所有可能的回文分区。
    /// 
    /// </summary>
    public class Palindrome_Partitioning
    {
        bool[][] f; // f[i][j] 记录子串 s.Substring(i, j - i + 1) 是否为回文
        IList<IList<string>> ret = new List<IList<string>>();
        List<string> ans = new List<string>();
        int n;

        /// <summary>
        /// 回溯 + 动态规划预处理
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> Partition(string s)
        {
            n = s.Length;
            f = new bool[n][];
            for (int i = 0; i < n; ++i)
            {
                f[i] = new bool[n];
                Array.Fill(f[i], true);
            }

            for (int i = n - 1; i >= 0; --i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    // 根据首位字符及去除首尾字符后字符串是否为回文判定
                    f[i][j] = (s[i] == s[j]) && f[i + 1][j - 1];
                }
            }

            Dfs(s, 0);
            return ret;
        }


        private void Dfs(string s, int i)
        {
            if (i == n)
            {
                ret.Add(new List<string>(ans));
                return;
            }
            for (int j = i; j < n; ++j)
            {
                if (f[i][j])
                {
                    ans.Add(s.Substring(i, j - i + 1));
                    Dfs(s, j + 1);
                    ans.RemoveAt(ans.Count - 1);
                }
            }
        }
    }
}
