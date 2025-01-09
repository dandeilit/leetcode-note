namespace Code
{
    /// <summary>
    /// 3297. Count Substrings That Can Be Rearranged to Contain a String I
    /// 
    /// You are given two strings word1 and word2.
    /// 给您两个字符串word1和word2 。
    /// 
    /// A string x is called valid if x can be rearranged to have word2 as a prefix.
    /// 如果字符串 x 可以重新排列为以 word2 作为前缀，则称其为有效字符串。
    /// 
    /// Return the total number of valid substrings of word1.
    /// 返回 word1 的有效子字符串总数。
    /// 
    /// </summary>
    public class ValidSubstringCount
    {

        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public long Solution(string word1, string word2)
        {
            int[] diff = new int[26]; // 26个字母

            foreach (char c in word2) // 统计word2中每个字母出现的次数
            {
                diff[c - 'a']--;
            }

            long res = 0;
            int cnt = diff.Count(c => c < 0); // 统计world2的字母类型个数
            int l = 0, r = 0; // 滑动窗口左右游标
            while (l < word1.Length)
            {
                while (r < word1.Length && cnt > 0)
                {
                    diff[word1[r] - 'a'] += 1; // 窗口最右侧字母判定+1
                    if (diff[word1[r] - 'a'] == 0) // 如果窗口最右侧字母判定为0
                    {
                        // 表明world2中的某类型字母已经全部匹配
                        // 减少world2中的字母类型个数
                        cnt--;
                    }
                    r++;
                }

                if (cnt == 0) // 如果world2中的所有字母已经全部匹配
                {
                    // 统计有效子字符串数量
                    // 例如：abcabc, abc => 4
                    // 有效子字符串为 abc, abca, abcab, abcabc
                    res += word1.Length - r + 1;
                }

                diff[word1[l] - 'a'] -= 1; // 窗口最右侧字母判定-1
                // 经过之前右游标的判定，窗口内除了world2中的字母类型外，其他类型的字母均大于0，所以这里只需要判断是否为-1
                if (diff[word1[l] - 'a'] == -1) // 如果窗口最左侧字母判定为-1
                {
                    // 表明world2中已经全部匹配的某类型字母被移除
                    // 补充world2中的字母类型个数
                    cnt++;
                }
                l++;
            }
            return res;
        }
    }
}
