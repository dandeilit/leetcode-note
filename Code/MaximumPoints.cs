namespace Code
{
    /// <summary>
    /// 2920. Maximum Points After Collecting Coins From All Nodes
    /// 
    /// There exists an undirected tree rooted at node 0 with n nodes labeled from 0 to n - 1. You are given a 2D integer array edges of length n - 1, where edges[i] = [a[i], b[i]] indicates that there is an edge between nodes a[i] and b[i] in the tree. You are also given a 0-indexed array coins of size n where coins[i] indicates the number of coins in the vertex i, and an integer k.
    /// 存在一个以节点 0 为根的无向树，该树有 n 个节点，标签从 0 到 n - 1。给定一个长度为 n - 1 的二维整数数组 edge，其中 edge[i] = [a[i], b[i]] 表示树中节点 a[i] 和 b[i] 之间存在一条边。还给定一个大小为 n 的 0 索引数组 coins，其中 coins[i] 表示顶点 i 中的硬币数量，以及一个整数 k。
    /// 
    /// Starting from the root, you have to collect all the coins such that the coins at a node can only be collected if the coins of its ancestors have been already collected.
    /// 从根开始，您必须收集所有硬币，并且只有当其祖先的硬币已被收集时，才能收集节点上的硬币。
    /// 
    /// Coins at node[i] can be collected in one of the following ways:
    /// 节点[i] 处的硬币可以通过以下方式之一收集：
    /// 
    /// * Collect all the coins, but you will get coins[i] - k points. If coins[i] - k is negative then you will lose abs(coins[i] - k) points.
    /// * 收集所有硬币，但您将获得 coins[i] - k 分。如果 coins[i] - k 为负数，则您将失去 abs(coins[i] - k) 分。
    /// 
    /// * Collect all the coins, but you will get floor(coins[i] / 2) points. If this way is used, then for all the node[j] present in the subtree of node[i], coins[j] will get reduced to floor(coins[j] / 2).
    /// * 收集所有硬币，但您将获得 floor(coins[i] / 2) 分。如果使用这种方式，则对于 node[i] 子树中存在的所有 node[j]，coins[j] 将减少到 floor(coins[j] / 2)。
    /// 
    /// Return the maximum points you can get after collecting the coins from all the tree nodes.
    /// 返回从所有树节点收集硬币后可以获得的最大分数。
    /// 
    /// </summary>
    public class MaximumPoints
    {
        /// <summary>
        /// 记忆化搜索
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="coins"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution(int[][] edges, int[] coins, int k)
        {
            int n = coins.Length;
            var children = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                children.Add(new List<int>());
            }
            foreach (var edge in edges)
            {
                children[edge[0]].Add(edge[1]);
                children[edge[1]].Add(edge[0]);
            }
            var memo = new int[n, 14];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    memo[i, j] = -1;
                }
            }
            return Dfs(0, -1, 0, coins, k, children, memo);
        }

        private int Dfs(int node, int parent, int f, int[] coins, int k, List<List<int>> children, int[,] memo)
        {
            if (memo[node, f] != -1)
            {
                return memo[node, f];
            }
            int res0 = (coins[node] >> f) - k;
            int res1 = coins[node] >> (f + 1);
            foreach (int child in children[node])
            {
                if (child == parent)
                {
                    continue;
                }
                res0 += Dfs(child, node, f, coins, k, children, memo);
                if (f + 1 < 14)
                {
                    res1 += Dfs(child, node, f + 1, coins, k, children, memo);
                }
            }
            memo[node, f] = Math.Max(res0, res1);
            return memo[node, f];
        }

        /// <summary>
        /// 递归模拟（超时）
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="coins"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int Solution2(int[][] edges, int[] coins, int k)
        {
            var tree = GetNode(edges, coins, k);
            return tree.GetMaximumPoints();
        }

        public Node GetNode(int[][] edges, int[] coins, int k)
        {
            int inx = 0;
            Node root = new Node()
            {
                Inx = 0,
                Val = coins[0],
                Point = coins[0] - k,
                Level = 0,
            };
            foreach (var edge in edges)
            {
                int x = edge[0], y = edge[1];
                if (edge[0] > edge[1])
                {
                    x = edge[1];
                    y = edge[0];
                }

                var newNode = new Node()
                {
                    Inx = y,
                    Val = coins[y],
                    Point = coins[y] - k,
                };

                var node = root.DFS(x);
                node.AddChild(newNode);
            }

            return root;
        }

        public class Node
        {
            public int Inx { get; set; }
            public int Val { get; set; }
            public int Point { get; set; }
            public int Level { get; set; }

            public IList<Node> Children { get; set; }

            public void AddChild(Node node)
            {
                if (Children == null)
                {
                    Children = new List<Node>();
                }
                node.Level = Level + 1;
                Children.Add(node);
            }

            public Node DFS(int inx)
            {
                if (this.Inx == inx)
                {
                    return this;
                }

                if (this.Children != null)
                {
                    foreach (var child in Children)
                    {
                        var node = child.DFS(inx);
                        if (node != null)
                        {
                            return node;
                        }
                    }
                }

                return null;
            }

            public int GetSumFloorPoints(int level)
            {
                var ans = Val >> (Level - level + 1);
                if (Children != null)
                {
                    foreach (var child in Children)
                    {
                        ans += child.GetSumFloorPoints(level);
                    }
                }
                return ans;
            }

            public int GetMaximumPoints()
            {
                var ans = Point;
                var ansx = GetSumFloorPoints(Level);
                if (Children == null)
                {
                    if (ans < ansx)
                    {
                        ans = ansx;
                    }
                    return ans;
                }

                foreach (var child in Children)
                {
                    ans += child.GetMaximumPoints();
                }

                if (ans < ansx)
                {
                    ans = ansx;
                }

                return ans;
            }
        }
    }
}
