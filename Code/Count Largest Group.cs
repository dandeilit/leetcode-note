namespace Code
{
    /// <summary>
    /// 1399. Count Largest Group
    /// 1399. 统计最大组的数目
    /// 
    /// You are given an integer n.
    /// 给你一个整数 n 。
    /// 
    /// Each number from 1 to n is grouped according to the sum of its digits.
    /// 请你先求出从 1 到 n 的每个整数 10 进制表示下的数位和（每一位上的数字相加），然后把数位和相等的数字放到同一个组中。
    /// 
    /// Return the number of groups that have the largest size.
    /// 请你统计每个组中的数字数目，并返回数字数目并列最多的组有多少个。
    /// 
    /// </summary>
    public class Count_Largest_Group
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountLargestGroup(int n)
        {
            var hashMap = new Dictionary<int, int>();
            int maxValue = 0;
            for (int i = 1; i <= n; ++i)
            {
                int key = 0, i0 = i;
                while (i0 > 0)
                {
                    key += i0 % 10;
                    i0 /= 10;
                }
                if (hashMap.ContainsKey(key))
                {
                    hashMap[key]++;
                }
                else
                {
                    hashMap[key] = 1;
                }
                maxValue = Math.Max(maxValue, hashMap[key]);
            }

            int count = 0;
            foreach (var value in hashMap.Values)
            {
                if (value == maxValue)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
