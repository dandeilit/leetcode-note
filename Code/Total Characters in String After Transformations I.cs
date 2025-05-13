namespace Code
{
    /// <summary>
    /// 3335. Total Characters in String After Transformations I
    /// 3335. 字符串转换后的长度 I
    /// 
    /// You are given a string s and an integer t, representing the number of transformations to perform. In one transformation, every character in s is replaced according to the following rules:
    /// 给你一个字符串 s 和一个整数 t，表示要执行的 转换 次数。每次 转换 需要根据以下规则替换字符串 s 中的每个字符：
    /// 
    /// * If the character is 'z', replace it with the string "ab".
    /// * 如果字符是 'z'，则将其替换为字符串 "ab"。
    /// 
    /// * Otherwise, replace it with the next character in the alphabet. For example, 'a' is replaced with 'b', 'b' is replaced with 'c', and so on.
    /// * 否则，将其替换为字母表中的下一个字符。例如，'a' 替换为 'b'，'b' 替换为 'c'，依此类推。
    /// 
    /// Return the length of the resulting string after exactly t transformations.
    /// 返回 恰好 执行 t 次转换后得到的字符串的 长度。
    /// 
    /// Since the answer may be very large, return it modulo Math.Pow(10,9) + 7.
    /// 由于答案可能非常大，返回其对 Math.Pow(10,9) + 7 取余的结果。
    /// 
    /// </summary>
    public class Total_Characters_in_String_After_Transformations_I
    {
        private const int MOD = 1000000007;

        /// <summary>
        /// 递推
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int LengthAfterTransformations(string s, int t)
        {
            int[] cnt = new int[26];
            foreach (char ch in s)
            {
                ++cnt[ch - 'a'];
            }
            for (int round = 0; round < t; ++round)
            {
                int[] nxt = new int[26];
                nxt[0] = cnt[25];
                nxt[1] = (cnt[25] + cnt[0]) % MOD;
                for (int i = 2; i < 26; ++i)
                {
                    nxt[i] = cnt[i - 1];
                }
                cnt = nxt;
            }
            int ans = 0;
            for (int i = 0; i < 26; ++i)
            {
                ans = (ans + cnt[i]) % MOD;
            }
            return ans;
        }
    }
}
