namespace Code
{
    /// <summary>
    /// 2275. Largest Combination With Bitwise AND Greater Than Zero
    /// 
    /// The bitwise AND of an array nums is the bitwise AND of all integers in nums.
    /// 数组 nums 的按位与是 nums 中所有整数的按位与。
    /// 
    /// * For example, for nums = [1, 5, 3], the bitwise AND is equal to 1 & 5 & 3 = 1.
    /// * 例如，对于 nums = [1, 5, 3]，按位与等于 1 & 5 & 3 = 1。
    /// 
    /// * Also, for nums = [7], the bitwise AND is 7.
    /// * 此外，对于 nums = [7]，按位与为 7。
    /// 
    /// You are given an array of positive integers candidates. Compute the bitwise AND for all possible combinations of elements in the candidates array.
    /// 给定一个正整数候选数组。计算候选数组中所有可能元素组合的按位与。
    /// 
    /// Return the size of the largest combination of candidates with a bitwise AND greater than 0.
    /// 返回按位与大于 0 的最大候选组合的大小。
    /// 
    /// </summary>
    public class LargestCombination
    {
        /// <summary>
        /// 统计所有数字各二进制位上最多的1出现次数
        /// 只有子集中每个数字某一位都是1才保证结果不为0
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        public int Solution(int[] candidates)
        {
            int[] map = new int[32];
            foreach (var candidate in candidates)
            {
                for (var i = 0; i < 32; i++)
                {
                    if ((candidate & (1 << i)) > 0)
                    {
                        map[i]++;
                    }
                }
            }
            return map.Max();
        }
    }
}
