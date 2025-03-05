namespace Code
{
    /// <summary>
    /// 1328. Break a Palindrome
    /// 
    /// Given a palindromic string of lowercase English letters palindrome, replace exactly one character with any lowercase English letter so that the resulting string is not a palindrome and that it is the lexicographically smallest one possible.
    /// 给定一个小写英文字母 palindrome 的回文字符串，用任意小写英文字母替换一个字符，使得生成的字符串不是回文，并且是字典顺序最小的字符串。
    /// 
    /// Return the resulting string. If there is no way to replace a character to make it not a palindrome, return an empty string.
    /// 返回生成的字符串。如果无法替换字符使其不是回文，则返回空字符串。
    /// 
    /// A string a is lexicographically smaller than a string b (of the same length) if in the first position where a and b differ, a has a character strictly smaller than the corresponding character in b. For example, "abcc" is lexicographically smaller than "abcd" because the first position they differ is at the fourth character, and 'c' is smaller than 'd'.
    /// 如果在 a 和 b 的第一个不同位置上，a 的字符严格小于 b 中相应字符，则字符串 a 的字典顺序小于字符串 b（长度相同）。例如，“abcc”的字典顺序小于“abcd”，因为它们的第一个不同位置是第四个字符，并且“c”小于“d”。
    /// 
    /// </summary>
    public class Break_a_Palindrome
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="palindrome"></param>
        /// <returns></returns>
        public string BreakPalindrome(string palindrome)
        {
            int n = palindrome.Length;
            if (n == 1) return "";

            char[] str = palindrome.ToCharArray();

            for (var i = 0; i < n >> 1; i++)
            {
                if (str[i] != 'a')
                {
                    str[i] = 'a';
                    return new string(str);
                }
            }
            str[n - 1] = 'b';

            return new string(str);
        }
    }
}
