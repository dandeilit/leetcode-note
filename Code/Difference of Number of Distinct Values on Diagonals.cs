namespace Code
{
    /// <summary>
    /// 2711. Difference of Number of Distinct Values on Diagonals
    /// 2711. 对角线上不同值的数量差
    /// 
    /// Given a 2D grid of size m x n, you should find the matrix answer of size m x n.
    /// 给你一个下标从 0 开始、大小为 m x n 的二维矩阵 grid ，请你求解大小同样为 m x n 的答案矩阵 answer 。
    /// 
    /// The cell answer[r][c] is calculated by looking at the diagonal values of the cell grid[r][c]:
    /// 矩阵 answer 中每个单元格 (r, c) 的值可以按下述方式进行计算：
    /// 
    /// * Let leftAbove[r][c] be the number of distinct values on the diagonal to the left and above the cell grid[r][c] not including the cell grid[r][c] itself.
    /// * 令 topLeft[r][c] 为矩阵 grid 中单元格 (r, c) 左上角对角线上 不同值 的数量。
    /// 
    /// * Let rightBelow[r][c] be the number of distinct values on the diagonal to the right and below the cell grid[r][c], not including the cell grid[r][c] itself.
    /// * 令 bottomRight[r][c] 为矩阵 grid 中单元格 (r, c) 右下角对角线上 不同值 的数量。
    /// 
    /// * Then answer[r][c] = |leftAbove[r][c] - rightBelow[r][c]|.
    /// * 然后 answer[r][c] = |topLeft[r][c] - bottomRight[r][c]| 。
    /// 
    /// A matrix diagonal is a diagonal line of cells starting from some cell in either the topmost row or leftmost column and going in the bottom-right direction until the end of the matrix is reached.
    /// 矩阵对角线 是从最顶行或最左列的某个单元格开始，向右下方向走到矩阵末尾的对角线。
    /// 
    /// </summary>
    public class Difference_of_Number_of_Distinct_Values_on_Diagonals
    {
        /// <summary>
        /// 前缀和
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int[][] DifferenceOfDistinctValues(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[][] res = new int[m][];
            for (int i = 0; i < m; ++i)
            {
                res[i] = new int[n];
            }

            for (int i = 0; i < m; ++i)
            {
                int x = i, y = 0;
                HashSet<int> s = new HashSet<int>();
                while (x < m && y < n)
                {
                    res[x][y] += s.Count;
                    s.Add(grid[x][y]);
                    x += 1;
                    y += 1;
                }
            }

            for (int j = 1; j < n; ++j)
            {
                int x = 0, y = j;
                HashSet<int> s = new HashSet<int>();
                while (x < m && y < n)
                {
                    res[x][y] += s.Count;
                    s.Add(grid[x][y]);
                    x += 1;
                    y += 1;
                }
            }

            for (int i = 0; i < m; ++i)
            {
                int x = i, y = n - 1;
                HashSet<int> s = new HashSet<int>();
                while (x >= 0 && y >= 0)
                {
                    res[x][y] -= s.Count;
                    res[x][y] = Math.Abs(res[x][y]);
                    s.Add(grid[x][y]);
                    x -= 1;
                    y -= 1;
                }
            }

            for (int j = n - 2; j >= 0; --j)
            {
                int x = m - 1, y = j;
                HashSet<int> s = new HashSet<int>();
                while (x >= 0 && y >= 0)
                {
                    res[x][y] -= s.Count;
                    res[x][y] = Math.Abs(res[x][y]);
                    s.Add(grid[x][y]);
                    x -= 1;
                    y -= 1;
                }
            }

            return res;
        }
    }
}
