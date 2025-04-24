namespace Code
{
    /// <summary>
    /// 2799. Count Complete Subarrays in an Array
    /// 2799. 统计完全子数组的数目
    /// 
    /// You are given an array nums consisting of positive integers.
    /// 给你一个由 正 整数组成的数组 nums 。
    /// 
    /// We call a subarray of an array complete if the following condition is satisfied:
    /// 如果数组中的某个子数组满足下述条件，则称之为 完全子数组 ：
    /// 
    /// * The number of distinct elements in the subarray is equal to the number of distinct elements in the whole array.
    /// * 子数组中 不同 元素的数目等于整个数组不同元素的数目。
    /// 
    /// Return the number of complete subarrays.
    /// 返回数组中 完全子数组 的数目。
    /// 
    /// A subarray is a contiguous non-empty part of an array.
    /// 子数组 是数组中的一个连续非空序列。
    /// 
    /// </summary>
    public class Count_Complete_Subarrays_in_an_Array
    {
        /// <summary>
        /// 超时
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountCompleteSubarrays(int[] nums)
        {
            HashSet<int> map = new HashSet<int>();
            foreach (var num in nums)
            {
                if (!map.Contains(num))
                {
                    map.Add(num);
                }
            }

            int ans = 0;
            int n = nums.Length;
            bool[,] dp = new bool[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = i; j < n; j++)
                {
                    if (i == j || dp[i, j - 1] == false)
                    {
                        HashSet<int> newMap = new HashSet<int>();
                        for (var x = i; x <= j; x++)
                        {
                            if (!newMap.Contains(nums[x]))
                            {
                                newMap.Add(nums[x]);
                            }
                        }
                        dp[i, j] = newMap.Count == map.Count;

                        if (dp[i, j]) ans++;

                        continue;
                    }

                    if (dp[i, j - 1])
                    {
                        dp[i, j] = true;
                        ans++;
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountCompleteSubarrays2(int[] nums)
        {
            int res = 0;
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            int n = nums.Length;
            int right = 0;
            int distinct = new HashSet<int>(nums).Count;

            for (int left = 0; left < n; left++)
            {
                if (left > 0)
                {
                    int remove = nums[left - 1];
                    cnt[remove]--;
                    if (cnt[remove] == 0)
                    {
                        cnt.Remove(remove);
                    }
                }
                while (right < n && cnt.Count < distinct)
                {
                    int add = nums[right];
                    if (!cnt.ContainsKey(add))
                    {
                        cnt[add] = 0;
                    }
                    cnt[add]++;
                    right++;
                }
                if (cnt.Count == distinct)
                {
                    res += (n - right + 1);
                }
            }
            return res;
        }
    }
}
