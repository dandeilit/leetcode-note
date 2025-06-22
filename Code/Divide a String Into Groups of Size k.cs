namespace Code
{
    /// <summary>
    /// 2138. Divide a String Into Groups of Size k
    /// 2138. 将字符串拆分为若干长度为 k 的组
    /// 
    /// A string s can be partitioned into groups of size k using the following procedure:
    /// 字符串 s 可以按下述步骤划分为若干长度为 k 的组：
    /// 
    /// * The first group consists of the first k characters of the string, the second group consists of the next k characters of the string, and so on. Each element can be a part of exactly one group.
    /// * 第一组由字符串中的前 k 个字符组成，第二组由接下来的 k 个字符串组成，依此类推。每个字符都能够成为 某一个 组的一部分。
    /// 
    /// * For the last group, if the string does not have k characters remaining, a character fill is used to complete the group.
    /// * 对于最后一组，如果字符串剩下的字符 不足 k 个，需使用字符 fill 来补全这一组字符。
    /// 
    /// Note that the partition is done so that after removing the fill character from the last group (if it exists) and concatenating all the groups in order, the resultant string should be s.
    /// 注意，在去除最后一个组的填充字符 fill（如果存在的话）并按顺序连接所有的组后，所得到的字符串应该是 s 。
    /// 
    /// Given the string s, the size of each group k and the character fill, return a string array denoting the composition of every group s has been divided into, using the above procedure.
    /// 给你一个字符串 s ，以及每组的长度 k 和一个用于填充的字符 fill ，按上述步骤处理之后，返回一个字符串数组，该数组表示 s 分组后 每个组的组成情况 。
    /// 
    /// </summary>
    public class Divide_a_String_Into_Groups_of_Size_k
    {
        public string[] DivideString(string s, int k, char fill)
        {
            var n = s.Length;
            var ans = new string[(n + k - 1) / k];//向上取整
            for (var i = 0; i < ans.Length; i++)
            {
                var curStr = s.Substring(i * k, Math.Min(k, n - i * k));
                while (i == ans.Length - 1 && curStr.Length < k) curStr += fill;
                ans[i] = curStr;
            }

            return ans;
        }
    }
}
