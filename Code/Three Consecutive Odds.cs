namespace Code
{
    /// <summary>
    /// 1550. Three Consecutive Odds
    /// 1550. 存在连续三个奇数的数组
    /// 
    /// Given an integer array arr, return true if there are three consecutive odd numbers in the array. Otherwise, return false.
    /// 给你一个整数数组 arr，请你判断数组中是否存在连续三个元素都是奇数的情况：如果存在，请返回 true ；否则，返回 false 。
    /// 
    /// </summary>
    public class Three_Consecutive_Odds
    {
        public bool ThreeConsecutiveOdds(int[] arr)
        {
            int num = 0;
            foreach (var item in arr)
            {
                if (item % 2 == 0)
                {
                    num = 0;
                }
                else
                {
                    num++;
                    if (num >= 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
