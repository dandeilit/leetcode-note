namespace Code
{
    /// <summary>
    /// 3110. Score of a String
    /// 3110. 字符串的分数
    /// 
    /// You are given a string s. The score of a string is defined as the sum of the absolute difference between the ASCII values of adjacent characters.
    /// 给你一个字符串 s 。一个字符串的 分数 定义为相邻字符 ASCII 码差值绝对值的和。
    /// 
    /// Return the score of s.
    /// 请你返回 s 的 分数 。
    /// 
    /// </summary>
    public class Score_of_a_String
    {
        public int ScoreOfString(string s)
        {
            int ans = 0;
            for (int i = 1; i < s.Length; i++)
            {
                ans += Math.Abs(s[i] - s[i - 1]);
            }
            return ans;
        }
    }
}
