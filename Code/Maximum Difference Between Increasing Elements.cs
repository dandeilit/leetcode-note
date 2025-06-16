namespace Code
{
    /// <summary>
    /// 2016. Maximum Difference Between Increasing Elements
    /// 2016. 增量元素之间的最大差值
    /// 
    /// Given a 0-indexed integer array nums of size n, find the maximum difference between nums[i] and nums[j] (i.e., nums[j] - nums[i]), such that 0 <= i < j < n and nums[i] < nums[j].
    /// 给你一个下标从 0 开始的整数数组 nums ，该数组的大小为 n ，请你计算 nums[j] - nums[i] 能求得的 最大差值 ，其中 0 <= i < j < n 且 nums[i] < nums[j] 。
    /// 
    /// Return the maximum difference. If no such i and j exists, return -1.
    /// 返回 最大差值 。如果不存在满足要求的 i 和 j ，返回 -1 。
    /// 
    /// </summary>
    public class Maximum_Difference_Between_Increasing_Elements
    {
        public int MaximumDifference(int[] nums)
        {
            int ans = -1;
            int n = nums.Length;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        ans = Math.Max(ans, nums[j] - nums[i]);
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// 前缀最小值
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumDifference2(int[] nums)
        {
            int ans = -1;
            int l = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                if (nums[i] <= l) l = nums[i];
                else ans = Math.Max(ans, nums[i] - l);
            }
            return ans;
        }
    }
}
