namespace Code
{
    /// <summary>
    /// 3306. Count of Substrings Containing Every Vowel and K Consonants II
    /// 3306. 元音辅音字符串计数 II
    /// 
    /// You are given a string word and a non-negative integer k.
    /// 给你一个字符串 word 和一个 非负 整数 k。
    /// 
    /// Return the total number of substrings of word that contain every vowel ('a', 'e', 'i', 'o', and 'u') at least once and exactly k consonants.
    /// 返回 word 的 子字符串 中，每个元音字母（'a'、'e'、'i'、'o'、'u'）至少 出现一次，并且 恰好 包含 k 个辅音字母的子字符串的总数。
    /// 
    /// </summary>
    public class Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="word"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountOfSubstrings(string word, int k)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

            // count(k) 表示每个元音字母至少出现一次，并且至少包含 k 个辅音字母的子字符串的总数
            long Count(int m)
            {
                int n = word.Length, consonants = 0;
                long res = 0;
                Dictionary<char, int> occur = new Dictionary<char, int>();
                for (int i = 0, j = 0; i < n; i++)
                {
                    while (j < n && (consonants < m || occur.Count < 5))
                    {
                        char ch = word[j];
                        if (vowels.Contains(ch))
                        {
                            if (!occur.ContainsKey(ch)) occur[ch] = 0;
                            occur[ch]++;
                        }
                        else
                        {
                            consonants++;
                        }
                        j++;
                    }
                    if (consonants >= m && occur.Count == 5)
                    {
                        res += n - j + 1;
                    }
                    char left = word[i];
                    if (vowels.Contains(left))
                    {
                        occur[left]--;
                        if (occur[left] == 0)
                        {
                            occur.Remove(left);
                        }
                    }
                    else
                    {
                        consonants--;
                    }
                }
                return res;
            }
            return Count(k) - Count(k + 1);
        }

        /// <summary>
        /// 滑动窗口 + 二进制计算
        /// </summary>
        /// <param name="word"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountOfSubstrings2(string word, int k)
        {
            int[] chs = new int[26], tChs = new int[26];
            int mask = 0;
            string vowels = "aeiou";
            foreach (char vowel in vowels)
            {
                mask |= 1 << (vowel - 'a');
            }
            int yuanCount = 0, fuCount = 0, left = 0, leftYuan = 0;
            long ans = 0;
            for (int i = 0; i < word.Length; ++i)
            {
                int t = word[i] - 'a';
                chs[t]++;
                tChs[t]++;
                if (((1 << t) & mask) != 0)
                {
                    if (chs[t] == 1) yuanCount++;
                }
                else
                {
                    fuCount++;
                }
                while (fuCount > k)
                {
                    t = word[left] - 'a';
                    chs[t]--;
                    if (left == leftYuan)
                    {
                        leftYuan++;
                        tChs[t]--;
                    }
                    if (((1 << t) & mask) != 0)
                    {
                        if (chs[t] == 0) yuanCount--;
                    }
                    else
                    {
                        fuCount--;
                    }
                    left++;
                }

                if (yuanCount == 5 && fuCount == k)
                {
                    ans += leftYuan - left + 1;
                    while (((1 << (word[leftYuan] - 'a')) & mask) != 0 && tChs[word[leftYuan] - 'a'] > 1)
                    {
                        tChs[word[leftYuan] - 'a']--;
                        ans++;
                        leftYuan++;
                    }
                }
            }
            return ans;
        }
    }
}
