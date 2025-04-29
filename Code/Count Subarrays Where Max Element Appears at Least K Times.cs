namespace Code
{
    /// <summary>
    /// 2962. Count Subarrays Where Max Element Appears at Least K Times
    /// 2962. 统计最大元素出现至少 K 次的子数组
    /// 
    /// You are given an integer array nums and a positive integer k.
    /// 给你一个整数数组 nums 和一个 正整数 k 。
    /// 
    /// Return the number of subarrays where the maximum element of nums appears at least k times in that subarray.
    /// 请你统计有多少满足 「 nums 中的 最大 元素」至少出现 k 次的子数组，并返回满足这一条件的子数组的数目。
    /// 
    /// A subarray is a contiguous sequence of elements within an array.
    /// 子数组是数组中的一个连续元素序列。
    /// 
    /// </summary>
    public class Count_Subarrays_Where_Max_Element_Appears_at_Least_K_Times
    {
        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountSubarrays(int[] nums, int k)
        {
            int mx = nums.Max();
            long ans = 0;
            int cnt = 0, left = 0;
            foreach (int x in nums)
            {
                if (x == mx)
                {
                    cnt++;
                }
                while (cnt == k)
                {
                    if (nums[left] == mx)
                    {
                        cnt--;
                    }
                    left++;
                }
                ans += left;
            }
            return ans;
        }
    }
}
