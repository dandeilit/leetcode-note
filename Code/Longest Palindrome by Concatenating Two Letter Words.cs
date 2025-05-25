namespace Code
{
    /// <summary>
    /// 2131. Longest Palindrome by Concatenating Two Letter Words
    /// 2131. 连接两字母单词得到的最长回文串
    /// 
    /// You are given an array of strings words. Each element of words consists of two lowercase English letters.
    /// 给你一个字符串数组 words 。words 中每个元素都是一个包含 两个 小写英文字母的单词。
    /// 
    /// Create the longest possible palindrome by selecting some elements from words and concatenating them in any order. Each element can be selected at most once.
    /// 请你从 words 中选择一些元素并按 任意顺序 连接它们，并得到一个 尽可能长的回文串 。每个元素 至多 只能使用一次。
    /// 
    /// Return the length of the longest palindrome that you can create. If it is impossible to create any palindrome, return 0.
    /// 请你返回你能得到的最长回文串的 长度 。如果没办法得到任何一个回文串，请你返回 0 。
    /// 
    /// A palindrome is a string that reads the same forward and backward.
    /// 回文串 指的是从前往后和从后往前读一样的字符串。
    /// 
    /// </summary>
    public class Longest_Palindrome_by_Concatenating_Two_Letter_Words
    {
        /// <summary>
        /// 贪心 + 哈希表
        /// 遍历源数组统计
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestPalindrome(string[] words)
        {
            Dictionary<string, int> dp = new Dictionary<string, int>();
            int ans = 0;
            foreach (string word in words)
            {
                string reverse = new string(word.Reverse().ToArray());
                if (dp.ContainsKey(reverse) && dp[reverse] > 0)
                {
                    dp[reverse] -= 1;
                    ans += 2;
                }
                else
                {
                    if (dp.ContainsKey(word))
                    {
                        dp[word] += 1;
                    }
                    else
                    {
                        dp.Add(word, 1);
                    }
                }
            }

            foreach (var item in dp)
            {
                if (item.Value > 0 && item.Key == new string(item.Key.Reverse().ToArray()))
                {
                    ans++;
                    break;
                }
            }

            return ans * 2;
        }

        /// <summary>
        /// 贪心 + 哈希表
        /// 遍历哈希表统计
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int LongestPalindrome2(string[] words)
        {
            Dictionary<string, int> freq = new Dictionary<string, int>();
            foreach (string word in words)
            {
                freq[word] = freq.GetValueOrDefault(word, 0) + 1;
            }
            int res = 0;
            bool mid = false;
            foreach (var entry in freq)
            {
                string word = entry.Key;
                int cnt = entry.Value;
                string rev = "" + word[1] + word[0];
                if (word == rev)
                {
                    if (cnt % 2 == 1)
                    {
                        mid = true;
                    }
                    res += 2 * (cnt / 2 * 2);
                }
                else if (string.Compare(word, rev) > 0)
                {
                    res += 4 * Math.Min(freq.GetValueOrDefault(word, 0), freq.GetValueOrDefault(rev, 0));
                }
            }
            if (mid)
            {
                res += 2;
            }
            return res;
        }
    }
}
