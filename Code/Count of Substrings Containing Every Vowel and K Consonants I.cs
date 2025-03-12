namespace Code
{
    /// <summary>
    /// 3305. Count of Substrings Containing Every Vowel and K Consonants I
    /// 3305. 元音辅音字符串计数 I
    /// 
    /// You are given a string word and a non-negative integer k.
    /// 给你一个字符串 word 和一个 非负 整数 k。
    /// 
    /// Return the total number of substrings of word that contain every vowel ('a', 'e', 'i', 'o', and 'u') at least once and exactly k consonants.
    /// 返回 word 的 子字符串 中，每个元音字母（'a'、'e'、'i'、'o'、'u'）至少 出现一次，并且 恰好 包含 k 个辅音字母的子字符串的总数。
    /// 
    /// </summary>
    public class Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_I
    {
        public int CountOfSubstrings(string word, int k)
        {
            var vowelKey = new Dictionary<char, int>() {
                { 'a',0},
                { 'e',1},
                { 'i',2},
                { 'o',3},
                { 'u',4},
            };

            int ans = 0;
            int n = word.Length;
            for (var len = 5 + k; len <= n; len++)
            {
                for (var i = 0; i <= n - len; i++)
                {
                    int num = 0;
                    int vowelCheck = 0;
                    for (var j = 0; j < len; j++)
                    {
                        if (vowelKey.ContainsKey(word[i + j]))
                        {
                            vowelCheck |= (1 << vowelKey[word[i + j]]);
                        }
                        else
                        {
                            num++;
                            if (num > k) break;
                        }
                    }
                    if (vowelCheck == 31 && num == k)
                    {
                        ans++;
                    }
                }
            }

            return ans;
        }

        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="word"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountOfSubstrings2(string word, int k)
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
    }
}
