namespace Code
{
    /// <summary>
    /// 2843. Count Symmetric Integers
    /// 2843. 统计对称整数的数目
    /// 
    /// You are given two positive integers low and high.
    /// 给你两个正整数 low 和 high 。
    /// 
    /// An integer x consisting of 2 * n digits is symmetric if the sum of the first n digits of x is equal to the sum of the last n digits of x. Numbers with an odd number of digits are never symmetric.
    /// 对于一个由 2 * n 位数字组成的整数 x ，如果其前 n 位数字之和与后 n 位数字之和相等，则认为这个数字是一个对称整数。
    /// 
    /// Return the number of symmetric integers in the range [low, high].
    /// 返回在 [low, high] 范围内的 对称整数的数目 。
    /// 
    /// </summary>
    public class Count_Symmetric_Integers
    {
        /// <summary>
        /// 枚举
        /// 数据量小的情况下的面向数据范围编程
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int CountSymmetricIntegers(int low, int high)
        {
            int res = 0;
            for (int a = low; a <= high; ++a)
            {
                if (a < 100 && a % 11 == 0)
                {
                    res++;
                }
                else if (1000 <= a && a < 10000)
                {
                    int left = a / 1000 + (a % 1000) / 100;
                    int right = (a % 100) / 10 + a % 10;
                    if (left == right)
                    {
                        res++;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 暴力枚举
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public int CountSymmetricIntegers2(int low, int high)
        {
            int ans = 0;
            for (int i = low; i <= high; i++)
            {
                char[] crr = i.ToString().ToCharArray();
                int n = crr.Length;
                if (n % 2 == 0)
                {
                    int n2 = n / 2;
                    int s1 = 0;
                    int s2 = 0;
                    for (int j = 0; j < n2; j++)
                    {
                        s1 += crr[j] - 48;
                        s2 += crr[j + n2] - 48;
                    }
                    if (s1 == s2) ans++;
                }
            }
            return ans;
        }
    }
}
