namespace Code
{
    /// <summary>
    /// 1863. Sum of All Subset XOR Totals
    /// 1863. 找出所有子集的异或总和再求和
    /// 
    /// The XOR total of an array is defined as the bitwise XOR of all its elements, or 0 if the array is empty.
    /// 一个数组的 异或总和 定义为数组中所有元素按位 XOR 的结果；如果数组为 空 ，则异或总和为 0 。
    /// 
    /// For example, the XOR total of the array [2,5,6] is 2 XOR 5 XOR 6 = 1.
    /// 例如，数组 [2,5,6] 的 异或总和 为 2 XOR 5 XOR 6 = 1 。
    /// 
    /// Given an array nums, return the sum of all XOR totals for every subset of nums. 
    /// 给你一个数组 nums ，请你求出 nums 中每个 子集 的 异或总和 ，计算并返回这些值相加之 和 。
    /// 
    /// Note: Subsets with the same elements should be counted multiple times.
    /// 注意：在本题中，元素 相同 的不同子集应 多次 计数。
    /// 
    /// An array a is a subset of an array b if a can be obtained from b by deleting some (possibly zero) elements of b.
    /// 数组 a 是数组 b 的一个 子集 的前提条件是：从 b 删除几个（也可能不删除）元素能够得到 a 。
    /// 
    /// </summary>
    public class Sum_of_All_Subset_XOR_Totals
    {
        int res;
        int n;

        // 深度优先搜索
        void Dfs(int val, int idx, int[] nums)
        {
            if (idx == n)
            {
                // 终止递归
                res += val;
                return;
            }
            // 考虑选择当前数字
            Dfs(val ^ nums[idx], idx + 1, nums);
            // 考虑不选择当前数字
            Dfs(val, idx + 1, nums);
        }

        public int SubsetXORSum(int[] nums)
        {
            res = 0;
            n = nums.Length;
            Dfs(0, 0, nums);
            return res;
        }

        /// <summary>
        /// 按位考虑 + 二项式展开
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SubsetXORSum2(int[] nums)
        {
            int res = 0;
            int n = nums.Length;
            foreach (int num in nums)
            {
                res |= num;
            }
            return res << (n - 1);
        }
    }
}
