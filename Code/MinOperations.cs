namespace Code
{
    /// <summary>
    /// 3065. Minimum Operations to Exceed Threshold Value I
    /// 
    /// You are given a 0-indexed integer array nums, and an integer k.
    /// 给定一个0 索引的整数数组nums和一个整数k 。
    /// 
    /// In one operation, you can remove one occurrence of the smallest element of nums.
    /// 在一次操作中，您可以删除nums中最小元素的一次出现。
    /// 
    /// Return the minimum number of operations needed so that all elements of the array are greater than or equal to k.
    /// 返回使数组的所有元素都大于或等于k所需的最少操作数。
    /// 
    /// </summary>
    public class MinOperations
    {
        public int Solution(int[] nums, int k)
        {
            int ans = 0;
            foreach (var num in nums)
            {
                if (num < k)
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
