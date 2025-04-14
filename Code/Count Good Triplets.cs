namespace Code
{
    /// <summary>
    /// 1534. Count Good Triplets
    /// 1534. 统计好三元组
    /// 
    /// Given an array of integers arr, and three integers a, b and c. You need to find the number of good triplets.
    /// 给你一个整数数组 arr ，以及 a、b 、c 三个整数。请你统计其中好三元组的数量。
    /// 
    /// A triplet (arr[i], arr[j], arr[k]) is good if the following conditions are true:
    /// 如果三元组 (arr[i], arr[j], arr[k]) 满足下列全部条件，则认为它是一个 好三元组 。
    /// 
    /// * 0 <= i < j < k < arr.length
    /// 
    /// * |arr[i] - arr[j]| <= a
    /// 
    /// * |arr[j] - arr[k]| <= b
    /// 
    /// * |arr[i] - arr[k]| <= c
    /// 
    /// Where |x| denotes the absolute value of x.
    /// 其中 |x| 表示 x 的绝对值。
    /// 
    /// Return the number of good triplets.
    /// 返回 好三元组的数量 。
    /// 
    /// </summary>
    public class Count_Good_Triplets
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int n = arr.Length;
            int ans = 0;
            for (var j = 1; j < n - 1; j++)
            {
                for (var i = 0; i < j; i++)
                {
                    if (Math.Abs(arr[i] - arr[j]) > a)
                    {
                        continue;
                    }

                    for (var k = j + 1; k < n; k++)
                    {
                        if (Math.Abs(arr[j] - arr[k]) > b)
                        {
                            continue;
                        }

                        if (Math.Abs(arr[i] - arr[k]) > c)
                        {
                            continue;
                        }

                        ans++;
                    }
                }
            }
            return ans;
        }

        /// <summary>
        /// 枚举优化
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int CountGoodTriplets2(int[] arr, int a, int b, int c)
        {
            int ans = 0, n = arr.Length;
            int[] sum = new int[1001];
            for (int j = 0; j < n; ++j)
            {
                for (int k = j + 1; k < n; ++k)
                {
                    if (Math.Abs(arr[j] - arr[k]) <= b)
                    {
                        int lj = arr[j] - a, rj = arr[j] + a;
                        int lk = arr[k] - c, rk = arr[k] + c;
                        int l = Math.Max(0, Math.Max(lj, lk)), r = Math.Min(1000, Math.Min(rj, rk));
                        if (l <= r)
                        {
                            if (l == 0)
                            {
                                ans += sum[r];
                            }
                            else
                            {
                                ans += sum[r] - sum[l - 1];
                            }
                        }
                    }
                }
                for (int k = arr[j]; k <= 1000; ++k)
                {
                    ++sum[k];
                }
            }
            return ans;
        }
    }
}
