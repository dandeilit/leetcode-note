namespace Code
{
    /// <summary>
    /// 2845. Count of Interesting Subarrays
    /// 2845. 统计趣味子数组的数目
    /// 
    /// You are given a 0-indexed integer array nums, an integer modulo, and an integer k.
    /// 给你一个下标从 0 开始的整数数组 nums ，以及整数 modulo 和整数 k 。
    /// 
    /// Your task is to find the count of subarrays that are interesting.
    /// 请你找出并统计数组中 趣味子数组 的数目。
    /// 
    /// A subarray nums[l..r] is interesting if the following condition holds:
    /// 如果 子数组 nums[l..r] 满足下述条件，则称其为 趣味子数组 ：
    /// 
    /// * Let cnt be the number of indices i in the range [l, r] such that nums[i] % modulo == k. Then, cnt % modulo == k.
    /// * 在范围 [l, r] 内，设 cnt 为满足 nums[i] % modulo == k 的索引 i 的数量。并且 cnt % modulo == k 。
    /// 
    /// Return an integer denoting the count of interesting subarrays.
    /// 以整数形式表示并返回趣味子数组的数目。
    /// 
    /// Note: A subarray is a contiguous non-empty sequence of elements within an array.
    /// 注意：子数组是数组中的一个连续非空的元素序列。
    /// 
    /// </summary>
    public class Count_of_Interesting_Subarrays
    {
        /// <summary>
        /// 超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="modulo"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
        {
            int n = nums.Count;
            bool[] checks = new bool[n];
            for (var i = 0; i < n; i++)
            {
                checks[i] = nums[i] % modulo == k;
            }

            long ans = 0;
            for (var i = 0; i < n; i++)
            {
                long cnt = 0;
                for (var j = i; j < n; j++)
                {
                    cnt += checks[j] ? 1 : 0;
                    if (cnt % modulo == k) ans++;
                }
            }
            return ans;
        }

        /// <summary>
        /// 前缀和
        /// sum[i] 表示数组 nums 索引从 0 到 i 中出现满足 x mod modulo = k 特殊元素的数目
        /// (sum[r]−sum[l−1]) mod modulo = k
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="modulo"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountInterestingSubarrays2(IList<int> nums, int modulo, int k)
        {
            int n = nums.Count;

            // 当前已遍历的前缀中 sum[i] mod modulo 的数目
            Dictionary<int, int> cnt = new Dictionary<int, int>();

            long res = 0;
            int prefix = 0;
            cnt[0] = 1;
            for (int i = 0; i < n; i++)
            {
                prefix += nums[i] % modulo == k ? 1 : 0;
                res += cnt.ContainsKey((prefix - k + modulo) % modulo) ? cnt[(prefix - k + modulo) % modulo] : 0;
                if (cnt.ContainsKey(prefix % modulo))
                {
                    cnt[prefix % modulo]++;
                }
                else
                {
                    cnt[prefix % modulo] = 1;
                }
            }
            return res;
        }
    }
}
