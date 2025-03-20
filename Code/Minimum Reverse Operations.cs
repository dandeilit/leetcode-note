namespace Code
{
    /// <summary>
    /// 2612. Minimum Reverse Operations
    /// 2612. 最少翻转操作数
    /// 
    /// You are given an integer n and an integer p representing an array arr of length n where all elements are set to 0's, except position p which is set to 1. You are also given an integer array banned containing restricted positions. Perform the following operation on arr:
    /// 
    /// * Reverse a subarray with size k if the single 1 is not set to a position in banned.
    /// 
    /// 
    /// Return an integer array answer with n results where the i-th result is the minimum number of operations needed to bring the single 1 to position i in arr, or -1 if it is impossible.
    /// 
    /// 给你一个整数 n 和一个在范围 [0, n - 1] 以内的整数 p ，它们表示一个长度为 n 且下标从 0 开始的数组 arr ，数组中除了下标为 p 处是 1 以外，其他所有数都是 0 。
    /// 
    /// 同时给你一个整数数组 banned ，它包含数组中的一些位置。banned 中第 i 个位置表示 arr[banned[i]] = 0 ，题目保证 banned[i] != p 。
    /// 
    /// 你可以对 arr 进行 若干次 操作。一次操作中，你选择大小为 k 的一个 子数组 ，并将它 翻转 。在任何一次翻转操作后，你都需要确保 arr 中唯一的 1 不会到达任何 banned 中的位置。换句话说，arr[banned[i]] 始终 保持 0 。
    /// 
    /// 请你返回一个数组 ans ，对于 [0, n - 1] 之间的任意下标 i ，ans[i] 是将 1 放到位置 i 处的 最少 翻转操作次数，如果无法放到位置 i 处，此数为 -1 。
    /// 
    /// * 子数组 指的是一个数组里一段连续 非空 的元素序列。
    /// * 对于所有的 i ，ans[i] 相互之间独立计算。
    /// * 将一个数组中的元素 翻转 指的是将数组中的值变成 相反顺序 。
    /// 
    /// </summary>
    public class Minimum_Reverse_Operations
    {
        /// <summary>
        /// 广度优先搜索 + 平衡树
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="banned"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MinReverseOperations(int n, int p, int[] banned, int k)
        {
            HashSet<int> ban = new HashSet<int>(banned);
            SortedSet<int>[] sets = new SortedSet<int>[2];
            sets[0] = new SortedSet<int>();
            sets[1] = new SortedSet<int>();
            for (int i = 0; i < n; ++i)
            {
                if (i != p && !ban.Contains(i))
                {
                    sets[i % 2].Add(i);
                }
            }
            int[] ans = new int[n];
            Array.Fill(ans, -1);
            Queue<int> q = new Queue<int>();
            q.Enqueue(p);
            ans[p] = 0;
            while (q.Count > 0)
            {
                int i = q.Dequeue();
                int mn = Math.Max(i - k + 1, k - i - 1);
                int mx = Math.Min(i + k - 1, n * 2 - k - i - 1);
                SortedSet<int> set = sets[mx % 2];
                var toRemove = new List<int>();
                var it = set.GetViewBetween(mn, mx).GetEnumerator();
                while (it.MoveNext())
                {
                    int current = it.Current;
                    ans[current] = ans[i] + 1;
                    q.Enqueue(current);
                    toRemove.Add(current);
                }
                foreach (int val in toRemove)
                {
                    set.Remove(val);
                }
            }
            return ans;
        }


        /// <summary>
        /// 广度优先搜索 + 并查集
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        /// <param name="banned"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MinReverseOperations2(int n, int p, int[] banned, int k)
        {
            int[][] fa = new int[2][];
            for (int i = 0; i < 2; i++)
            {
                fa[i] = new int[n + 2];
                for (int j = 0; j < n + 2; j++)
                {
                    fa[i][j] = j;
                }
            }
            foreach (int ban in banned)
            {
                Merge(fa[ban % 2], ban, ban + 2);
            }
            int[] ans = new int[n];
            Array.Fill(ans, -1);
            Queue<int> q = new Queue<int>();
            q.Enqueue(p);
            ans[p] = 0;
            Merge(fa[p % 2], p, p + 2);
            while (q.Count > 0)
            {
                int i = q.Dequeue();
                int mn = Math.Max(i - k + 1, k - i - 1);
                int mx = Math.Min(i + k - 1, n * 2 - k - i - 1);
                int fi = 0;
                for (int j = mn; j <= mx; j = fi + 2)
                {
                    fi = Find(fa[mn % 2], j);
                    if (fi > mx)
                    {
                        break;
                    }
                    ans[fi] = ans[i] + 1;
                    q.Enqueue(fi);
                    Merge(fa[mn % 2], fi, fi + 2);
                }
            }
            return ans;
        }

        private int Find(int[] f, int x)
        {
            return f[x] == x ? x : (f[x] = Find(f, f[x]));
        }

        private void Merge(int[] f, int x, int y)
        {
            int fx = Find(f, x), fy = Find(f, y);
            f[fx] = fy;
        }
    }
}
