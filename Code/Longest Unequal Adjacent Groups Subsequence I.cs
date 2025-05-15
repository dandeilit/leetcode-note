namespace Code
{
    /// <summary>
    /// 2900. Longest Unequal Adjacent Groups Subsequence I
    /// 2900. 最长相邻不相等子序列 I
    /// 
    /// You are given a string array words and a binary array groups both of length n, where words[i] is associated with groups[i].
    /// 给你一个下标从 0 开始的字符串数组 words ，和一个下标从 0 开始的 二进制 数组 groups ，两个数组长度都是 n 。
    /// 
    /// Your task is to select the longest alternating subsequence from words. A subsequence of words is alternating if for any two consecutive strings in the sequence, their corresponding elements in the binary array groups differ. Essentially, you are to choose strings such that adjacent elements have non-matching corresponding bits in the groups array.
    /// 你需要从 words 中选出 最长子序列。如果对于序列中的任何两个连续串，二进制数组 groups 中它们的对应元素不同，则 words 的子序列是不同的。
    /// 
    /// Formally, you need to find the longest subsequence of an array of indices [0, 1, ..., n - 1] denoted as [i0, i1, ..., ik-1], such that groups[ij] != groups[ij+1] for each 0 <= j < k - 1 and then find the words corresponding to these indices.
    /// 正式来说，你需要从下标 [0, 1, ..., n - 1] 中选出一个 最长子序列 ，将这个子序列记作长度为 k 的 [i0, i1, ..., ik - 1] ，对于所有满足 0 <= j < k - 1 的 j 都有 groups[ij] != groups[ij + 1] 。
    /// 
    /// Return the selected subsequence. If there are multiple answers, return any of them.
    /// 请你返回一个字符串数组，它是下标子序列 依次 对应 words 数组中的字符串连接形成的字符串数组。如果有多个答案，返回 任意 一个。
    /// 
    /// Note: The elements in words are distinct.
    /// 注意：words 中的元素是不同的 。
    /// 
    /// </summary>
    public class Longest_Unequal_Adjacent_Groups_Subsequence_I
    {
        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="words"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public IList<string> GetLongestSubsequence(string[] words, int[] groups)
        {
            int n = words.Length;
            // dp[i] 表示以 i 为结尾的最长子序列的长度
            int[] dp = new int[n];
            // prev[i] 记载最长子序列中索引 i 的前一个元素 j
            int[] prev = new int[n];
            int maxLen = 1, endIndex = 0;

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                prev[i] = -1;
            }
            for (int i = 1; i < n; i++)
            {
                int bestLen = 1;
                int bestPrev = -1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (groups[i] != groups[j] && dp[j] + 1 > bestLen)
                    {
                        bestLen = dp[j] + 1;
                        bestPrev = j;
                    }
                }
                dp[i] = bestLen;
                prev[i] = bestPrev;
                if (dp[i] > maxLen)
                {
                    maxLen = dp[i];
                    endIndex = i;
                }
            }

            List<string> res = new List<string>();
            for (int i = endIndex; i != -1; i = prev[i])
            {
                res.Add(words[i]);
            }
            res.Reverse();
            return res;
        }

        /// <summary>
        /// 贪心
        /// 只需要把数组中相邻元素相同的部分去掉，剩余的元素即为最长且不相邻的子序列
        /// </summary>
        /// <param name="words"></param>
        /// <param name="groups"></param>
        /// <returns></returns>
        public IList<string> GetLongestSubsequence2(string[] words, int[] groups)
        {
            List<string> ans = new List<string>();
            int n = words.Length;
            for (int i = 0; i < n; i++)
            {
                if (i == 0 || groups[i] != groups[i - 1])
                {
                    ans.Add(words[i]);
                }
            }
            return ans;
        }
    }
}
