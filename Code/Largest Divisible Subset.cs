namespace Code
{
    /// <summary>
    /// 368. Largest Divisible Subset
    /// 368. 最大整除子集
    /// 
    /// Given a set of distinct positive integers nums, return the largest subset answer such that every pair (answer[i], answer[j]) of elements in this subset satisfies:
    /// 给你一个由 无重复 正整数组成的集合 nums ，请你找出并返回其中最大的整除子集 answer ，子集中每一元素对 (answer[i], answer[j]) 都应当满足：
    /// 
    /// * answer[i] % answer[j] == 0, or
    /// * answer[i] % answer[j] == 0，或
    /// 
    /// * answer[j] % answer[i] == 0
    /// * answer[j] % answer[i] == 0
    /// 
    /// If there are multiple solutions, return any of them.
    /// 如果存在多个有效解子集，返回其中任何一个均可。
    /// 
    /// </summary>
    public class Largest_Divisible_Subset
    {
        /// <summary>
        /// 动态规划
        /// 整除关系具有传递性，即如果 a % b == 0，并且 b % c == 0，那么 a % c == 0
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            int len = nums.Length;
            Array.Sort(nums);

            // 第 1 步：动态规划找出最大子集的个数、最大子集中的最大整数
            // dp[i] 表示在输入数组 nums 升序排列的前提下，以 nums[i] 为最大整数的「整除子集」的大小（在这种定义下 nums[i] 必须被选择）。
            int[] dp = new int[len];
            Array.Fill(dp, 1);
            int maxSize = 1;
            int maxVal = dp[0];
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // 题目中说「没有重复元素」很重要
                    if (nums[i] % nums[j] == 0)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }

                if (dp[i] > maxSize)
                {
                    maxSize = dp[i];
                    maxVal = nums[i];
                }
            }

            // 第 2 步：倒推获得最大子集
            var res = new List<int>();
            if (maxSize == 1)
            {
                res.Add(nums[0]);
                return res;
            }

            for (int i = len - 1; i >= 0 && maxSize > 0; i--)
            {
                if (dp[i] == maxSize && maxVal % nums[i] == 0)
                {
                    res.Add(nums[i]);
                    maxVal = nums[i];
                    maxSize--;
                }
            }
            return res;
        }
    }
}
