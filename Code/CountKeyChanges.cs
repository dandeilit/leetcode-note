namespace Code
{
    /// <summary>
    /// 3019. Number of Changing Keys
    /// 
    /// You are given a 0-indexed string s typed by a user. Changing a key is defined as using a key different from the last used key. For example, s = "ab" has a change of a key while s = "bBBb" does not have any.
    /// 您将获得一个由用户输入的0 索引字符串s 。更改密钥被定义为使用与上次使用的密钥不同的密钥。例如， s = "ab"有密钥更改，而s = "bBBb"没有任何更改。
    /// 
    /// Return the number of times the user had to change the key.
    /// 返回用户必须更改密钥的次数。
    /// 
    /// Note: Modifiers like shift or caps lock won't be counted in changing the key that is if a user typed the letter 'a' and then the letter 'A' then it will not be considered as a changing of key.
    /// 注意：像shift或caps lock这样的修饰符不会被计入更改密钥的范围内，也就是说，如果用户输入字母'a' ，然后输入字母'A' ，则不会被视为更改密钥。
    /// 
    /// </summary>
    public class CountKeyChanges
    {
        /// <summary>
        /// 通过比较相邻字符的ASCII码值来判断是否需要更改密钥
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Solution(string s)
        {
            int ans = 0;
            for (var i = 0; i < s.Length - 1; i++)
            {
                int temp = Math.Abs(s[i] - s[i + 1]);
                if (temp != 32 && temp != 0)
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
