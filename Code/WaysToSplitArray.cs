namespace Code
{
    /// <summary>
    /// 2270. Number of Ways to Split Array
    /// 
    /// You are given a 0-indexed integer array nums of length n.
    /// 给定一个长度为n的0 索引整数数组nums 。
    /// 
    /// nums contains a valid split at index i if the following are true:
    /// 如果满足以下条件， nums在索引i处包含有效的分割：
    /// 
    /// * The sum of the first i + 1 elements is greater than or equal to the sum of the last n - i - 1 elements.
    /// 前i + 1元素的总和大于或等于后n - i - 1元素的总和。
    /// 
    /// * There is at least one element to the right of i. That is, 0 <= i < n - 1.
    /// i右侧至少有一个元素。即， 0 <= i < n - 1 。
    /// 
    /// Return the number of valid splits in nums.
    /// 返回 nums 中有效分割的数量。
    /// 
    /// </summary>
    public class WaysToSplitArray
    {
        public int Solution(int[] nums)
        {
            int ans = 0;
            long l = 0;
            long r = nums.Sum(x => (long)x);

            for (var i = 0; i < nums.Length - 1; i++)
            {
                l += nums[i];
                r -= nums[i];

                if (l >= r)
                {
                    ans++;
                }
            }

            return ans;
        }
    }
}
