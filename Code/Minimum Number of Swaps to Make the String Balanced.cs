namespace Code
{
    /// <summary>
    /// 1963. Minimum Number of Swaps to Make the String Balanced
    /// 1963. 使字符串平衡的最小交换次数
    /// 
    /// You are given a 0-indexed string s of even length n. The string consists of exactly n / 2 opening brackets '[' and n / 2 closing brackets ']'.
    /// 给你一个字符串 s ，下标从 0 开始 ，且长度为偶数 n 。字符串 恰好 由 n / 2 个开括号 '[' 和 n / 2 个闭括号 ']' 组成。
    /// 
    /// A string is called balanced if and only if:
    /// 只有能满足下述所有条件的字符串才能称为 平衡字符串 ：
    /// 
    /// * It is the empty string, or
    /// * 字符串是一个空字符串，或者
    /// 
    /// * It can be written as AB, where both A and B are balanced strings, or
    /// * 字符串可以记作 AB ，其中 A 和 B 都是 平衡字符串 ，或者
    /// 
    /// * It can be written as [C], where C is a balanced string.
    /// * 字符串可以写成 [C] ，其中 C 是一个 平衡字符串 。
    /// 
    /// You may swap the brackets at any two indices any number of times.
    /// 你可以交换 任意 两个下标所对应的括号 任意 次数。
    /// 
    /// Return the minimum number of swaps to make s balanced.
    /// 返回使 s 变成 平衡字符串 所需要的 最小 交换次数。
    /// 
    /// </summary>
    public class Minimum_Number_of_Swaps_to_Make_the_String_Balanced
    {
        public int MinSwaps(string s)
        {
            int num = 0;
            foreach (var c in s)
            {
                if (c == '[' && num == 0)
                {
                    num++;
                }
                else
                {
                    num--;
                }
            }

            return -(num + 1) / 2;
        }
    }
}
