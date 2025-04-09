namespace Code
{
    /// <summary>
    /// 3375. Minimum Operations to Make Array Values Equal to K
    /// 3375. 使数组的值全部为 K 的最少操作次数
    /// 
    /// You are given an integer array nums and an integer k.
    /// 给你一个整数数组 nums 和一个整数 k 。
    /// 
    /// An integer h is called valid if all values in the array that are strictly greater than h are identical.
    /// 如果一个数组中所有 严格大于 h 的整数值都 相等 ，那么我们称整数 h 是 合法的 。
    /// 
    /// For example, if nums = [10, 8, 10, 8], a valid integer is h = 9 because all nums[i] > 9 are equal to 10, but 5 is not a valid integer.
    /// 比方说，如果 nums = [10, 8, 10, 8] ，那么 h = 9 是一个 合法 整数，因为所有满足 nums[i] > 9 的数都等于 10 ，但是 5 不是 合法 整数。
    /// 
    /// You are allowed to perform the following operation on nums:
    /// 你可以对 nums 执行以下操作：
    /// 
    /// * Select an integer h that is valid for the current values in nums.
    /// * 选择一个整数 h ，它对于 当前 nums 中的值是合法的。
    /// 
    /// * For each index i where nums[i] > h, set nums[i] to h.
    /// * 对于每个下标 i ，如果它满足 nums[i] > h ，那么将 nums[i] 变为 h 。
    /// 
    /// Return the minimum number of operations required to make every element in nums equal to k. If it is impossible to make all elements equal to k, return -1.
    /// 你的目标是将 nums 中的所有元素都变为 k ，请你返回 最少 操作次数。如果无法将所有元素都变 k ，那么返回 -1 。
    /// 
    /// </summary>
    public class Minimum_Operations_to_Make_Array_Values_Equal_to_K
    {
        public int MinOperations(int[] nums, int k)
        {
            Array.Sort(nums);

            if (nums[0] < k) return -1;

            int num = nums[0] == k ? 0 : 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1]) num++;
            }
            return num;
        }

        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinOperations2(int[] nums, int k)
        {
            HashSet<int> st = new HashSet<int>();
            foreach (int x in nums)
            {
                if (x < k)
                {
                    return -1;
                }
                else if (x > k)
                {
                    st.Add(x);
                }
            }
            return st.Count;
        }
    }
}
