namespace Code
{
    /// <summary>
    /// 2364. Count Number of Bad Pairs
    /// 2364. 统计坏数对的数目
    /// 
    /// You are given a 0-indexed integer array nums. A pair of indices (i, j) is a bad pair if i < j and j - i != nums[j] - nums[i].
    /// 给你一个下标从 0 开始的整数数组 nums 。如果 i < j 且 j - i != nums[j] - nums[i] ，那么我们称 (i, j) 是一个 坏数对 。
    /// 
    /// Return the total number of bad pairs in nums.
    /// 请你返回 nums 中 坏数对 的总数目。
    /// 
    /// </summary>
    public class Count_Number_of_Bad_Pairs
    {
        /// <summary>
        /// 遍历数对
        /// 超时
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long CountBadPairs(int[] nums)
        {
            long ans = 0;
            int n = nums.Length;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (nums[j] - nums[i] != j - i)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// 哈希表
        /// nums[i]−i != nums[j]−j
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long CountBadPairs2(int[] nums)
        {
            Dictionary<int, int> mp = new Dictionary<int, int>();
            long res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int key = nums[i] - i;
                mp.TryGetValue(key, out int count);
                res += i - count;
                mp[key] = count + 1;
            }
            return res;
        }
    }
}
