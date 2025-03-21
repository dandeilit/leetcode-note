namespace Code
{
    /// <summary>
    /// 2680. Maximum OR
    /// 
    /// You are given a 0-indexed integer array nums of length n and an integer k. In an operation, you can choose an element and multiply it by 2.
    /// 给你一个下标从 0 开始长度为 n 的整数数组 nums 和一个整数 k 。每一次操作中，你可以选择一个数并将它乘 2 。
    /// 
    /// Return the maximum possible value of nums[0] | nums[1] | ... | nums[n - 1] that can be obtained after applying the operation on nums at most k times.
    /// 你最多可以进行 k 次操作，请你返回 nums[0] | nums[1] | ... | nums[n - 1] 的最大值。
    /// 
    /// Note that a | b denotes the bitwise or between two integers a and b.
    /// a | b 表示两个整数 a 和 b 的 按位或 运算。
    /// 
    /// </summary>
    public class Maximum_OR
    {
        /// <summary>
        /// 贪心 + 前缀和
        /// 前部分统计 | 当前值 << k | 后部分统计
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaximumOr(int[] nums, int k)
        {
            int n = nums.Length;
            long[] suf = new long[n + 1];
            for (int i = n - 1; i >= 0; i--)
            {
                suf[i] = suf[i + 1] | nums[i];
            }
            long res = 0, pre = 0;
            for (int i = 0; i < n; i++)
            {
                res = Math.Max(res, pre | ((long)nums[i] << k) | suf[i + 1]);
                pre |= nums[i];
            }
            return res;
        }

        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long MaximumOr2(int[] nums, int k)
        {
            long orSum = 0, multiBits = 0;
            foreach (int x in nums)
            {
                multiBits |= x & orSum;
                orSum |= x;
            }
            long res = 0;
            foreach (int x in nums)
            {
                res = Math.Max(res, (orSum ^ x) | ((long)x << k) | multiBits);
            }
            return res;
        }
    }
}
