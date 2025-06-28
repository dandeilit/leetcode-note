namespace Code
{
    /// <summary>
    /// 2099. Find Subsequence of Length K With the Largest Sum
    /// 2099. 找到和最大的长度为 K 的子序列
    /// 
    /// You are given an integer array nums and an integer k. You want to find a subsequence of nums of length k that has the largest sum.
    /// 给你一个整数数组 nums 和一个整数 k 。你需要找到 nums 中长度为 k 的 子序列 ，且这个子序列的 和最大 。
    /// 
    /// Return any such subsequence as an integer array of length k.
    /// 请你返回 任意 一个长度为 k 的整数子序列。
    /// 
    /// A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
    /// 子序列 定义为从一个数组里删除一些元素后，不改变剩下元素的顺序得到的数组。
    /// 
    /// </summary>
    public class Find_Subsequence_of_Length_K_With_the_Largest_Sum
    {
        public int[] MaxSubsequence(int[] nums, int k)
        {
            var sortedVals = Enumerable.Range(0, nums.Length)
            .Select(i => new { Index = i, Value = nums[i] })
            .OrderByDescending(x => x.Value)
            .ToArray();

            return sortedVals.Take(k)
                .OrderBy(x => x.Index)
                .Select(x => x.Value)
                .ToArray();
        }
    }
}
