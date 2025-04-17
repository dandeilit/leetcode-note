namespace Code
{
    /// <summary>
    /// 2176. Count Equal and Divisible Pairs in an Array
    /// 2176. 统计数组中相等且可以被整除的数对
    /// 
    /// Given a 0-indexed integer array nums of length n and an integer k, return the number of pairs (i, j) where 0 <= i < j < n, such that nums[i] == nums[j] and (i * j) is divisible by k.
    /// 给你一个下标从 0 开始长度为 n 的整数数组 nums 和一个整数 k ，请你返回满足 0 <= i < j < n ，nums[i] == nums[j] 且 (i * j) 能被 k 整除的数对 (i, j) 的 数目 。
    /// 
    /// </summary>
    public class Count_Equal_and_Divisible_Pairs_in_an_Array
    {
        /// <summary>
        /// 遍历数对
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountPairs(int[] nums, int k)
        {
            int ans = 0;
            int n = nums.Length;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (nums[i] == nums[j] && i * j % k == 0)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }
    }
}
