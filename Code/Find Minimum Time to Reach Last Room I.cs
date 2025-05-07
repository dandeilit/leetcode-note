namespace Code
{
    /// <summary>
    /// 3341. Find Minimum Time to Reach Last Room I
    /// 3341. 到达最后一个房间的最少时间 I
    /// 
    /// There is a dungeon with n x m rooms arranged as a grid.
    /// 有一个地窖，地窖中有 n x m 个房间，它们呈网格状排布。
    /// 
    /// You are given a 2D array moveTime of size n x m, where moveTime[i][j] represents the minimum time in seconds when you can start moving to that room. You start from the room (0, 0) at time t = 0 and can move to an adjacent room. Moving between adjacent rooms takes exactly one second.
    /// 给你一个大小为 n x m 的二维数组 moveTime ，其中 moveTime[i][j] 表示在这个时刻 以后 你才可以 开始 往这个房间 移动 。你在时刻 t = 0 时从房间 (0, 0) 出发，每次可以移动到 相邻 的一个房间。在 相邻 房间之间移动需要的时间为 1 秒。
    /// 
    /// Return the minimum time to reach the room (n - 1, m - 1).
    /// 请你返回到达房间 (n - 1, m - 1) 所需要的 最少 时间。
    /// 
    /// Two rooms are adjacent if they share a common wall, either horizontally or vertically.
    /// 如果两个房间有一条公共边（可以是水平的也可以是竖直的），那么我们称这两个房间是 相邻 的。
    /// 
    /// </summary>
    public class Find_Minimum_Time_to_Reach_Last_Room_I
    {
        private const int INF = 0x3f3f3f3f;

        private class State : IComparable<State>
        {
            public int x;
            public int y;
            public int dis;

            public State(int x, int y, int dis)
            {
                this.x = x;
                this.y = y;
                this.dis = dis;
            }

            public int CompareTo(State other)
            {
                return this.dis.CompareTo(other.dis);
            }
        }

        /// <summary>
        /// 最短路 + Dijkstra
        /// </summary>
        /// <param name="moveTime"></param>
        /// <returns></returns>
        public int MinTimeToReach(int[][] moveTime)
        {
            int n = moveTime.Length;
            int m = moveTime[0].Length;
            int[,] d = new int[n, m];
            bool[,] v = new bool[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    d[i, j] = INF;
                }
            }

            int[][] dirs = new int[][] {
            new int[] {1, 0},
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {0, -1}
        };

            d[0, 0] = 0;
            var pq = new PriorityQueue<State, int>();
            pq.Enqueue(new State(0, 0, 0), 0);

            while (pq.Count > 0)
            {
                State s = pq.Dequeue();
                if (v[s.x, s.y])
                {
                    continue;
                }
                v[s.x, s.y] = true;
                foreach (var dir in dirs)
                {
                    int nx = s.x + dir[0];
                    int ny = s.y + dir[1];
                    if (nx < 0 || nx >= n || ny < 0 || ny >= m)
                    {
                        continue;
                    }
                    int dist = Math.Max(d[s.x, s.y], moveTime[nx][ny]) + 1;
                    if (d[nx, ny] > dist)
                    {
                        d[nx, ny] = dist;
                        pq.Enqueue(new State(nx, ny, dist), dist);
                    }
                }
            }

            return d[n - 1, m - 1];
        }
    }
}
