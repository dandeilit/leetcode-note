namespace Code
{
    /// <summary>
    /// 624. Maximum Distance in Arrays
    /// 
    /// You are given m arrays, where each array is sorted in ascending order.
    /// 给定 m 个数组，每个数组按升序排序。
    /// 
    /// You can pick up two integers from two different arrays (each array picks one) and calculate the distance. We define the distance between two integers a and b to be their absolute difference |a - b|.
    /// 您可以从两个不同的数组中挑选两个整数（每个数组挑选一个）并计算距离。我们将两个整数 a 和 b 之间的距离定义为它们的绝对差 |a - b|。
    /// 
    /// Return the maximum distance.
    /// 返回最大距离。
    /// 
    /// </summary>
    public class Maximum_Distance_in_Arrays
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int MaxDistance(IList<IList<int>> arrays)
        {
            int m = arrays.Count;
            int[][] maxs = new int[m][];
            int[][] mins = new int[m][];

            for (var i = 0; i < arrays.Count; i++)
            {
                maxs[i] = [arrays[i][arrays[i].Count - 1], i];
                mins[i] = [arrays[i][0], i];
            }

            Array.Sort(maxs, Comparer<int[]>.Create((a, b) => b[0] - a[0]));
            Array.Sort(mins, Comparer<int[]>.Create((a, b) => a[0] - b[0]));

            if (maxs[0][1] != mins[0][1])
            {
                return maxs[0][0] - mins[0][0];
            }
            else
            {
                return Math.Max(maxs[1][0] - mins[0][0], maxs[0][0] - mins[1][0]);
            }
        }

        /// <summary>
        /// 单次扫描
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int MaxDistance2(IList<IList<int>> arrays)
        {
            int res = 0;
            int n = arrays[0].Count;
            int minVal = arrays[0][0];
            int maxVal = arrays[0][n - 1];
            for (int i = 1; i < arrays.Count; i++)
            {
                n = arrays[i].Count;
                res = Math.Max(res, Math.Max(Math.Abs(arrays[i][n - 1] - minVal),
                                             Math.Abs(maxVal - arrays[i][0])));
                minVal = Math.Min(minVal, arrays[i][0]);
                maxVal = Math.Max(maxVal, arrays[i][n - 1]);
            }
            return res;
        }
    }
}
