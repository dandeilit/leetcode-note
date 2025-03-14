namespace Code
{
    /// <summary>
    /// 3340. Check Balanced String
    /// 
    /// You are given a string num consisting of only digits. A string of digits is called balanced if the sum of the digits at even indices is equal to the sum of digits at odd indices.
    /// 给你一个仅由数字 0 - 9 组成的字符串 num。如果偶数下标处的数字之和等于奇数下标处的数字之和，则认为该数字字符串是一个 平衡字符串。
    /// 
    /// Return true if num is balanced, otherwise return false.
    /// 如果 num 是一个 平衡字符串，则返回 true；否则，返回 false。
    /// 
    /// </summary>
    public class Check_Balanced_String
    {
        public bool IsBalanced(string num)
        {
            var t = 0;
            var k = 1;
            for (int i = 0; i < num.Length; i++)
            {
                t += (num[i] - '0') * k;
                k *= -1;
            }
            return t == 0;
        }
    }
}
