namespace Code
{
    /// <summary>
    /// 1760. Minimum Limit of Balls in a Bag
    /// 
    /// You are given an integer array nums where the i-th bag contains nums[i] balls. You are also given an integer maxOperations.
    /// 给定一个整数数组 nums，其中第 i 个袋子包含 nums[i] 个球。还给定一个整数 max Operations。
    /// 
    /// You can perform the following operation at most maxOperations times:
    /// 您最多可以执行以下操作 max 次：
    /// 
    /// * Take any bag of balls and divide it into two new bags with a positive number of balls. For example, a bag of 5 balls can become two new bags of 1 and 4 balls, or two new bags of 2 and 3 balls.
    /// * 取任意一袋球，将其分成两个新袋，每个袋中的球数为正数。例如，一袋 5 个球可以变成两个新袋，每个袋中分别有 1 个和 4 个球，或者两个新袋，每个袋中分别有 2 个和 3 个球。
    /// 
    /// Your penalty is the maximum number of balls in a bag. You want to minimize your penalty after the operations.
    /// 您的惩罚是袋子中的最大球数。您希望在操作后将惩罚最小化。
    /// 
    /// Return the minimum possible penalty after performing the operations.
    /// 返回执行操作后可能的最小惩罚。
    /// 
    /// </summary>
    public class Minimum_Limit_of_Balls_in_a_Bag
    {
        /// <summary>
        /// 二分查找
        /// 问题可转化为：给定 maxOperations 次操作次数，能否可以使得单个袋子里球数目的最大值不超过 y。
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="maxOperations"></param>
        /// <returns></returns>
        public int MinimumSize(int[] nums, int maxOperations)
        {
            int left = 1, right = nums.Max();
            int ans = 0;
            while (left <= right)
            {
                int y = (left + right) / 2;
                long ops = 0;
                foreach (int x in nums)
                {
                    // x == y 时，无需分割
                    ops += (x - 1) / y;
                }
                if (ops <= maxOperations)
                {
                    ans = y;
                    right = y - 1;
                }
                else
                {
                    left = y + 1;
                }
            }
            return ans;
        }
    }
}
