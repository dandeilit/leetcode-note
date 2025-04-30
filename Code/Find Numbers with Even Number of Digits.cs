namespace Code
{
    /// <summary>
    /// 1295. Find Numbers with Even Number of Digits
    /// 1295. 统计位数为偶数的数字
    /// 
    /// Given an array nums of integers, return how many of them contain an even number of digits.
    /// 给你一个整数数组 nums，请你返回其中包含 偶数 个数位的数字的个数。
    /// 
    /// </summary>
    public class Find_Numbers_with_Even_Number_of_Digits
    {
        public int FindNumbers(int[] nums)
        {
            int ans = 0;
            foreach (var num in nums)
            {
                if (GetLen(num) % 2 == 0)
                {
                    ans++;
                }
            }
            return ans;
        }

        private int GetLen(int num)
        {
            int len = 1;
            while (num >= 10)
            {
                len++;
                num = num / 10;
            }
            return len;
        }
    }
}
