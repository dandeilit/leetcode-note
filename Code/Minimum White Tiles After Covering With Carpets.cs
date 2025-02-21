namespace Code
{
    /// <summary>
    /// 2209. Minimum White Tiles After Covering With Carpets
    /// 
    /// You are given a 0-indexed binary string floor, which represents the colors of tiles on a floor:
    /// 给定一个 0 索引的二进制字符串 floor，它表示地板上瓷砖的颜色：
    /// 
    /// * floor[i] = '0' denotes that the i-th tile of the floor is colored black.
    /// * floor[i] = '0' 表示地板上的第 i 块瓷砖是黑色的。
    /// 
    /// * On the other hand, floor[i] = '1' denotes that the i-th tile of the floor is colored white.
    /// * 另一方面，floor[i] = '1' 表示地板上的第 i 块瓷砖是白色的。
    /// 
    /// You are also given numCarpets and carpetLen. You have numCarpets black carpets, each of length carpetLen tiles. Cover the tiles with the given carpets such that the number of white tiles still visible is minimum. Carpets may overlap one another.
    /// 还将为您提供 numCarpets 和 carpetLen。您有 numCarpets 张黑色地毯，每张地毯的长度为 carpetLen 块瓷砖。用给定的地毯覆盖瓷砖，使仍然可见的白色瓷砖数量最少。地毯可以相互重叠。
    /// 
    /// Return the minimum number of white tiles still visible.
    /// 返回仍然可见的白色瓷砖的最小数量。
    /// 
    /// </summary>
    public class Minimum_White_Tiles_After_Covering_With_Carpets
    {
        /// <summary>
        /// 动态规划
        /// dp[i,j] 表示在前 i 块砖块上使用 j 张地毯后，最少有多少未被覆盖的白色砖块
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="numCarpets"></param>
        /// <param name="carpetLen"></param>
        /// <returns></returns>
        public int MinimumWhiteTiles(string floor, int numCarpets, int carpetLen)
        {
            int n = floor.Length;
            int[,] dp = new int[n + 1, numCarpets + 1];
            for (var i = 0; i <= n; i++)
            {
                for (var j = 0; j <= numCarpets; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            for (var j = 0; j <= numCarpets; j++)
            {
                dp[0, j] = 0;
            }

            for (var i = 1; i <= n; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + (floor[i - 1] == '1' ? 1 : 0);
            }

            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= numCarpets; j++)
                {
                    // 不增加地毯，按原逻辑铺设地毯，多出来的一块地砖为白色则最小数量加一
                    dp[i, j] = dp[i - 1, j] + (floor[i - 1] == '1' ? 1 : 0);

                    // 增加地毯，根据地毯长度判定，最优结果为增加的地毯刚好铺满多增加的地砖，与当前地砖数减去该地砖数时的最小数量一致
                    dp[i, j] = Math.Min(dp[i, j], dp[Math.Max(0, i - carpetLen), j - 1]);
                }
            }

            return dp[n, numCarpets];
        }

        /// <summary>
        /// 滚动数组优化
        /// </summary>
        /// <param name="floor"></param>
        /// <param name="numCarpets"></param>
        /// <param name="carpetLen"></param>
        /// <returns></returns>
        public int MinimumWhiteTiles2(string floor, int numCarpets, int carpetLen)
        {
            int n = floor.Length;
            int[] d = new int[n + 1];
            int[] f = new int[n + 1];
            Array.Fill(d, int.MaxValue);
            Array.Fill(f, int.MaxValue);
            d[0] = 0;
            for (int i = 1; i <= n; i++)
            {
                d[i] = d[i - 1] + (floor[i - 1] == '1' ? 1 : 0);
            }
            for (int j = 1; j <= numCarpets; j++)
            {
                f[0] = 0;
                for (int i = 1; i <= n; i++)
                {
                    f[i] = f[i - 1] + (floor[i - 1] == '1' ? 1 : 0);
                    f[i] = Math.Min(f[i], d[Math.Max(0, i - carpetLen)]);
                }
                int[] temp = d;
                d = f;
                f = temp;
            }

            return d[n];
        }
    }
}
