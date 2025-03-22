namespace Code
{
    /// <summary>
    /// 2643. Row With Maximum Ones
    /// 2643. 一最多的行
    /// 
    /// Given a m x n binary matrix mat, find the 0-indexed position of the row that contains the maximum count of ones, and the number of ones in that row.
    /// 给你一个大小为 m x n 的二进制矩阵 mat ，请你找出包含最多 1 的行的下标（从 0 开始）以及这一行中 1 的数目。
    /// 
    /// In case there are multiple rows that have the maximum count of ones, the row with the smallest row number should be selected.
    /// 如果有多行包含最多的 1 ，只需要选择 行下标最小 的那一行。
    /// 
    /// Return an array containing the index of the row, and the number of ones in it.
    /// 返回一个由行下标和该行中 1 的数量组成的数组。
    /// 
    /// </summary>
    public class Row_With_Maximum_Ones
    {
        public int[] RowAndMaximumOnes(int[][] mat)
        {
            var ans = new int[2];
            for (var i = 0; i < mat.Length; i++)
            {
                int num = 0;
                for (var j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 1) num++;
                }
                if (num > ans[1])
                {
                    ans[1] = num;
                    ans[0] = i;
                }
            }
            return ans;
        }
    }
}
