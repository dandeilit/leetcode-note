namespace Code
{
    /// <summary>
    /// 2302. Count Subarrays With Score Less Than K
    /// 2302. 统计得分小于 K 的子数组数目
    /// 
    /// The score of an array is defined as the product of its sum and its length.
    /// 一个数组的 分数 定义为数组之和 乘以 数组的长度。
    /// 
    /// * For example, the score of [1, 2, 3, 4, 5] is (1 + 2 + 3 + 4 + 5) * 5 = 75.
    /// * 比方说，[1, 2, 3, 4, 5] 的分数为 (1 + 2 + 3 + 4 + 5) * 5 = 75 。
    /// 
    /// Given a positive integer array nums and an integer k, return the number of non-empty subarrays of nums whose score is strictly less than k.
    /// 给你一个正整数数组 nums 和一个整数 k ，请你返回 nums 中分数 严格小于 k 的 非空整数子数组数目。
    /// 
    /// A subarray is a contiguous sequence of elements within an array.
    /// 子数组 是数组中的一个连续元素序列。
    /// 
    /// </summary>
    public class Count_Subarrays_With_Score_Less_Than_K
    {
        /// <summary>
        /// 滑动窗口
        /// i 为子数组左端点，j 为子数组右端点
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, long k)
        {
            int n = nums.Length;
            long res = 0, total = 0;
            for (int i = 0, j = 0; j < n; j++)
            {
                total += nums[j];
                while (i <= j && total * (j - i + 1) >= k)
                {
                    total -= nums[i];
                    i++;
                }
                res += j - i + 1;
            }
            return res;
        }
    }
}
