namespace Code
{
    /// <summary>
    /// 2070. Most Beautiful Item for Each Query
    /// 
    /// You are given a 2D integer array items where items[i] = [price, beauty] denotes the price and beauty of an item respectively.
    /// 给定一个二维整数数组 items，其中 items[i] = [price, beauty] 分别表示商品的价格和美丽程度。
    /// 
    /// You are also given a 0-indexed integer array queries. For each queries[j], you want to determine the maximum beauty of an item whose price is less than or equal to queries[j]. If no such item exists, then the answer to this query is 0.
    /// 还给定一个 0 索引整数数组 queries。对于每个 queries[j]，您要确定价格小于或等于 queries[j] 的商品的最大美度。如果不存在这样的商品，则此查询的答案为 0。
    /// 
    /// Return an array answer of the same length as queries where answer[j] is the answer to the j-th query.
    /// 返回一个长度与 queries 相同的数组 answer，其中 answer[j] 是第 j 个查询的答案。
    /// 
    /// </summary>
    public class Most_Beautiful_Item_for_Each_Query
    {
        /// <summary>
        /// 排序 + 二分查找
        /// </summary>
        /// <param name="items"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] MaximumBeauty(int[][] items, int[] queries)
        {
            // 将物品按价格升序排序
            Array.Sort(items, (a, b) => a[0].CompareTo(b[0]));
            int n = items.Length;
            // 按定义修改美丽值
            for (int i = 1; i < n; ++i)
            {
                items[i][1] = Math.Max(items[i][1], items[i - 1][1]);
            }
            // 二分查找处理查询
            int[] res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                res[i] = Query(items, queries[i]);
            }
            return res;
        }

        private int Query(int[][] items, int q)
        {
            int l = 0, r = items.Length;
            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (items[mid][0] > q)
                {
                    r = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            if (l == 0)
            {
                // 此时所有物品价格均大于查询价格
                return 0;
            }
            else
            {
                // 返回小于等于查询价格的物品的最大美丽值
                return items[l - 1][1];
            }
        }
    }
}
