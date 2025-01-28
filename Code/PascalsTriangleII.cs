namespace Code
{
    /// <summary>
    /// 119. Pascal's Triangle II
    /// 
    /// Given an integer rowIndex, return the rowIndex-th (0-indexed) row of the Pascal's triangle.
    /// 给定一个整数行索引，返回帕斯卡三角形的该整数行数组（0 索引）。
    /// 
    /// In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
    /// 在帕斯卡三角形中，每个数字都是其正上方两个数字的总和，如下所示：
    /// 
    /// 1
    /// 1 1
    /// 1 2 1
    /// 1 3 3 1
    /// 1 4 6 4 1
    /// 
    /// Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?
    /// 进阶：您能否优化算法以仅使用 O（行索引）额外空间？
    /// 
    /// </summary>
    public class PascalsTriangleII
    {
        /// <summary>
        /// 递推
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            var row = new int[rowIndex + 1];
            row[0] = 1;

            for (int i = 1; i <= rowIndex; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    row[j] += row[j - 1];
                }
            }
            return row;
        }

        /// <summary>
        /// 线性递推
        /// 
        /// C(m,n) = n! / m!(n-m)!
        /// =>
        /// C(m,n) = C(m,n-1) * (n-m+1) / m
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow2(int rowIndex)
        {
            var row = new int[rowIndex + 1];
            row[0] = 1;

            for (int i = 1; i <= rowIndex; i++)
            {
                row[i] = (int)((long)row[i - 1] * (rowIndex - i + 1) / i);
            }
            return row;
        }
    }
}
