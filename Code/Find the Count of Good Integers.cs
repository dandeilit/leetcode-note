namespace Code
{
    /// <summary>
    /// 3272. Find the Count of Good Integers
    /// 3272. 统计好整数的数目
    /// 
    /// You are given two positive integers n and k.
    /// 给你两个 正 整数 n 和 k 。
    /// 
    /// An integer x is called k-palindromic if:
    /// 如果一个整数 x 满足以下条件，那么它被称为 k 回文 整数 。
    /// 
    /// * x is a palindrome.
    /// x 是一个 回文整数 。
    /// 
    /// * x is divisible by k.
    /// x 能被 k 整除。
    /// 
    /// An integer is called good if its digits can be rearranged to form a k-palindromic integer. For example, for k = 2, 2020 can be rearranged to form the k-palindromic integer 2002, whereas 1010 cannot be rearranged to form a k-palindromic integer.
    /// 如果一个整数的数位重新排列后能得到一个 k 回文整数 ，那么我们称这个整数为 好 整数。比方说，k = 2 ，那么 2020 可以重新排列得到 2002 ，2002 是一个 k 回文串，所以 2020 是一个好整数。而 1010 无法重新排列数位得到一个 k 回文整数。
    /// 
    /// Return the count of good integers containing n digits.
    /// 请你返回 n 个数位的整数中，有多少个 好 整数。
    /// 
    /// Note that any integer must not have leading zeros, neither before nor after rearrangement. For example, 1010 cannot be rearranged to form 101.
    /// 注意 ，任何整数在重新排列数位之前或者之后 都不能 有前导 0 。比方说 1010 不能重排列得到 101 。
    /// 
    /// </summary>
    public class Find_the_Count_of_Good_Integers
    {
        /// <summary>
        /// 枚举 + 排列组合
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountGoodIntegers(int n, int k)
        {
            var dict = new HashSet<string>();
            int baseVal = (int)Math.Pow(10, (n - 1) / 2);
            int skip = n & 1;
            /* 枚举 n 个数位的回文数 */
            for (int i = baseVal; i < baseVal * 10; i++)
            {
                string s = i.ToString();
                s += new string(s.Reverse().Skip(skip).ToArray());
                long palindromicInteger = long.Parse(s);
                /* 如果当前回文数是 k 回文数 */
                if (palindromicInteger % k == 0)
                {
                    char[] chars = s.ToCharArray();
                    Array.Sort(chars);
                    dict.Add(new string(chars));
                }
            }

            long[] factorial = new long[n + 1];
            factorial[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial[i] = factorial[i - 1] * i;
            }

            long ans = 0;
            foreach (string s in dict)
            {
                int[] cnt = new int[10];
                foreach (char c in s)
                {
                    cnt[c - '0']++;
                }
                /* 计算排列组合 */
                long tot = (n - cnt[0]) * factorial[n - 1];
                foreach (int x in cnt)
                {
                    tot /= factorial[x];
                }
                ans += tot;
            }

            return ans;
        }
    }
}
