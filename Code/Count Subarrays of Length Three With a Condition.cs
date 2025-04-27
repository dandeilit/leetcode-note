namespace Code
{
    /// <summary>
    /// 3392. Count Subarrays of Length Three With a Condition
    /// 3392. 统计符合条件长度为 3 的子数组数目
    /// 
    /// Given an integer array nums, return the number of subarrays of length 3 such that the sum of the first and third numbers equals exactly half of the second number.
    /// 给你一个整数数组 nums ，请你返回长度为 3 的 子数组 的数量，满足第一个数和第三个数的和恰好为第二个数的一半。
    /// 
    /// A subarray is a contiguous part of an array.
    /// 子数组 指的是一个数组中连续 非空 的元素序列。
    /// 
    /// </summary>
    public class Count_Subarrays_of_Length_Three_With_a_Condition
    {
        public int CountSubarrays(int[] nums)
        {
            int ans = 0;
            for (var i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i + 1] == (nums[i] + nums[i + 2]) << 1) ans++;
            }
            return ans;
        }
    }
}
