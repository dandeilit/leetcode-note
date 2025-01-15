namespace Code
{
    /// <summary>
    /// 3066. Minimum Operations to Exceed Threshold Value II
    /// 
    /// You are given a 0-indexed integer array nums, and an integer k.
    /// 给定一个从 0 开始的整数数组 nums 和一个整数 k。
    /// 
    /// In one operation, you will:
    /// 在单次操作中，您将：
    /// 
    /// * Take the two smallest integers x and y in nums.
    /// * 取 nums 中最小的两个整数 x 和 y。
    /// 
    /// * Remove x and y from nums.
    /// * 从 nums 中删除 x 和 y。
    /// 
    /// * Add min(x, y) * 2 + max(x, y) anywhere in the array.
    /// * 在数组中的任意位置添加 min(x, y) * 2 + max(x, y)。
    /// 
    /// Note: that you can only apply the described operation if nums contains at least two elements.
    /// 注意: 只有当 nums 至少包含两个元素时，您才能应用所描述的操作。
    /// 
    /// Return the minimum number of operations needed so that all elements of the array are greater than or equal to k.
    /// 返回所需的最少操作数，以便数组的所有元素都大于或等于 k。
    /// 
    /// </summary>
    public class MinOperationsII
    {
        /// <summary>
        /// 利用优先队列模拟计算
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution(int[] nums, int k)
        {
            PriorityQueue<long, long> queue = new PriorityQueue<long, long>();

            foreach (var num in nums)
            {
                queue.Enqueue(num, num);
            }

            int ans = 0;

            while (queue.Peek() < k)
            {
                ans++;
                long x = queue.Dequeue();
                long y = queue.Dequeue();
                long num = x + x + y;

                queue.Enqueue(num, num);
            }

            return ans;
        }
    }
}
