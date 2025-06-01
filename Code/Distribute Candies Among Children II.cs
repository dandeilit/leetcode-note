namespace Code
{
    /// <summary>
    /// 2929. Distribute Candies Among Children II
    /// 2929. 给小朋友们分糖果 II
    /// 
    /// You are given two positive integers n and limit.
    /// 给你两个正整数 n 和 limit 。
    /// 
    /// Return the total number of ways to distribute n candies among 3 children such that no child gets more than limit candies.
    /// 请你将 n 颗糖果分给 3 位小朋友，确保没有任何小朋友得到超过 limit 颗糖果，请你返回满足此条件下的 总方案数 。
    /// 
    /// </summary>
    public class Distribute_Candies_Among_Children_II
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="n"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public long DistributeCandies(int n, int limit)
        {
            long ans = 0;
            for (int i = 0; i <= Math.Min(limit, n); i++)
            {
                if (n - i > 2 * limit)
                {
                    continue;
                }
                ans += Math.Min(n - i, limit) - Math.Max(0, n - i - limit) + 1;
            }
            return ans;
        }

        /// <summary>
        /// 容斥
        /// 使用组合数学的容斥原理，用所有的方案数减去至少有一个小朋友分得超过 limit 颗糖果。但会重复计算至少有两个小朋友分得超过 limit 颗糖果，因此把这部分加回来。计算这部分的时候又会重复计算三个小朋友都分得超过 limit 颗糖果的方案，因此再减去这部分方案数。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public long DistributeCandies2(int n, int limit)
        {
            return Cal(n + 2) - 3 * Cal(n - limit + 1) + 3 * Cal(n - (limit + 1) * 2 + 2) - Cal(n - 3 * (limit + 1) + 2);
        }

        private long Cal(int x)
        {
            if (x < 0)
            {
                return 0;
            }
            return (long)x * (x - 1) / 2;
        }
    }
}
