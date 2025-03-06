namespace Code
{
    /// <summary>
    /// 2588. Count the Number of Beautiful Subarrays
    /// 
    /// You are given a 0-indexed integer array nums. In one operation, you can:
    /// 给定一个 0 索引整数数组 nums。在一次操作中，您可以：
    /// 
    /// * Choose two different indices i and j such that 0 <= i, j < nums.length.
    /// * 选择两个不同的索引 i 和 j，使得 0 <= i, j < nums.length。
    /// 
    /// * Choose a non-negative integer k such that the k-th bit (0-indexed) in the binary representation of nums[i] and nums[j] is 1.
    /// * 选择一个非负整数 k，使得 nums[i] 和 nums[j] 的二进制表示中的第 k 位（0 索引）为 1。
    /// 
    /// * Subtract Math.Pow(2, k) from nums[i] and nums[j].
    /// * 从 nums[i] 和 nums[j] 中减去 Math.Pow(2, k)。
    /// 
    /// A subarray is beautiful if it is possible to make all of its elements equal to 0 after applying the above operation any number of times.
    /// 如果在应用上述操作任意次数后可以使子数组的所有元素都等于 0，则该子数组是漂亮的。
    /// 
    /// Return the number of beautiful subarrays in the array nums.
    /// 返回数组 nums 中漂亮子数组的数量。
    /// 
    /// A subarray is a contiguous non-empty sequence of elements within an array.
    /// 子数组是数组内连续的非空元素序列。
    /// 
    /// </summary>
    public class Count_the_Number_of_Beautiful_Subarrays
    {
        /// <summary>
        /// 前缀和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long BeautifulSubarrays(int[] nums)
        {
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            int mask = 0;
            long ans = 0;
            cnt[0] = 1;
            foreach (int x in nums)
            {
                mask ^= x;
                if (cnt.ContainsKey(mask))
                {
                    ans += cnt[mask];
                }
                if (cnt.ContainsKey(mask))
                {
                    cnt[mask]++;
                }
                else
                {
                    cnt[mask] = 1;
                }
            }
            return ans;
        }
    }
}
