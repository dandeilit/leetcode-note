namespace Code
{
    /// <summary>
    /// 63. Unique Paths II
    /// 
    /// You are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.
    /// 给定一个M X N整数阵列网格。有一个机器人位于左上角（即网格[0] [0]）。机器人试图移至右下角（即网格[m -1] [n -1]）。机器人只能向下移动或向右移动。
    /// 
    /// An obstacle and space are marked as 1 or 0 respectively in grid. A path that the robot takes cannot include any square that is an obstacle.
    /// 障碍物和空间在网格中分别标记为1或0。机器人所走的路径不能包括任何正方形的障碍。
    /// 
    /// Return the number of possible unique paths that the robot can take to reach the bottom-right corner.
    /// 返回机器人可能需要的唯一路径的数量，以达到右下角。
    /// 
    /// The testcases are generated so that the answer will be less than or equal to 2 * Math.Pow(10,9).
    /// 答案小于或等于2 * Math.pow.pow（10,9）。
    /// 
    /// </summary>
    public class Unique_Paths_II
    {
        /// <summary>
        /// 递归遍历（超时）
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            if (obstacleGrid[m - 1][n - 1] == 1)
                return 0;

            return CheckUniquePath(0, 0, m, n, obstacleGrid);
        }

        private int CheckUniquePath(int x, int y, int m, int n, int[][] obstacleGrid)
        {
            if (x + 1 >= m && y + 1 >= n)
            {
                return 1;
            }

            if (obstacleGrid[x][y] == 1)
            {
                return 0;
            }

            int ans = 0;
            if (x + 1 < m)
            {
                ans += CheckUniquePath(x + 1, y, m, n, obstacleGrid);
            }

            if (y + 1 < n)
            {
                ans += CheckUniquePath(x, y + 1, m, n, obstacleGrid);
            }
            return ans;
        }


        /// <summary>
        /// 动态规划
        /// 滚动数组思想
        /// 目标点的路径数由目标左侧坐标和上侧坐标的路径数合计
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int UniquePathsWithObstacles2(int[][] obstacleGrid)
        {
            int n = obstacleGrid.Length, m = obstacleGrid[0].Length;
            int[] f = new int[m];
            f[0] = obstacleGrid[0][0] == 0 ? 1 : 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        f[j] = 0;
                    }
                    else if (j > 0 && obstacleGrid[i][j - 1] == 0)
                    {
                        f[j] += f[j - 1];
                    }
                }
            }
            return f[m - 1];
        }
    }
}
