namespace Code
{
    /// <summary>
    /// 2412. Minimum Money Required Before Transactions
    /// 
    /// You are given a 0-indexed 2D integer array transactions, where transactions[i] = [cost[i], cashback[i]].
    /// 给定一个 0 索引的二维整数数组交易，其中交易 [i] = [成本 [i], 现金返还 [i]]。
    /// 
    /// The array describes transactions, where each transaction must be completed exactly once in some order. At any given moment, you have a certain amount of money. In order to complete transaction i, money >= cost[i] must hold true. After performing a transaction, money becomes money - cost[i] + cashback[i].
    /// 该数组描述交易，其中每笔交易必须按某种顺序完成一次。在任何给定时刻，您都有一定数量的钱。为了完成交易 i，金钱 >= 成本 [i] 必须成立。执行交易后，金钱变成金钱 - 成本 [i] + 现金返还 [i]。
    /// 
    /// Return the minimum amount of money required before any transaction so that all of the transactions can be completed regardless of the order of the transactions.
    /// 返回任何交易之前所需的最低金额，以便无论交易顺序如何，都可以完成所有交易。
    /// 
    /// </summary>
    public class MinimumMoney
    {
        /// <summary>
        /// 贪心
        /// 最坏情况是先进行所有的亏损交易，然后进行成本最大的盈利交易。
        /// </summary>
        /// <param name="transactions"></param>
        /// <returns></returns>
        public long Solution(int[][] transactions)
        {
            long totalLose = 0; // 亏损交易花费和
            int res = 0; // 成本最大的盈利交易花费
            foreach (var t in transactions)
            {
                int cost = t[0];
                int cashback = t[1];
                totalLose += Math.Max(cost - cashback, 0);
                res = Math.Max(res, Math.Min(cost, cashback));
            }
            return totalLose + res;
        }

        public long Solution2(int[][] transactions)
        {
            var increase = new List<int[]>();
            var decrease = 0;

            foreach (var tran in transactions)
            {
                if (tran[0] > tran[1])
                {
                    increase.Add(tran);
                }
                else
                {
                    if (tran[0] > decrease)
                    {
                        decrease = tran[0];
                    }
                }
            }

            var order = increase.OrderBy(x => x[1]).ThenByDescending(x => x[0]).ToList();
            order.Add([decrease, 0]);

            long money = order[0][0];
            long ans = money;

            for (var i = 1; i < order.Count; i++)
            {
                money = money - order[i - 1][1] + order[i][0];
                if (money > ans)
                {
                    ans = money;
                }
            }

            return ans;
        }
    }
}
