namespace Code
{
    /// <summary>
    /// 3287. Find the Maximum Sequence Value of Array
    /// 
    /// You are given an integer array nums and a positive integer k.
    /// 给定一个整数数组 nums 和一个正整数 k。
    /// 
    /// The value of a sequence seq of size 2 * x is defined as:
    /// 大小为 2 * x 的序列 seq 的值定义为：
    /// 
    /// * (seq[0] OR seq[1] OR ... OR seq[x - 1]) XOR (seq[x] OR seq[x + 1] OR ... OR seq[2 * x - 1]).
    /// 
    /// Return the maximum value of any subsequence of nums having size 2 * k.
    /// 返回大小为 2 * k 的任何 nums 子序列的最大值。
    /// 
    /// </summary>
    public class MaxValue
    {
        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution(int[] nums, int k)
        {
            var A = FindORs(nums, k);
            Array.Reverse(nums);
            var B = FindORs(nums, k);

            // 正反各算一遍，取值时避免交叉重复

            int mx = 0;
            for (int i = k - 1; i < nums.Length - k; i++)
            {
                foreach (int a in A[i])
                {
                    foreach (int b in B[nums.Length - i - 2])
                    {
                        mx = Math.Max(mx, a ^ b);
                    }
                }
            }
            return mx;
        }

        /// <summary>
        /// 求数组 nums 下所有 k 长度子数组可能的所有 OR 运算值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<HashSet<int>> FindORs(int[] nums, int k)
        {
            var dp = new List<HashSet<int>>();

            // 记录每个长度子数组的 OR 运算值，下一个长度子数组的 OR 运算值可使用上一个长度子数组的 OR 运算值计算
            var prev = new List<HashSet<int>>();
            for (int i = 0; i <= k; i++)
            {
                prev.Add(new HashSet<int>());
            }
            prev[0].Add(0);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = Math.Min(k - 1, i + 1); j >= 0; j--)
                {
                    foreach (int x in prev[j])
                    {
                        prev[j + 1].Add(x | nums[i]);
                    }
                }
                dp.Add(new HashSet<int>(prev[k]));
            }
            return dp;
        }
    }
}
