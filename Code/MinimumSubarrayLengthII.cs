namespace Code
{
    /// <summary>
    /// 3097. Shortest Subarray With OR at Least K II
    /// 
    /// You are given an array nums of non-negative integers and an integer k.
    /// 给定一个非负整数数组 nums 和一个整数 k。
    /// 
    /// An array is called special if the bitwise OR of all of its elements is at least k.
    /// 如果数组所有元素的按位或至少为 k，则该数组称为特殊数组。
    /// 
    /// Return the length of the shortest special non-empty subarray of nums, or return -1 if no special subarray exists.
    /// 返回 nums 的最短特殊非空子数组的长度，如果不存在特殊子数组，则返回 -1。
    /// 
    /// </summary>
    public class MinimumSubarrayLengthII
    {
        /// <summary>
        /// 滑动窗口
        /// 利用 A|B >= A 的原理
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution(int[] nums, int k)
        {
            int n = nums.Length;
            int[] bits = new int[30];  // 记录维护按位或结果
            int res = int.MaxValue;

            for (int left = 0, right = 0; right < n; right++)
            {
                for (int i = 0; i < 30; i++) // 右侧按位或计算
                {
                    bits[i] += (nums[right] >> i) & 1;
                }
                while (left <= right && Calc(bits) >= k)
                {
                    // 比较子数组长度
                    res = Math.Min(res, right - left + 1);

                    // 去除左侧按位或计算
                    for (int i = 0; i < 30; i++)
                    {
                        bits[i] -= (nums[left] >> i) & 1;
                    }
                    left++;
                }
            }

            return res == int.MaxValue ? -1 : res;
        }

        /// <summary>
        /// 按位或结果还原
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        private int Calc(int[] bits)
        {
            int ans = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] > 0)
                {
                    ans |= 1 << i;
                }
            }
            return ans;
        }
    }
}
