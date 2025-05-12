namespace Code
{
    /// <summary>
    /// 2094. Finding 3-Digit Even Numbers
    /// 2094. 找出 3 位偶数
    /// 
    /// You are given an integer array digits, where each element is a digit. The array may contain duplicates.
    /// 给你一个整数数组 digits ，其中每个元素是一个数字（0 - 9）。数组中可能存在重复元素。
    /// 
    /// You need to find all the unique integers that follow the given requirements:
    /// 你需要找出 所有 满足下述条件且 互不相同 的整数：
    /// 
    /// * The integer consists of the concatenation of three elements from digits in any arbitrary order.
    /// * 该整数由 digits 中的三个元素按 任意 顺序 依次连接 组成。
    /// 
    /// * The integer does not have leading zeros.
    /// * 该整数不含 前导零
    /// 
    /// * The integer is even.
    /// * 该整数是一个 偶数
    /// 
    /// For example, if the given digits were [1, 2, 3], integers 132 and 312 follow the requirements.
    /// 例如，给定的 digits 是 [1, 2, 3] ，整数 132 和 312 满足上面列出的全部条件。
    /// 
    /// Return a sorted array of the unique integers.
    /// 将找出的所有互不相同的整数按 递增顺序 排列，并以数组形式返回。
    /// 
    /// </summary>
    public class Finding_3_Digit_Even_Numbers
    {
        public int[] FindEvenNumbers(int[] digits)
        {
            List<int> res = new List<int>();
            int[] nums = new int[10];
            foreach (var digit in digits)
            {
                nums[digit]++;
            }
            for (var i = 100; i < 999; i += 2)
            {
                Dictionary<int, int> dp = new Dictionary<int, int>();
                int num1 = i % 10;
                if (dp.ContainsKey(num1))
                {
                    dp[num1]++;
                }
                else
                {
                    dp[num1] = 1;
                }


                int num2 = i % 100 / 10;
                if (dp.ContainsKey(num2))
                {
                    dp[num2]++;
                }
                else
                {
                    dp[num2] = 1;
                }

                int num3 = i / 100;
                if (dp.ContainsKey(num3))
                {
                    dp[num3]++;
                }
                else
                {
                    dp[num3] = 1;
                }

                bool flag = true;
                foreach (var d in dp)
                {
                    if (nums[d.Key] < d.Value)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    res.Add(i);
                }
            }

            return res.ToArray();
        }
    }
}
