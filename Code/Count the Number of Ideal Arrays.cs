namespace Code
{
    /// <summary>
    /// 2338. Count the Number of Ideal Arrays
    /// 2338. 统计理想数组的数目
    /// 
    /// You are given two integers n and maxValue, which are used to describe an ideal array.
    /// 给你两个整数 n 和 maxValue ，用于描述一个 理想数组 。
    /// 
    /// A 0-indexed integer array arr of length n is considered ideal if the following conditions hold:
    /// 对于下标从 0 开始、长度为 n 的整数数组 arr ，如果满足以下条件，则认为该数组是一个 理想数组 ：
    /// 
    /// * Every arr[i] is a value from 1 to maxValue, for 0 <= i < n.
    /// * 每个 arr[i] 都是从 1 到 maxValue 范围内的一个值，其中 0 <= i < n 。
    /// 
    /// * Every arr[i] is divisible by arr[i - 1], for 0 < i < n.
    /// * 每个 arr[i] 都可以被 arr[i - 1] 整除，其中 0 < i < n 。
    /// 
    /// Return the number of distinct ideal arrays of length n. Since the answer may be very large, return it modulo Math.Pow(10,9) + 7.
    /// 返回长度为 n 的 不同 理想数组的数目。由于答案可能很大，返回对 Math.Pow(10,9) + 7 取余的结果。
    /// 
    /// </summary>
    public class Count_the_Number_of_Ideal_Arrays
    {
        const int MOD = 1000000007;
        const int MAX_N = 10010;
        const int MAX_P = 15; // 最多有 15 个质因子
        int[,] c = new int[MAX_N + MAX_P, MAX_P + 1];
        int[] sieve = new int[MAX_N]; // 最小质因子
        List<int>[] ps = new List<int>[MAX_N]; // 质因子个数列表

        public Count_the_Number_of_Ideal_Arrays()
        {
            if (c[0, 0] == 1)
            {
                return;
            }
            for (int i = 0; i < MAX_N; i++)
            {
                ps[i] = new List<int>();
            }
            for (int i = 2; i < MAX_N; i++)
            {
                if (sieve[i] == 0)
                {
                    for (int j = i; j < MAX_N; j += i)
                    {
                        if (sieve[j] == 0)
                        {
                            sieve[j] = i;
                        }
                    }
                }
            }

            for (int i = 2; i < MAX_N; i++)
            {
                int x = i;
                while (x > 1)
                {
                    int p = sieve[x];
                    int cnt = 0;
                    while (x % p == 0)
                    {
                        x /= p;
                        cnt++;
                    }
                    ps[i].Add(cnt);
                }
            }
            c[0, 0] = 1;
            for (int i = 1; i < MAX_N + MAX_P; i++)
            {
                c[i, 0] = 1;
                for (int j = 1; j <= Math.Min(i, MAX_P); j++)
                {
                    c[i, j] = (c[i - 1, j] + c[i - 1, j - 1]) % MOD;
                }
            }
        }

        /// <summary>
        /// 组合数学
        /// 隔板法
        /// </summary>
        /// <param name="n"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int IdealArrays(int n, int maxValue)
        {
            long ans = 0;
            for (int x = 1; x <= maxValue; x++)
            {
                long mul = 1;
                foreach (var p in ps[x])
                {
                    mul = mul * c[n + p - 1, p] % MOD;
                }
                ans = (ans + mul) % MOD;
            }
            return (int)ans;
        }
    }
}
