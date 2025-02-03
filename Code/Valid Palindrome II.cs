namespace Code
{
    /// <summary>
    /// 680. Valid Palindrome II
    /// 
    /// Given a string s, return true if the s can be palindrome after deleting at most one character from it.
    /// 给定一个字符串 s，如果从中最多删除一个字符后 s 可以成为回文，则返回 true。
    /// 
    /// </summary>
    public class Valid_Palindrome_II
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ValidPalindrome(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (s[l] == s[r])
                {
                    l++;
                    r--;
                }
                else
                {
                    return IsPalindrome(s, l + 1, r) || IsPalindrome(s, l, r - 1);
                }
            }
            return true;
        }

        private bool IsPalindrome(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                {
                    return false;
                }
                l++;
                r--;
            }
            return true;
        }
    }
}
