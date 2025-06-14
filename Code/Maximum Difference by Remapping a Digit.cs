namespace Code
{
    /// <summary>
    /// 2566. Maximum Difference by Remapping a Digit
    /// 2566. 替换一个数字后的最大差值
    /// 
    /// You are given an integer num. You know that Bob will sneakily remap one of the 10 possible digits (0 to 9) to another digit.
    /// 给你一个整数 num 。你知道 Bob 会偷偷将 0 到 9 中的一个数字 替换 成另一个数字。
    /// 
    /// Return the difference between the maximum and minimum values Bob can make by remapping exactly one digit in num.
    /// 请你返回将 num 中 恰好一个 数字进行替换后，得到的最大值和最小值的差为多少。
    /// 
    /// Notes:
    /// 注意：
    /// 
    /// * When Bob remaps a digit d1 to another digit d2, Bob replaces all occurrences of d1 in num with d2.
    /// * 当 Bob 将一个数字 d1 替换成另一个数字 d2 时，Bob 需要将 nums 中所有 d1 都替换成 d2 。
    /// 
    /// * Bob can remap a digit to itself, in which case num does not change.
    /// * Bob 可以将一个数字替换成它自己，也就是说 num 可以不变。
    /// 
    /// * Bob can remap different digits for obtaining minimum and maximum values respectively.
    /// * Bob 可以将数字分别替换成两个不同的数字分别得到最大值和最小值。
    /// 
    /// * The resulting number after remapping can contain leading zeroes.
    /// * 替换后得到的数字可以包含前导 0 。
    /// 
    /// </summary>
    public class Maximum_Difference_by_Remapping_a_Digit
    {
        /// <summary>
        /// 数字计算
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinMaxDifference(int num)
        {
            if (num <= 9) return 9;


            int maxVal = Replace(num, 9);
            int minVal = Replace(num, 0);
            return maxVal - minVal;
        }

        private int Replace(int num, int k)
        {
            int val = 0;
            int replace = num % 10;
            int rem = num / 10;
            while (rem > 9)
            {
                int nReplace = rem % 10;
                if (nReplace != k)
                {
                    replace = nReplace;
                }
                rem = rem / 10;
            }
            if (rem != k) replace = rem;

            rem = num;
            int c = 1;
            while (rem > 9)
            {
                int i = rem % 10;
                if (i == replace)
                {
                    val += k * c;
                }
                else
                {
                    val += i * c;
                }

                c *= 10;
                rem = rem / 10;
            }
            if (rem == replace)
            {
                val += k * c;
            }
            else
            {
                val += rem * c;
            }
            return val;
        }


        /// <summary>
        /// 转换文本替换后转换数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinMaxDifference2(int num)
        {
            string max = GetNum(num.ToString(), '9');
            string min = GetNum(num.ToString(), '0');
            static string GetNum(string arr, char c)
            {
                for (int i = 0; i < arr.Length; ++i)
                {
                    if (arr[i] != c)
                    {
                        return arr.Replace(arr[i], c);
                    }
                }
                return arr;
            }
            return int.Parse(max) - int.Parse(min);
        }
    }
}
