using System.Collections;

namespace Code
{
    /// <summary>
    /// 416. Partition Equal Subset Sum
    /// 416. 分割等和子集
    /// 
    /// Given an integer array nums, return true if you can partition the array into two subsets such that the sum of the elements in both subsets is equal or false otherwise.
    /// 给你一个 只包含正整数 的 非空 数组 nums 。请你判断是否可以将这个数组分割成两个子集，使得两个子集的元素和相等。
    /// 
    /// </summary>
    public class Partition_Equal_Subset_Sum
    {
        /// <summary>
        /// 递归（超时）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            long sum = nums.Sum();

            if (sum % 2 == 1) return false;

            int n = nums.Length;

            for (var i = 0; i < n; i++)
            {
                if (Dfs(0, i, nums, sum / 2)) return true;
            }
            return false;

        }

        private bool Dfs(int val, int index, int[] nums, long target)
        {
            if (index == nums.Length || val > target)
            {
                return false;
            }

            if (val == target)
            {
                return true;
            }

            val += nums[index];

            for (var i = index; i < nums.Length; i++)
            {
                if (Dfs(val, i + 1, nums, target)) return true;
            }
            return false;
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition2(int[] nums)
        {
            int n = nums.Length;
            if (n < 2)
            {
                return false;
            }
            int sum = 0, maxNum = 0;
            foreach (var num in nums)
            {
                sum += num;
                maxNum = Math.Max(maxNum, num);
            }
            if (sum % 2 != 0)
            {
                return false;
            }
            int target = sum / 2;
            if (maxNum > target)
            {
                return false;
            }

            // dp[i][j] 表示从数组的 [0,i] 下标范围内选取若干个正整数（可以是 0 个），是否存在一种选取方案使得被选取的正整数的和等于 j。
            bool[][] dp = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new bool[target + 1];
                dp[i][0] = true;
            }
            dp[0][nums[0]] = true;
            for (int i = 1; i < n; i++)
            {
                int num = nums[i];
                for (int j = 1; j <= target; j++)
                {
                    if (j >= num)
                    {
                        dp[i][j] = dp[i - 1][j] | dp[i - 1][j - num];
                    }
                    else
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                }
            }
            return dp[n - 1][target];
        }

        /// <summary>
        /// 动态规划 + BitArray 优化
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition3(int[] nums)
        {
            int s = nums.Sum();
            if (s % 2 == 1) return false;
            BitArray b = new(s / 2 + 1);
            b[0] = true;
            foreach (int i in nums) b.Or(new BitArray(b).LeftShift(i));
            return b[s / 2];
        }
    }
}
