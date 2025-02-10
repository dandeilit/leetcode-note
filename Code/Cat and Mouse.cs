namespace Code
{
    /// <summary>
    /// 913. Cat and Mouse
    /// 
    /// A game on an undirected graph is played by two players, Mouse and Cat, who alternate turns.
    /// 一个无向图上的游戏由两个玩家（老鼠和猫）轮流进行。
    /// 
    /// The graph is given as follows: graph[a] is a list of all nodes b such that ab is an edge of the graph.
    /// 该图如下所示：graph[a] 是所有节点 b 的列表，其中 ab 是图的一条边。
    /// 
    /// The mouse starts at node 1 and goes first, the cat starts at node 2 and goes second, and there is a hole at node 0.
    /// 老鼠从节点 1 开始并首先行动，猫从节点 2 开始并第二个行动，节点 0 处有一个洞。
    /// 
    /// During each player's turn, they must travel along one edge of the graph that meets where they are.  For example, if the Mouse is at node 1, it must travel to any node in graph[1].
    /// 在每个玩家的回合中，他们必须沿着与他们所在位置相交的图的一条边行进。例如，如果老鼠在节点 1，它必须前往 graph[1] 中的任何节点。
    /// 
    /// Additionally, it is not allowed for the Cat to travel to the Hole (node 0).
    /// 此外，猫不允许前往洞（节点 0）。
    /// 
    /// Then, the game can end in three ways:
    /// 然后，游戏可以以三种方式结束：
    /// 
    /// * If ever the Cat occupies the same node as the Mouse, the Cat wins.
    /// * 如果猫占据与老鼠相同的节点，则猫获胜。
    /// 
    /// * If ever the Mouse reaches the Hole, the Mouse wins.
    /// * 如果老鼠到达洞，则老鼠获胜。
    /// 
    /// * If ever a position is repeated (i.e., the players are in the same position as a previous turn, and it is the same player's turn to move), the game is a draw.
    /// * 如果某个位置重复出现（即玩家与前一轮处于相同的位置，并且轮到同一个玩家移动），则游戏为平局。
    /// 
    /// Given a graph, and assuming both players play optimally, return
    /// 给定一个图表，并假设两个玩家都发挥最佳，则返回
    /// 
    /// * 1 if the mouse wins the game.
    /// * 如果老鼠赢得游戏，则返回 1。
    /// 
    /// * 2 if the cat wins the game.
    /// * 如果猫赢得游戏，则返回 2。
    /// 
    /// * 0 if the game is a draw.
    /// * 如果游戏为平局，则返回 0。
    /// 
    /// </summary>
    public class Cat_and_Mouse
    {
        const int MOUSE_WIN = 1;
        const int CAT_WIN = 2;
        const int DRAW = 0;
        int n;
        int[][] graph;
        // dp[mouse][cat][turns] 表示从老鼠位于节点 mouse、猫位于节点 cat、游戏已经进行了 turns 轮的状态开始，猫和老鼠都按照最优策略的情况下的游戏结果
        int[,,] dp;

        /// <summary>
        /// 自顶向下动态规划（超时）
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public int CatMouseGame(int[][] graph)
        {
            this.n = graph.Length;
            this.graph = graph;
            this.dp = new int[n, n, 2 * n * (n - 1)];

            // 给所有可能情况设置默认值 -1
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < 2 * n * (n - 1); k++)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }
            return GetResult(1, 2, 0);
        }

        private int GetResult(int mouse, int cat, int turns)
        {
            // 老鼠可能的位置数是 n，
            // 因此猫可能的位置数是 n−1（由于猫不能移动到节点 0），
            // 轮到移动的一方有 2 种可能，因此游戏中所有可能的局面数是 2n(n−1)
            // 超过该轮数必然存在和局的情况
            if (turns == 2 * n * (n - 1))
            {
                return DRAW;
            }

            if (dp[mouse, cat, turns] < 0)
            {
                if (mouse == 0)
                {
                    dp[mouse, cat, turns] = MOUSE_WIN;
                }
                else if (cat == mouse)
                {
                    dp[mouse, cat, turns] = CAT_WIN;
                }
                else
                {
                    GetNextResult(mouse, cat, turns);
                }
            }
            return dp[mouse, cat, turns];
        }

        private void GetNextResult(int mouse, int cat, int turns)
        {
            // 根据轮数奇偶判定当前移动方
            int curMove = turns % 2 == 0 ? mouse : cat;

            // 设置移动方可能的最好结果
            int defaultResult = curMove == mouse ? CAT_WIN : MOUSE_WIN;

            int result = defaultResult;
            int[] nextNodes = graph[curMove];
            foreach (int next in nextNodes)
            {
                // 猫不能移动到 0
                if (curMove == cat && next == 0)
                {
                    continue;
                }

                int nextMouse = curMove == mouse ? next : mouse;
                int nextCat = curMove == cat ? next : cat;
                int nextResult = GetResult(nextMouse, nextCat, turns + 1);

                // 无法保证移动方必胜
                if (nextResult != defaultResult)
                {
                    result = nextResult;

                    // 确定移动方必败
                    if (result != DRAW)
                    {
                        break;
                    }
                }
            }
            dp[mouse, cat, turns] = result;
        }

        const int MOUSE_TURN = 0, CAT_TURN = 1;
        //const int DRAW = 0, MOUSE_WIN = 1, CAT_WIN = 2;
        //int[][] graph;
        int[,,] degrees; // 老鼠的位置、猫的位置、轮到移动的一方时的继续移动的范围大小
        int[,,] results; // 老鼠的位置、猫的位置、轮到移动的一方时的结果

        /// <summary>
        /// 拓扑排序（自底向上）
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public int CatMouseGame2(int[][] graph)
        {
            int n = graph.Length;
            this.graph = graph;
            this.degrees = new int[n, n, 2];
            this.results = new int[n, n, 2];
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();

            // 各种局势下双方可移动的范围大小
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    degrees[i, j, MOUSE_TURN] = graph[i].Length;
                    degrees[i, j, CAT_TURN] = graph[j].Length;
                }
            }

            // 剔除猫移动到洞的范围大小
            foreach (int node in graph[0])
            {
                for (int i = 0; i < n; i++)
                {
                    degrees[i, node, CAT_TURN]--;
                }
            }

            // 边界结果写入
            for (int j = 1; j < n; j++)
            {
                results[0, j, MOUSE_TURN] = MOUSE_WIN;
                results[0, j, CAT_TURN] = MOUSE_WIN;
                queue.Enqueue(new Tuple<int, int, int>(0, j, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(0, j, CAT_TURN));
            }
            for (int i = 1; i < n; i++)
            {
                results[i, i, MOUSE_TURN] = CAT_WIN;
                results[i, i, CAT_TURN] = CAT_WIN;
                queue.Enqueue(new Tuple<int, int, int>(i, i, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(i, i, CAT_TURN));
            }

            while (queue.Count > 0)
            {
                Tuple<int, int, int> state = queue.Dequeue();
                int mouse = state.Item1, cat = state.Item2, turn = state.Item3;
                int result = results[mouse, cat, turn];

                // 获取到达边界结果的上一轮移动信息（默认结果为和）
                IList<Tuple<int, int, int>> prevStates = GetPrevStates(mouse, cat, turn);
                foreach (Tuple<int, int, int> prevState in prevStates)
                {
                    int prevMouse = prevState.Item1, prevCat = prevState.Item2, prevTurn = prevState.Item3;
                    if (results[prevMouse, prevCat, prevTurn] == DRAW)
                    {
                        // 判定是否能赢
                        bool canWin = (result == MOUSE_WIN && prevTurn == MOUSE_TURN) || (result == CAT_WIN && prevTurn == CAT_TURN);
                        if (canWin)
                        {
                            results[prevMouse, prevCat, prevTurn] = result;
                            queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                        }
                        else
                        {
                            // 可能减一
                            degrees[prevMouse, prevCat, prevTurn]--;
                            // 不存在可能达到当前结果的可能
                            if (degrees[prevMouse, prevCat, prevTurn] == 0)
                            {
                                // 结果失败
                                int loseResult = prevTurn == MOUSE_TURN ? CAT_WIN : MOUSE_WIN;
                                results[prevMouse, prevCat, prevTurn] = loseResult;
                                queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                            }
                        }
                    }
                }
            }
            return results[1, 2, MOUSE_TURN];
        }

        private IList<Tuple<int, int, int>> GetPrevStates(int mouse, int cat, int turn)
        {
            IList<Tuple<int, int, int>> prevStates = new List<Tuple<int, int, int>>();
            int prevTurn = turn == MOUSE_TURN ? CAT_TURN : MOUSE_TURN;
            if (prevTurn == MOUSE_TURN)
            {
                foreach (int prev in graph[mouse])
                {
                    prevStates.Add(new Tuple<int, int, int>(prev, cat, prevTurn));
                }
            }
            else
            {
                foreach (int prev in graph[cat])
                {
                    if (prev != 0)
                    {
                        prevStates.Add(new Tuple<int, int, int>(mouse, prev, prevTurn));
                    }
                }
            }
            return prevStates;
        }
    }
}
