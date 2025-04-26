namespace Code
{
    /// <summary>
    /// 2444. Count Subarrays With Fixed Bounds
    /// 2444. 统计定界子数组的数目
    /// 
    /// You are given an integer array nums and two integers minK and maxK.
    /// 给你一个整数数组 nums 和两个整数 minK 以及 maxK 。
    /// 
    /// A fixed-bound subarray of nums is a subarray that satisfies the following conditions:
    /// nums 的定界子数组是满足下述条件的一个子数组：
    /// 
    /// * The minimum value in the subarray is equal to minK.
    /// * 子数组中的 最小值 等于 minK 。
    /// 
    /// * The maximum value in the subarray is equal to maxK.
    /// * 子数组中的 最大值 等于 maxK 。
    /// 
    /// Return the number of fixed-bound subarrays.
    /// 返回定界子数组的数目。
    /// 
    /// A subarray is a contiguous part of an array.
    /// 子数组是数组中的一个连续部分。
    /// 
    /// </summary>
    public class Count_Subarrays_With_Fixed_Bounds
    {
        /// <summary>
        /// 一次遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="minK"></param>
        /// <param name="maxK"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, int minK, int maxK)
        {
            long res = 0;
            // border 为段左边界
            int border = -1, last_min = -1, last_max = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                // 当前值不可存在子数组内，设为边界
                if (nums[i] < minK || nums[i] > maxK)
                {
                    last_max = -1;
                    last_min = -1;
                    border = i;
                }

                // 标定下边界
                if (nums[i] == minK)
                {
                    last_min = i;
                }

                // 标定上边界
                if (nums[i] == maxK)
                {
                    last_max = i;
                }

                if (last_min != -1 && last_max != -1)
                {
                    res += Math.Min(last_min, last_max) - border;
                }
            }
            return res;
        }
    }
}
