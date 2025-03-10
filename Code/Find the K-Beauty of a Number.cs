namespace Code
{
    /// <summary>
    /// 2269. Find the K-Beauty of a Number
    /// 
    /// The k-beauty of an integer num is defined as the number of substrings of num when it is read as a string that meet the following conditions:
    /// 一个整数 num 的 k 美丽值定义为 num 中符合以下条件的 子字符串 数目：
    /// 
    /// * It has a length of k.
    /// * 子字符串长度为 k 。
    /// 
    /// * It is a divisor of num.
    /// * 子字符串能整除 num 。
    /// 
    /// Given integers num and k, return the k-beauty of num.
    /// 给你整数 num 和 k ，请你返回 num 的 k 美丽值。
    /// 
    /// Note:
    /// 注意：
    /// 
    /// * Leading zeros are allowed.
    /// * 允许有 前缀 0 。
    /// 
    /// * 0 is not a divisor of any value.
    /// * 0 不能整除任何值。
    /// 
    /// A substring is a contiguous sequence of characters in a string.
    /// 一个 子字符串 是一个字符串里的连续一段字符序列。
    /// 
    /// </summary>
    public class Find_the_K_Beauty_of_a_Number
    {
        public int DivisorSubstrings(int num, int k)
        {
            var strNum = num.ToString();
            int n = strNum.Length;
            if (n < k) return 0;
            if (n == k) return 1;

            int ans = 0;
            for (var i = 0; i < n - k + 1; i++)
            {
                var divisor = Convert.ToInt32(strNum.Substring(i, k));
                if (divisor != 0 && num % divisor == 0) ans++;
            }
            return ans;
        }

        public int DivisorSubstrings2(int num, int k)
        {
            var ans = 0;
            var remaining = num;
            while (remaining >= Math.Pow(10, k - 1))
            {
                var divisor = remaining % Math.Pow(10, k);
                remaining = remaining / 10;
                if (divisor != 0 && num % divisor == 0) ans++;
            }
            return ans;
        }
    }
}
