namespace Code
{
    /// <summary>
    /// 3423. Maximum Difference Between Adjacent Elements in a Circular Array
    /// 3423. 循环数组中相邻元素的最大差值
    /// 
    /// Given a circular array nums, find the maximum absolute difference between adjacent elements.
    /// 给你一个 循环 数组 nums ，请你找出相邻元素之间的 最大 绝对差值。
    /// 
    /// Note: In a circular array, the first and last elements are adjacent.
    /// 注意：一个循环数组中，第一个元素和最后一个元素是相邻的。
    /// 
    /// </summary>
    public class Maximum_Difference_Between_Adjacent_Elements_in_a_Circular_Array
    {
        public int MaxAdjacentDistance(int[] nums)
        {
            int n = nums.Length;
            int diff = Math.Abs(nums[0] - nums[n - 1]);
            for (var i = 1; i < n; i++)
            {
                diff = Math.Max(diff, Math.Abs(nums[i] - nums[i - 1]));
            }
            return diff;
        }
    }
}
