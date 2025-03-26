namespace Code
{
    /// <summary>
    /// 2829. Determine the Minimum Sum of a k-avoiding Array
    /// 2829. k-avoiding 数组的最小总和
    /// 
    /// You are given two integers, n and k.
    /// 给你两个整数 n 和 k 。
    /// 
    /// An array of distinct positive integers is called a k-avoiding array if there does not exist any pair of distinct elements that sum to k.
    /// 对于一个由 不同 正整数组成的数组，如果其中不存在任何求和等于 k 的不同元素对，则称其为 k-avoiding 数组。
    /// 
    /// Return the minimum possible sum of a k-avoiding array of length n.
    /// 返回长度为 n 的 k-avoiding 数组的可能的最小总和。
    /// 
    /// </summary>
    public class Determine_the_Minimum_Sum_of_a_k_avoiding_Array
    {
        public int MinimumSum(int n, int k)
        {
            if (n <= k / 2)
            {
                return (n * (n + 1) / 2);
            }
            else
            {
                return ((k / 2 + 1) * (k / 2) / 2 + ((2 * n + k * 3 - 1) / 2) * (n - k / 2) / 2);
            }
        }

        /// <summary>
        /// 贪心 + 等差数列求和
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumSum2(int n, int k)
        {
            if (n <= k / 2)
            {
                return ArithmeticSeriesSum(1, 1, n);
            }
            else
            {
                return ArithmeticSeriesSum(1, 1, k / 2) + ArithmeticSeriesSum(k, 1, n - k / 2);
            }
        }

        private int ArithmeticSeriesSum(int a1, int d, int n)
        {
            return (a1 + a1 + (n - 1) * d) * n / 2;
        }
    }
}
