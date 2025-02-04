namespace Code
{
    /// <summary>
    /// 922. Sort Array By Parity II
    /// 
    /// Given an array of integers nums, half of the integers in nums are odd, and the other half are even.
    /// 给定一个整数数组 nums，nums 中一半的整数是奇数，另一半是偶数。
    /// 
    /// Sort the array so that whenever nums[i] is odd, i is odd, and whenever nums[i] is even, i is even.
    /// 对数组进行排序，使得每当 nums[i] 为奇数时，i 也为奇数，每当 nums[i] 为偶数时，i 也为偶数。
    /// 
    /// Return any answer array that satisfies this condition.
    /// 返回满足此条件的任何答案数组。
    /// 
    /// Follow Up: Could you solve it in-place?
    /// 进阶：你能就地解决它吗？
    /// 
    /// </summary>
    public class Sort_Array_By_Parity_II
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayByParityII(int[] nums)
        {
            int i = 0, j = 1;
            int n = nums.Length;
            while (i < n)
            {
                if (nums[i] % 2 == 0)
                {
                    i += 2;
                }
                else if (nums[j] % 2 == 1)
                {
                    j += 2;
                }
                else
                {
                    int tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                    i += 2;
                    j += 2;
                }
            }
            return nums;
        }
    }
}
