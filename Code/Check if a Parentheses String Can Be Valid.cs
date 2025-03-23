namespace Code
{
    /// <summary>
    /// 2116. Check if a Parentheses String Can Be Valid
    /// 2116. 判断一个括号字符串是否有效
    /// 
    /// A parentheses string is a non-empty string consisting only of '(' and ')'. It is valid if any of the following conditions is true:
    /// 一个括号字符串是只由 '(' 和 ')' 组成的 非空 字符串。如果一个字符串满足下面 任意 一个条件，那么它就是有效的：
    /// 
    /// * It is ().
    /// * 字符串为 ().
    /// 
    /// * It can be written as AB (A concatenated with B), where A and B are valid parentheses strings.
    /// * 它可以表示为 AB（A 与 B 连接），其中A 和 B 都是有效括号字符串。
    /// 
    /// * It can be written as (A), where A is a valid parentheses string.
    /// * 它可以表示为 (A) ，其中 A 是一个有效括号字符串。
    /// 
    /// You are given a parentheses string s and a string locked, both of length n. locked is a binary string consisting only of '0's and '1's. For each index i of locked,
    /// 给你一个括号字符串 s 和一个字符串 locked ，两者长度都为 n 。locked 是一个二进制字符串，只包含 '0' 和 '1' 。对于 locked 中 每一个 下标 i ：
    /// 
    /// * If locked[i] is '1', you cannot change s[i].
    /// * 如果 locked[i] 是 '1' ，你 不能 改变 s[i] 。
    /// 
    /// * But if locked[i] is '0', you can change s[i] to either '(' or ')'.
    /// * 如果 locked[i] 是 '0' ，你 可以 将 s[i] 变为 '(' 或者 ')' 。
    /// 
    /// Return true if you can make s a valid parentheses string. Otherwise, return false.
    /// 如果你可以将 s 变为有效括号字符串，请你返回 true ，否则返回 false 。
    /// 
    /// </summary>
    public class Check_if_a_Parentheses_String_Can_Be_Valid
    {

        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="s"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public bool CanBeValid(string s, string locked)
        {
            int n = s.Length;
            int mx = 0;   // 可以达到的最大分数
            int mn = 0;   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
            for (int i = 0; i < n; ++i)
            {
                if (locked[i] == '1')
                {
                    // 此时对应字符无法更改
                    int diff;
                    if (s[i] == '(')
                    {
                        diff = 1;
                    }
                    else
                    {
                        diff = -1;
                    }
                    mx += diff;
                    mn = Math.Max(mn + diff, (i + 1) % 2);
                }
                else
                {
                    // 此时对应字符可以更改
                    ++mx;
                    mn = Math.Max(mn - 1, (i + 1) % 2);
                }
                if (mx < mn)
                {
                    // 此时该前缀无法变为有效前缀
                    return false;
                }
            }
            // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
            return mn == 0;
        }

        /// <summary>
        /// 1.长度是奇数返回假。
        /// 2.从左到右扫描，尽量都改成左括号，一旦有多余的右括号返回假。
        /// 3.从右到左扫描，尽量都改成右括号，一旦有多余的左括号返回假。
        /// 4.返回真。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public bool CanBeValid2(string s, string locked)
        {
            int n = s.Length;
            if (n % 2 == 1) return false;

            int num = 0;
            for (var i = 0; i < n; i++)
            {
                if (locked[i] == '0' || s[i] == '(') num++;
                else num--;

                if (num < 0) return false;
            }

            num = 0;
            for (var i = n - 1; i >= 0; i--)
            {
                if (locked[i] == '0' || s[i] == ')') num++;
                else num--;

                if (num < 0) return false;
            }

            return true;
        }
    }
}
