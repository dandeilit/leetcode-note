namespace Code
{
    /// <summary>
    /// 598. Range Addition II
    /// 
    /// You are given an m x n matrix M initialized with all 0's and an array of operations ops, where ops[i] = [a[i], b[i]] means M[x][y] should be incremented by one for all 0 <= x < a[i] and 0 <= y < b[i].
    /// 给定一个 m x n 矩阵 M，其初始化为全 0，以及一个操作数组 ops，其中 ops[i] = [a[i], b[i]] 表示对于所有 0 <= x < a[i] 和 0 <= y < b[i]，M[x][y] 应该加一。
    /// 
    /// Count and return the number of maximum integers in the matrix after performing all the operations.
    /// 执行完所有操作后，计算并返回矩阵中最大整数的数量。
    /// 
    /// </summary>
    public class Range_Addition_II
    {
        /// <summary>
        /// 维护所有操作的交集
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="ops"></param>
        /// <returns></returns>
        public int MaxCount(int m, int n, int[][] ops)
        {
            foreach (var op in ops)
            {
                if (op[0] < m) m = op[0];
                if (op[1] < n) n = op[1];
            }
            return m * n;
        }
    }
}
