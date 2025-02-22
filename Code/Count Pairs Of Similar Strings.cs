namespace Code
{
    /// <summary>
    /// 2506. Count Pairs Of Similar Strings
    /// 
    /// You are given a 0-indexed string array words.
    /// 给定一个从 0 开始的字符串数组 words。
    /// 
    /// Two strings are similar if they consist of the same characters.
    /// 如果两个字符串由相同的字符组成，则它们相似。
    /// 
    /// * For example, "abca" and "cba" are similar since both consist of characters 'a', 'b', and 'c'.
    /// * 例如，“abca”和“cba”相似，因为它们都由字符“a”、“b”和“c”组成。
    /// 
    /// * However, "abacba" and "bcfd" are not similar since they do not consist of the same characters.
    /// * 但是，“abacba”和“bcfd”并不相似，因为它们不是由相同的字符组成。
    /// 
    /// Return the number of pairs (i, j) such that 0 <= i < j <= word.length - 1 and the two strings words[i] and words[j] are similar.
    /// 返回满足 0 <= i < j <= word.length - 1 且两个字符串 words[i] 和 words[j] 相似的对 (i, j) 的数量。
    /// 
    /// </summary>
    public class Count_Pairs_Of_Similar_Strings
    {
        /// <summary>
        /// 位运算+遍历统计
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int SimilarPairs(string[] words)
        {
            int[] map = new int[words.Length];

            for (var i = 0; i < words.Length; i++)
            {
                for (var j = 0; j < words[i].Length; j++)
                {
                    map[i] |= 1 << (words[i][j] - 'a');
                }
            }

            int ans = 0;

            for (var i = 0; i < map.Length - 1; i++)
            {
                for (var j = i + 1; j < map.Length; j++)
                {
                    if (map[i] == map[j]) ans++;
                }
            }

            return ans;
        }


        /// <summary>
        /// 位运算+哈希统计
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int SimilarPairs2(string[] words)
        {
            int ans = 0;
            IDictionary<int, int> dic = new Dictionary<int, int>();
            foreach (string s in words)
            {
                int state = 0;
                foreach (char c in s)
                {
                    state |= 1 << (c - 'a');
                }
                dic.TryAdd(state, 0);
                ans += dic[state];
                dic[state]++;
            }
            return ans;
        }
    }
}
