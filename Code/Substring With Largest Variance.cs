namespace Code
{
    /// <summary>
    /// 2272. Substring With Largest Variance
    /// 2272. 最大波动的子字符串
    /// 
    /// The variance of a string is defined as the largest difference between the number of occurrences of any 2 characters present in the string. Note the two characters may or may not be the same.
    /// 字符串的 波动 定义为子字符串中出现次数 最多 的字符次数与出现次数 最少 的字符次数之差。
    /// 
    /// Given a string s consisting of lowercase English letters only, return the largest variance possible among all substrings of s.
    /// 给你一个字符串 s ，它只包含小写英文字母。请你返回 s 里所有 子字符串的 最大波动 值。
    /// 
    /// A substring is a contiguous sequence of characters within a string.
    /// 子字符串 是一个字符串的一段连续字符序列。
    /// 
    /// </summary>
    public class Substring_With_Largest_Variance
    {
        /// <summary>
        /// 枚举最多和最少的字符 + 最大子段和动态规划
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LargestVariance(string s)
        {
            // 记录相同字符索引位置
            var pos = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (!pos.ContainsKey(ch)) pos[ch] = new List<int>();
                pos[ch].Add(i);
            }

            int ans = 0;
            foreach (var c0 in pos)
            {
                foreach (var c1 in pos)
                {
                    if (c0.Key != c1.Key)
                    {
                        List<int> pos0 = c0.Value;
                        List<int> pos1 = c1.Value;
                        int i = 0, j = 0;
                        int f = 0, g = int.MinValue;
                        while (i < pos0.Count || j < pos1.Count)
                        {
                            if (j == pos1.Count || (i < pos0.Count && pos0[i] < pos1[j]))
                            {
                                f = Math.Max(f, 0) + 1;
                                g = g + 1;
                                i++;
                            }
                            else
                            {
                                g = Math.Max(f, Math.Max(g, 0)) - 1;
                                f = Math.Max(f, 0) - 1;
                                j++;
                            }
                            ans = Math.Max(ans, g);
                        }
                    }
                }
            }
            return ans;
        }
    }
}
