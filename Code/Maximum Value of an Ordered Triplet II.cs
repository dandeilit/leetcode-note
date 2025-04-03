namespace Code
{
    /// <summary>
    /// 2874. Maximum Value of an Ordered Triplet II
    /// 2874. 有序三元组中的最大值 II
    /// 
    /// You are given a 0-indexed integer array nums.
    /// 给你一个下标从 0 开始的整数数组 nums 。
    /// 
    /// Return the maximum value over all triplets of indices (i, j, k) such that i < j < k. If all such triplets have a negative value, return 0.
    /// 请你从所有满足 i < j < k 的下标三元组 (i, j, k) 中，找出并返回下标三元组的最大值。如果所有满足条件的三元组的值都是负数，则返回 0 。
    /// 
    /// The value of a triplet of indices (i, j, k) is equal to (nums[i] - nums[j]) * nums[k].
    /// 下标三元组 (i, j, k) 的值等于 (nums[i] - nums[j]) * nums[k] 。
    /// 
    /// </summary>
    public class Maximum_Value_of_an_Ordered_Triplet_II
    {
        /// <summary>
        /// 贪心 + 前后缀数组
        /// 当固定 j 时，nums[i] 和 nums[k] 分别取 [0,j) 和 [j+1,n) 的最大值时，三元组的值最大。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue(int[] nums)
        {
            int n = nums.Length;
            int[] leftMax = new int[n];
            int[] rightMax = new int[n];
            for (int i = 1; i < n; i++)
            {
                leftMax[i] = Math.Max(leftMax[i - 1], nums[i - 1]);
                rightMax[n - 1 - i] = Math.Max(rightMax[n - i], nums[n - i]);
            }
            long res = 0;
            for (int j = 1; j < n - 1; j++)
            {
                res = Math.Max(res, (long)(leftMax[j] - nums[j]) * rightMax[j]);
            }
            return res;
        }

        /// <summary>
        /// 贪心
        /// 用 imax 维护 nums[i] 的最大值，dmax 维护 nums[i]−nums[j] 的最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaximumTripletValue2(int[] nums)
        {
            int n = nums.Length;
            long res = 0, imax = 0, dmax = 0;
            for (int k = 0; k < n; k++)
            {
                res = Math.Max(res, dmax * nums[k]);
                dmax = Math.Max(dmax, imax - nums[k]);
                imax = Math.Max(imax, nums[k]);
            }
            return res;
        }
    }
}
