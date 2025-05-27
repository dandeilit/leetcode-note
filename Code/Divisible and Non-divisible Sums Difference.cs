namespace Code
{
    /// <summary>
    /// 2894. Divisible and Non-divisible Sums Difference
    /// 2894. 分类求和并作差
    /// 
    /// You are given positive integers n and m.
    /// 给你两个正整数 n 和 m 。
    /// 
    /// Define two integers as follows:
    /// 现定义两个整数 num1 和 num2 ，如下所示：
    /// 
    /// * num1: The sum of all integers in the range [1, n] (both inclusive) that are not divisible by m.
    /// * num1：范围 [1, n] 内所有 无法被 m 整除 的整数之和。
    /// 
    /// * num2: The sum of all integers in the range [1, n] (both inclusive) that are divisible by m.
    /// * num2：范围 [1, n] 内所有 能够被 m 整除 的整数之和。
    /// 
    /// Return the integer num1 - num2.
    /// 返回整数 num1 - num2 。
    /// 
    /// </summary>
    public class Divisible_and_Non_divisible_Sums_Difference
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int DifferenceOfSums(int n, int m)
        {
            int num2 = 0;
            int num = m;
            while (num <= n)
            {
                num2 += num;
                num += m;
            }
            return (1 + n) * n / 2 - num2 - num2;
        }

        /// <summary>
        /// 数学推导
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int DifferenceOfSums2(int n, int m)
        {
            return (1 + n) * n / 2 - (m + n - n % m) * (n / m);
        }
    }
}
