namespace Code
{
    /// <summary>
    /// 1745. Palindrome Partitioning IV
    /// 
    /// Given a string s, return true if it is possible to split the string s into three non-empty palindromic substrings. Otherwise, return false.
    /// 给定一个字符串 s，如果可以将字符串 s 拆分为三个非空回文子字符串，则返回 true。否则，返回 false。
    /// 
    /// A string is said to be palindrome if it the same string when reversed.
    /// 如果字符串反转后仍为相同的字符串，则称其为回文。
    /// 
    /// </summary>
    public class Palindrome_Partitioning_IV
    {
        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckPartitioning(string s)
        {
            int n = s.Length;

            // isPalindrome[start,end] 表示字符串从索引 start 至 end 的子字符串是否为回文
            bool[,] isPalindrome = new bool[n, n];
            for (int length = 1; length < n; length++)
            {
                for (int start = 0; start <= n - length; start++)
                {
                    int end = start + length - 1;
                    if (length == 1)
                    {
                        isPalindrome[start, end] = true;
                    }
                    else if (length == 2)
                    {
                        isPalindrome[start, end] = (s[start] == s[end]);
                    }
                    else
                    {
                        isPalindrome[start, end] = (s[start] == s[end]) && isPalindrome[start + 1, end - 1];
                    }
                }
            }

            for (int start = 1; start < n - 1; start++)
            {
                if (!isPalindrome[0, start - 1])
                {
                    continue;
                }
                for (int end = start; end < n - 1; end++)
                {
                    if (isPalindrome[start, end] && isPalindrome[end + 1, n - 1])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
