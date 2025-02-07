namespace Code
{
    /// <summary>
    /// 59. Spiral Matrix II
    /// 
    /// Given a positive integer n, generate an n x n matrix filled with elements from 1 to Math.Pow(n, 2) in spiral order.
    /// 给定一个正整数 n，生成一个 n x n 矩阵，其中以螺旋顺序填充元素从 1 到 Math.Pow(n, 2)。
    /// 
    /// 1  2  3  4
    /// 12 13 14 5
    /// 11 16 15 6
    /// 10 9  8  7
    /// 
    /// 1  2  3  4  5
    /// 16 17 18 19 6
    /// 15 24 25 20 7
    /// 14 23 22 21 8
    /// 13 12 11 10 9
    /// </summary>
    public class Spiral_Matrix_II
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] GenerateMatrix(int n)
        {
            var ans = new int[n][];
            for (var i = 0; i < ans.Length; i++)
            {
                ans[i] = new int[n];
            }

            int x = 0, y = 0;
            int max = (int)Math.Pow(n, 2);
            bool flag = false;
            int node = n;
            int path = 0;
            for (var i = 1; i <= max; i++)
            {
                ans[x][y] = i;

                if (i == node)
                {
                    node += flag ? n : --n;
                    flag = !flag;
                    path++;
                }

                switch (path % 4)
                {
                    case 0:
                        y++;
                        break;
                    case 1:
                        x++;
                        break;
                    case 2:
                        y--;
                        break;
                    case 3:
                        x--;
                        break;
                }
            }

            return ans;
        }
    }
}
