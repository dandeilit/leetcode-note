namespace Code
{
    /// <summary>
    /// 2944. Minimum Number of Coins for Fruits
    /// 
    /// You are given an 1-indexed integer array prices where prices[i] denotes the number of coins needed to purchase the ith fruit.
    /// 定一个 1 索引整数数组 prices，其中 prices[i] 表示购买第 i 个水果所需的硬币数量。
    /// 
    /// The fruit market has the following reward for each fruit:
    /// 水果市场对每种水果的奖励如下：
    /// 
    /// * If you purchase the ith fruit at prices[i] coins, you can get any number of the next i fruits for free.
    /// * 如果您以 prices[i] 硬币购买第 i 个水果，则可以免费获得接下来的 i 个水果中的任意数量。
    /// 
    /// Note: that even if you can take fruit j for free, you can still purchase it for prices[j] coins to receive its reward.
    /// 注意：即使您可以免费获得水果 j，您仍然可以花费 prices[j] 硬币购买它以获得奖励。
    /// 
    /// Return the minimum number of coins needed to acquire all the fruits.
    /// 返回获取所有水果所需的最少硬币数量。
    /// 
    /// </summary>
    public class MinimumCoins
    {
        IDictionary<int, int> memo = new Dictionary<int, int>();
        int[] prices;

        /// <summary>
        /// 记忆化搜索
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int Solution(int[] prices)
        {
            this.prices = prices;
            return DP(0);
        }

        /// <summary>
        /// 从下标 index 开始的所有水果需要花费的最少金币
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int DP(int index)
        {
            if (2 * index + 2 >= prices.Length)
            {
                return prices[index];
            }
            if (!memo.ContainsKey(index))
            {
                int minValue = int.MaxValue;
                for (int i = index + 1; i <= 2 * index + 2; i++)
                {
                    minValue = Math.Min(minValue, DP(i));
                }
                memo.Add(index, prices[index] + minValue);
            }
            return memo[index];
        }

        /// <summary>
        /// 单调队列优化时间复杂度
        /// 每一个 DP[i] 的值都依赖于后 i 个元素的结果，所以可以反向遍历避免递归
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int Solution2(int[] prices)
        {
            int n = prices.Length;
            var queue = new LinkedList<int[]>();
            queue.AddFirst(new int[] { n, 0 });
            for (int i = n - 1; i >= 0; i--)
            {
                while (queue.Last.Value[0] >= 2 * i + 3)
                {
                    queue.RemoveLast();
                }
                int cur = queue.Last.Value[1] + prices[i];
                while (queue.First.Value[1] >= cur)
                {
                    queue.RemoveFirst();
                }
                queue.AddFirst(new int[] { i, cur });
            }
            return queue.First.Value[1];
        }
    }
}
