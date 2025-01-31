namespace Code
{
    /// <summary>
    /// 541. Reverse String II
    /// 
    /// Given a string s and an integer k, reverse the first k characters for every 2k characters counting from the start of the string.
    /// 给定一个字符串 s 和一个整数 k，从字符串开头算起，每 2k 个字符反转前 k 个字符。
    /// 
    /// If there are fewer than k characters left, reverse all of them. If there are less than 2k but greater than or equal to k characters, then reverse the first k characters and leave the other as original.
    /// 如果剩余字符少于 k 个，则反转所有字符。如果少于 2k 个但大于或等于 k 个字符，则反转前 k 个字符，其余字符保持原样。
    /// 
    /// </summary>
    public class Reverse_String_II
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string ReverseStr(string s, int k)
        {
            var ans = new char[s.Length];

            for (var i = 0; i < s.Length; i++)
            {
                var rem = i % (2 * k);
                if (rem >= k)
                {
                    ans[i] = s[i];
                }
                else
                {
                    var start = i;
                    var end = Math.Min(i + k - 1, s.Length - 1);
                    i = end;
                    while (start <= end)
                    {
                        ans[start] = s[end];
                        ans[end] = s[start];
                        start++;
                        end--;
                    }
                }

            }

            return new string(ans);
        }
    }
}
