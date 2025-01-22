namespace Code
{
    /// <summary>
    /// 1561. Maximum Number of Coins You Can Get
    /// 
    /// There are 3n piles of coins of varying size, you and your friends will take piles of coins as follows:
    /// 有 3n 堆大小不一的硬币，你和你的朋友将按如下方式拿取硬币堆：
    /// 
    /// * In each step, you will choose any 3 piles of coins (not necessarily consecutive).
    /// * 在每个步骤中，你将选择任意 3 堆硬币（不一定是连续的）。
    /// 
    /// * Of your choice, Alice will pick the pile with the maximum number of coins.
    /// * 按照你的选择，Alice 将选择硬币数量最多的那堆。
    /// 
    /// * You will pick the next pile with the maximum number of coins.
    /// * 你将选择下一堆硬币数量最多的那堆。
    /// 
    /// * Your friend Bob will pick the last pile.
    /// * 你的朋友 Bob 将选择最后一堆。
    /// 
    /// * Repeat until there are no more piles of coins.
    /// * 重复，直到没有更多的硬币堆。
    /// 
    /// Given an array of integers piles where piles[i] is the number of coins in the ith pile.
    /// 给定一个整数数组，其中 pills[i] 是第 i 堆中的硬币数量。
    /// 
    /// Return the maximum number of coins that you can have.
    /// 返回你可以拥有的最大硬币数量。
    /// 
    /// </summary>
    public class MaxCoins
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        public int Solution(int[] piles)
        {
            Array.Sort(piles);

            int ans = 0;
            for (var i = piles.Length - 2; i >= piles.Length / 3; i -= 2)
            {
                ans += piles[i];
            }
            return ans;
        }
    }
}
