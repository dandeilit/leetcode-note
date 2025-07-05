namespace Code
{
    /// <summary>
    /// 1394. Find Lucky Integer in an Array
    /// 1394. 找出数组中的幸运数
    /// 
    /// 在整数数组中，如果一个整数的出现频次和它的数值大小相等，我们就称这个整数为「幸运数」。
    /// 
    /// Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
    /// 给你一个整数数组 arr，请你从中找出并返回一个幸运数。
    /// 
    /// Return the largest lucky integer in the array. If there is no lucky integer return -1.
    /// * 如果数组中存在多个幸运数，只需返回 最大 的那个。
    /// * 如果数组中不含幸运数，则返回 -1 。
    /// 
    /// </summary>
    public class Find_Lucky_Integer_in_an_Array
    {
        public int FindLucky(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (map.ContainsKey(num))
                {
                    map[num] += 1;
                }
                else
                {
                    map.Add(num, 1);
                }
            }

            int lucky = -1;
            foreach (var m in map)
            {
                if (m.Key == m.Value)
                {
                    lucky = Math.Max(lucky, m.Key);
                }
            }
            return lucky;
        }
    }
}
