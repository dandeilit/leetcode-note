namespace Code
{
    /// <summary>
    /// 1706. Where Will the Ball Fall
    /// 
    /// You have a 2-D grid of size m x n representing a box, and you have n balls. The box is open on the top and bottom sides.
    /// 您有一个 m x n 大小的二维网格，代表一个盒子，并且您有 n 个球。盒子的顶部和底部都是开放的。
    /// 
    /// Each cell in the box has a diagonal board spanning two corners of the cell that can redirect a ball to the right or to the left.
    /// 盒子中的每个单元格都有一个横跨单元格两个角的对角板，可以将球重定向到右侧或左侧。
    /// 
    /// * A board that redirects the ball to the right spans the top-left corner to the bottom-right corner and is represented in the grid as 1.
    /// * 将球重定向到右侧的板跨越左上角到右下角，在网格中表示为 1。
    /// 
    /// * A board that redirects the ball to the left spans the top-right corner to the bottom-left corner and is represented in the grid as -1.
    /// * 将球重定向到左侧的板跨越右上角到左下角，在网格中表示为 -1。
    /// 
    /// We drop one ball at the top of each column of the box. Each ball can get stuck in the box or fall out of the bottom. A ball gets stuck if it hits a "V" shaped pattern between two boards or if a board redirects the ball into either wall of the box.
    /// 我们在盒子的每一列顶部放置一个球。每个球都可能卡在盒子里或从底部掉出来。如果球击中两个板之间的“V”形图案，或者如果板将球重定向到盒子的任一壁，则球会被卡住。
    /// 
    /// Return an array answer of size n where answer[i] is the column that the ball falls out of at the bottom after dropping the ball from the ith column at the top, or -1 if the ball gets stuck in the box.
    /// 返回一个大小为 n 的数组 answer，其中 answer[i] 表示将球从顶部的第 i 列扔下后，球从底部掉落的列，如果球卡在盒子里，则为 -1。
    /// 
    /// </summary>
    public class Where_Will_the_Ball_Fall
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[] FindBall(int[][] grid)
        {
            this.grid = grid;
            this.m = grid.Length;
            this.n = grid[0].Length;

            map = new int[m][];
            for (var i = 0; i < m; i++)
            {
                map[i] = new int[n];
                Array.Fill(map[i], -2);
            }

            var ans = new int[n];
            for (var i = 0; i < n; i++)
            {
                ans[i] = FindBallNext(0, i);
            }

            return ans;
        }

        private int m;
        private int n;
        private int[][] map;
        private int[][] grid;

        private int FindBallNext(int y, int x)
        {
            if (map[y][x] > -2)
            {
                return map[y][x];
            }

            var point = grid[y][x];
            var nx = x + point;

            // 超出边界
            if (nx >= n || nx < 0)
            {
                map[y][x] = -1;
                return -1;
            }

            // 陷入 “V” 形卡住
            if (grid[y][nx] != point)
            {
                map[y][x] = -1;
                return -1;
            }

            // 正常掉落
            if (y < m - 1)
            {
                map[y][x] = FindBallNext(y + 1, nx);
            }
            else
            {
                map[y][x] = nx;
            }
            return map[y][x];
        }
    }
}
