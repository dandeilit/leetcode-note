namespace Code
{
    /// <summary>
    /// 45. Jump Game II
    /// 
    /// You are given a 0-indexed array of integers nums of length n. You are initially positioned at nums[0].
    /// 给定一个长度为 n 的整数数组 nums，其索引为 0。您的初始位置为 nums[0]。
    /// 
    /// Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at nums[i], you can jump to any nums[i + j] where:
    /// 每个元素 nums[i] 表示从索引 i 向前跳跃的最大长度。换句话说，如果您位于 nums[i]，则可以跳转到任何 nums[i + j]，其中：
    /// 
    /// * 0 <= j <= nums[i]
    /// * i + j < n
    /// 
    /// Return the minimum number of jumps to reach nums[n - 1]. The test cases are generated such that you can reach nums[n - 1].
    /// 返回到达 nums[n - 1] 所需的最少跳跃次数。测试用例的生成方式使您可以到达 nums[n - 1]。
    /// 
    /// </summary>
    public class Jump
    {
        /// <summary>
        /// 贪心算法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Solution(int[] nums)
        {
            int maxPos = 0, end = 0, steps = 0;
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (maxPos >= i)
                {
                    maxPos = Math.Max(maxPos, i + nums[i]);
                    if (i == end)
                    {
                        end = maxPos;
                        ++steps;
                    }
                }
            }
            return steps;
        }
    }
}
