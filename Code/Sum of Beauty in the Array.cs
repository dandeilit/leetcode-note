namespace Code
{
    /// <summary>
    /// 2012. Sum of Beauty in the Array
    /// 
    /// You are given a 0-indexed integer array nums. For each index i (1 <= i <= nums.length - 2) the beauty of nums[i] equals:
    /// 给你一个下标从 0 开始的整数数组 nums 。对于每个下标 i（1 <= i <= nums.length - 2），nums[i] 的 美丽值 等于：
    /// 
    /// * 2, if nums[j] < nums[i] < nums[k], for all 0 <= j < i and for all i < k <= nums.length - 1.
    /// * 2，对于所有 0 <= j < i 且 i < k <= nums.length - 1 ，满足 nums[j] < nums[i] < nums[k]
    /// 
    /// * 1, if nums[i - 1] < nums[i] < nums[i + 1], and the previous condition is not satisfied.
    /// * 1，如果满足 nums[i - 1] < nums[i] < nums[i + 1] ，且不满足前面的条件
    /// 
    /// * 0, if none of the previous conditions holds.
    /// * 0，如果上述条件全部不满足
    /// 
    /// Return the sum of beauty of all nums[i] where 1 <= i <= nums.length - 2.
    /// 返回符合 1 <= i <= nums.length - 2 的所有 nums[i] 的 美丽值的总和 。
    /// 
    /// 比左边所有数字都大，比右边所有数字都小的位置+2分，只比相邻左边大、相邻右边小的位置+1分，否则不加分
    /// </summary>
    public class Sum_of_Beauty_in_the_Array
    {
        public int SumOfBeauties(int[] nums)
        {
            int n = nums.Length;
            int[] state = new int[n];
            int pre_max = nums[0];
            for (int i = 1; i < n - 1; i++)
            {
                if (nums[i] > pre_max)
                {
                    state[i] = 1;
                    pre_max = nums[i];
                }
            }
            int suf_min = nums[n - 1];
            int res = 0;
            for (int i = n - 2; i > 0; i--)
            {
                if (state[i] == 1 && nums[i] < suf_min)
                {
                    res += 2;
                }
                else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1])
                {
                    res += 1;
                }
                suf_min = Math.Min(suf_min, nums[i]);
            }
            return res;
        }
    }
}
