﻿namespace Code
{
    /// <summary>
    /// 3095. Shortest Subarray With OR at Least K I
    /// 
    /// You are given an array nums of non-negative integers and an integer k.
    /// 给定一个非负整数数组 nums 和一个整数 k 。
    /// 
    /// An array is called special if the bitwise OR of all of its elements is at least k.
    /// 如果一个数组的所有元素按位 OR 至少为 k 则该数组被称为特殊数组。
    /// 
    /// Return the length of the shortest special non-empty subarray of nums, or return -1 if no special subarray exists.
    /// 返回 nums 的最短特殊非空子数组的长度，如果不存在特殊子数组则返回 -1。
    /// 
    /// </summary>
    public class MinimumSubarrayLength
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution(int[] nums, int k)
        {
            int ans = int.MaxValue;
            for (var i = 0; i < nums.Length; i++)
            {
                int val = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    val |= nums[j];
                    if (val >= k)
                    {
                        ans = Math.Min(ans, j - i + 1);
                        break;
                    }
                }
            }
            return ans == int.MaxValue ? -1 : ans;
        }

        /// <summary>
        /// 滑动窗口
        /// 利用 A|B >= A 的原理
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution2(int[] nums, int k)
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
