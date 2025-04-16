namespace Code
{
    /// <summary>
    /// 2537. Count the Number of Good Subarrays
    /// 2537. 统计好子数组的数目
    /// 
    /// Given an integer array nums and an integer k, return the number of good subarrays of nums.
    /// 给你一个整数数组 nums 和一个整数 k ，请你返回 nums 中 好 子数组的数目。
    /// 
    /// A subarray arr is good if there are at least k pairs of indices (i, j) such that i < j and arr[i] == arr[j].
    /// 一个子数组 arr 如果有 至少 k 对下标 (i, j) 满足 i < j 且 arr[i] == arr[j] ，那么称它是一个 好 子数组。
    /// 
    /// A subarray is a contiguous non-empty sequence of elements within an array.
    /// 子数组 是原数组中一段连续 非空 的元素序列。
    /// 
    /// </summary>
    public class Count_the_Number_of_Good_Subarrays
    {
        /// <summary>
        /// 动态规划
        /// 内存溢出
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountGood(int[] nums, int k)
        {
            //var minLen = Math.Round((Math.Sqrt(k * 8 + 1) - 1) / 2);
            int n = nums.Length;
            bool[][] dp = new bool[n][];
            for (var i = 0; i < n; i++)
            {
                dp[i] = new bool[n];
                Array.Fill(dp[i], false);
            }

            long ans = 0;
            for (var l = 0; l < n; l++)
            {
                for (var r = l + 1; r < n; r++)
                {
                    if (dp[l][r - 1])
                    {
                        dp[l][r] = true;
                        ans++;
                    }
                    else
                    {
                        dp[l][r] = CheckSub(l, r, nums, k);
                        if (dp[l][r]) ans++;
                    }
                }
            }
            return ans;
        }

        private bool CheckSub(int l, int r, int[] nums, int k)
        {
            if (l == r) return false;
            if (r > nums.Length - 1) r = nums.Length - 1;

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (var i = l; i <= r; i++)
            {
                if (!dic.ContainsKey(nums[i]))
                {
                    dic.Add(nums[i], 1);
                }
                else
                {
                    dic[nums[i]]++;
                }
            }

            long res = 0;
            foreach (var val in dic.Values)
            {
                res += val * (val - 1) / 2;
            }
            return res >= k;
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountGood2(int[] nums, int k)
        {
            int n = nums.Length;
            int same = 0, right = -1;
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            long ans = 0;
            for (int left = 0; left < n; ++left)
            {
                while (same < k && right + 1 < n)
                {
                    ++right;
                    cnt.TryGetValue(nums[right], out int current);
                    same += current;
                    cnt[nums[right]] = current + 1;
                }
                if (same >= k)
                {
                    ans += n - right;
                }
                cnt[nums[left]] = cnt[nums[left]] - 1;
                same -= cnt[nums[left]];
            }
            return ans;
        }
    }
}
