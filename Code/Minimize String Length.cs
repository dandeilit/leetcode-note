using System.Numerics;

namespace Code
{
    /// <summary>
    /// 2716. Minimize String Length
    /// 2716. 最小化字符串长度
    /// 
    /// Given a string s, you have two types of operation:
    /// 给你一个下标从 0 开始的字符串 s ，重复执行下述操作 任意 次：
    /// 
    /// * Choose an index i in the string, and let c be the character in position i. Delete the closest occurrence of c to the left of i (if exists).
    /// * 在字符串中选出一个下标 i ，并使 c 为字符串下标 i 处的字符。并在 i 左侧（如果有）删除 一个距离 i 最近 的字符 c 。
    /// 
    /// * Choose an index i in the string, and let c be the character in position i. Delete the closest occurrence of c to the right of i (if exists).
    /// * 在字符串中选出一个下标 i ，并使 c 为字符串下标 i 处的字符。并在 i 右侧（如果有）删除 一个距离 i 最近 的字符 c 。
    /// 
    /// Your task is to minimize the length of s by performing the above operations zero or more times.
    /// 请你通过执行上述操作任意次，使 s 的长度 最小化 。
    /// 
    /// Return an integer denoting the length of the minimized string.
    /// 返回一个表示 最小化 字符串的长度的整数。
    /// 
    /// </summary>
    public class Minimize_String_Length
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimizedStringLength(string s)
        {
            var cSet = new HashSet<char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!cSet.Contains(s[i]))
                {
                    cSet.Add(s[i]);
                }
            }
            return cSet.Count;
        }

        /// <summary>
        /// 二进制
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinimizedStringLength2(string s)
        {
            int mask = 0;
            foreach (char c in s)
            {
                mask |= 1 << (c - 'a');
            }
            return BitOperations.PopCount((uint)mask);
        }
    }
}
