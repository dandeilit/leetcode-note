namespace Code
{
    /// <summary>
    /// 2239. Find Closest Number to Zero
    /// 
    /// Given an integer array nums of size n, return the number with the value closest to 0 in nums. If there are multiple answers, return the number with the largest value.
    /// 给定一个大小为 n 的整数数组 nums，返回 nums 中值最接近 0 的数字。如果有多个答案，则返回值最大的数字。
    /// 
    /// </summary>
    public class FindClosestNumber
    {
        public int Solution(int[] nums)
        {
            int ans = int.MaxValue;
            foreach (var num in nums)
            {
                int absN = Math.Abs(num);
                int absA = Math.Abs(ans);
                if (absN > absA || (absN == absA && num <= ans))
                {
                    continue;
                }

                ans = num;
            }
            return ans;
        }
    }
}
