namespace Code
{
    /// <summary>
    /// 3442. Maximum Difference Between Even and Odd Frequency I
    /// 3442. 奇偶频次间的最大差值 I
    /// 
    /// You are given a string s consisting of lowercase English letters.
    /// 给你一个由小写英文字母组成的字符串 s 。
    /// 
    /// Your task is to find the maximum difference diff = freq(a1) - freq(a2) between the frequency of characters a1 and a2 in the string such that:
    /// 请你找出字符串中两个字符 a1 和 a2 的出现频次之间的 最大 差值 diff = a1 - a2，这两个字符需要满足：
    /// 
    /// * a1 has an odd frequency in the string.
    /// * a1 在字符串中出现 奇数次 。
    /// 
    /// * a2 has an even frequency in the string.
    /// * a2 在字符串中出现 偶数次 。
    /// 
    /// Return this maximum difference.
    /// 返回 最大 差值。
    /// 
    /// </summary>
    public class Maximum_Difference_Between_Even_and_Odd_Frequency_I
    {
        public int MaxDifference(string s)
        {
            int[] dp = new int[26];
            foreach (var c in s)
            {
                dp[c - 'a']++;
            }

            int a1 = int.MinValue;
            int a2 = int.MaxValue;
            foreach (var d in dp)
            {
                if (d == 0) continue;

                if (d % 2 == 0)
                {
                    a2 = Math.Min(a2, d);
                }
                else
                {
                    a1 = Math.Max(a1, d);
                }
            }
            return a1 - a2;
        }
    }
}
