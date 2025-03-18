namespace Code
{
    /// <summary>
    /// 2614. Prime In Diagonal
    /// 2614. 对角线上的质数
    /// 
    /// You are given a 0-indexed two-dimensional integer array nums.
    /// 给你一个下标从 0 开始的二维整数数组 nums 。
    /// 
    /// Return the largest prime number that lies on at least one of the diagonals of nums. In case, no prime is present on any of the diagonals, return 0.
    /// 返回位于 nums 至少一条 对角线 上的最大 质数 。如果任一对角线上均不存在质数，返回 0 。
    /// 
    /// Note that:
    /// 注意：
    /// 
    /// * An integer is prime if it is greater than 1 and has no positive integer divisors other than 1 and itself.
    /// * 如果某个整数大于 1 ，且不存在除 1 和自身之外的正整数因子，则认为该整数是一个质数。
    /// 
    /// * An integer val is on one of the diagonals of nums if there exists an integer i for which nums[i][i] = val or an i for which nums[i][nums.length - i - 1] = val.
    /// * 如果存在整数 i ，使得 nums[i][i] = val 或者 nums[i][nums.length - i - 1]= val ，则认为整数 val 位于 nums 的一条对角线上。
    /// 
    /// | 1 | 2 | 3 |
    /// | 4 | 5 | 6 |
    /// | 7 | 8 | 9 |
    /// 
    /// In the above diagram, one diagonal is [1,5,9] and another diagonal is [3,5,7].
    /// 在上图中，一条对角线是 [1,5,9] ，而另一条对角线是 [3,5,7] 。
    /// 
    /// </summary>
    public class Prime_In_Diagonal
    {
        public int DiagonalPrime(int[][] nums)
        {
            int maxPrimeNum = 0;
            int n = nums.Length;
            for (var i = 0; i < n; i++)
            {
                if (IsPrimeNum(nums[i][i]))
                {
                    maxPrimeNum = Math.Max(nums[i][i], maxPrimeNum);
                }

                if (IsPrimeNum(nums[i][n - 1 - i]))
                {
                    maxPrimeNum = Math.Max(nums[i][n - 1 - i], maxPrimeNum);
                }
            }
            return maxPrimeNum;
        }

        private bool IsPrimeNum(int num)
        {
            if (num <= 1) return false;

            int factor = 2;
            while (factor * factor <= num)
            {
                if (num % factor == 0)
                {
                    return false;
                }
                factor++;
            }
            return true;
        }
    }
}
