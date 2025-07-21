using System.Text;

namespace Code
{
    /// <summary>
    /// 1957. Delete Characters to Make Fancy String
    /// 1957. 删除字符使字符串变好
    /// 
    /// A fancy string is a string where no three consecutive characters are equal.
    /// 一个字符串如果没有 三个连续 相同字符，那么它就是一个 好字符串 。
    /// 
    /// Given a string s, delete the minimum possible number of characters from s to make it fancy.
    /// 给你一个字符串 s ，请你从 s 删除 最少 的字符，使它变成一个 好字符串 。
    /// 
    /// Return the final string after the deletion. It can be shown that the answer will always be unique.
    /// 请你返回删除后的字符串。题目数据保证答案总是 唯一的 。
    /// 
    /// </summary>
    public class Delete_Characters_to_Make_Fancy_String
    {
        public string MakeFancyString(string s)
        {
            StringBuilder res = new StringBuilder();   // 删除后的字符串

            // 遍历 s 模拟删除过程
            foreach (char ch in s)
            {
                int n = res.Length;
                if (n >= 2 && res[n - 1] == ch && res[n - 2] == ch)
                {
                    // 如果 res 最后两个字符与当前字符均相等，则不添加
                    continue;
                }
                // 反之则添加
                res.Append(ch);
            }
            return res.ToString();
        }
    }
}
