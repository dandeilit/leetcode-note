namespace Code
{
    /// <summary>
    /// 2218. Maximum Value of K Coins From Piles
    /// 
    /// There are n piles of coins on a table. Each pile consists of a positive number of coins of assorted denominations.
    /// 桌子上有 n 堆硬币。每堆由正数个不同面值的硬币组成。
    /// 
    /// In one move, you can choose any coin on top of any pile, remove it, and add it to your wallet.
    /// 在一步内，您可以选择任意堆顶部的任意硬币，将其取出并添加到您的钱包中。
    /// 
    /// Given a list piles, where piles[i] is a list of integers denoting the composition of the ith pile from top to bottom, and a positive integer k, return the maximum total value of coins you can have in your wallet if you choose exactly k coins optimally.
    /// 给定一个列表 pills，其中 pills[i] 是一个整数列表，表示从上到下第 i 堆的组成，以及一个正整数 k，如果您以最佳方式选择 k 个硬币，则返回您钱包中可以拥有的最大硬币总价值。
    /// 
    /// </summary>
    public class MaxValueOfCoins
    {
        /// <summary>
        /// 背包型的动态规划
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution(IList<IList<int>> piles, int k)
        {
            int[] dp = new int[k + 1];

            // 遍历每个堆
            foreach (var pile in piles)
            {
                // 计算当前堆的前缀和
                int[] prefixSum = new int[pile.Count + 1];
                for (int i = 0; i < pile.Count; i++)
                {
                    prefixSum[i + 1] = prefixSum[i] + pile[i];
                }

                // 倒序遍历，更新 dp 数组（避免覆盖问题）
                for (int j = k; j > 0; j--)
                {
                    for (int x = 1; x <= Math.Min(pile.Count, j); x++)
                    {
                        dp[j] = Math.Max(dp[j], dp[j - x] + prefixSum[x]);
                    }
                }
            }

            return dp[k];
        }
    }
}
