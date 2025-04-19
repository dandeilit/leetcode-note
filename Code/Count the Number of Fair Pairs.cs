namespace Code
{
    /// <summary>
    /// 2563. Count the Number of Fair Pairs
    /// 2563. 统计公平数对的数目
    /// 
    /// Given a 0-indexed integer array nums of size n and two integers lower and upper, return the number of fair pairs.
    /// 给你一个下标从 0 开始、长度为 n 的整数数组 nums ，和两个整数 lower 和 upper ，返回 公平数对的数目 。
    /// 
    /// A pair (i, j) is fair if:
    /// 如果 (i, j) 数对满足以下情况，则认为它是一个 公平数对 ：
    /// 
    /// * 0 <= i < j < n, and
    /// 
    /// * lower <= nums[i] + nums[j] <= upper
    /// 
    /// </summary>
    public class Count_the_Number_of_Fair_Pairs
    {
        /// <summary>
        /// 遍历数对
        /// 超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public long CountFairPairs(int[] nums, int lower, int upper)
        {
            long ans = 0;
            int n = nums.Length;
            for (var i = 0; i < n - 1; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    var sum = nums[i] + nums[j];
                    if (lower <= sum && sum <= upper)
                    {
                        ans++;
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// 二分查找
        /// 排序不影响计数结果
        /// 转换条件 lower−nums[j] ≤ nums[i] ≤ upper−nums[j]
        /// 可以找到 ≤upper−nums[j] 的元素个数，减去 <lower−nums[j] 的元素个数
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public long CountFairPairs2(int[] nums, int lower, int upper)
        {
            Array.Sort(nums);
            long ans = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                int r = LowerBound(nums, j, upper - nums[j] + 1);
                int l = LowerBound(nums, j, lower - nums[j]);
                ans += r - l;
            }

            return ans;
        }

        private int LowerBound(int[] nums, int right, int target)
        {
            int left = -1;
            while (left + 1 < right)
            {
                int mid = (left + right) >> 1;
                if (nums[mid] < target)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
            }
            return right;
        }

        /// <summary>
        /// 三指针
        /// left 表示 ≤upper−nums[j] 的最大元素位置
        /// right 表示 <lower−nums[j] 的最大元素位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public long CountFairPairs3(int[] nums, int lower, int upper)
        {
            Array.Sort(nums);
            long ans = 0;
            int left = nums.Length, right = nums.Length;

            for (int j = 0; j < nums.Length; ++j)
            {
                while (right > 0 && nums[right - 1] > upper - nums[j])
                {
                    right--;
                }
                while (left > 0 && nums[left - 1] >= lower - nums[j])
                {
                    left--;
                }
                ans += Math.Min(right, j) - Math.Min(left, j);
            }

            return ans;
        }
    }
}
