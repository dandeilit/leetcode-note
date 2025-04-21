namespace Code
{
    /// <summary>
    /// 2145. Count the Hidden Sequences
    /// 2145. 统计隐藏数组数目
    /// 
    /// You are given a 0-indexed array of n integers differences, which describes the differences between each pair of consecutive integers of a hidden sequence of length (n + 1). More formally, call the hidden sequence hidden, then we have that differences[i] = hidden[i + 1] - hidden[i].
    /// 给你一个下标从 0 开始且长度为 n 的整数数组 differences ，它表示一个长度为 n + 1 的 隐藏 数组 相邻 元素之间的 差值 。更正式的表述为：我们将隐藏数组记作 hidden ，那么 differences[i] = hidden[i + 1] - hidden[i] 。
    /// 
    /// You are further given two integers lower and upper that describe the inclusive range of values [lower, upper] that the hidden sequence can contain.
    /// 同时给你两个整数 lower 和 upper ，它们表示隐藏数组中所有数字的值都在 闭 区间 [lower, upper] 之间。
    /// 
    /// For example, given differences = [1, -3, 4], lower = 1, upper = 6, the hidden sequence is a sequence of length 4 whose elements are in between 1 and 6 (inclusive).
    /// 比方说，differences = [1, -3, 4] ，lower = 1 ，upper = 6 ，那么隐藏数组是一个长度为 4 且所有值都在 1 和 6 （包含两者）之间的数组。
    /// 
    /// * [3, 4, 1, 5] and [4, 5, 2, 6] are possible hidden sequences.
    /// * [3, 4, 1, 5] 和 [4, 5, 2, 6] 都是符合要求的隐藏数组。
    /// 
    /// * [5, 6, 3, 7] is not possible since it contains an element greater than 6.
    /// * [5, 6, 3, 7] 不符合要求，因为它包含大于 6 的元素。
    /// 
    /// * [1, 2, 3, 4] is not possible since the differences are not correct.
    /// * [1, 2, 3, 4] 不符合要求，因为相邻元素的差值不符合给定数据。
    /// 
    /// Return the number of possible hidden sequences there are. If there are no possible sequences, return 0.
    /// 请你返回 符合 要求的隐藏数组的数目。如果没有符合要求的隐藏数组，请返回 0 。
    /// 
    /// </summary>
    public class Count_the_Hidden_Sequences
    {
        /// <summary>
        /// 确定隐藏数组上下界的差值
        /// </summary>
        /// <param name="differences"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        public int NumberOfArrays(int[] differences, int lower, int upper)
        {
            int n = differences.Length;
            int diff = 0;
            int minDiff = diff;
            int maxDiff = diff;
            for (var i = 0; i < n; i++)
            {
                diff += differences[i];
                minDiff = Math.Min(minDiff, diff);
                maxDiff = Math.Max(maxDiff, diff);
                if (maxDiff - minDiff > upper - lower)
                {
                    return 0;
                }
            }

            return (upper - lower) - (maxDiff - minDiff) + 1;
        }
    }
}
