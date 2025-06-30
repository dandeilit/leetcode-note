namespace Code
{
    /// <summary>
    /// 594. Longest Harmonious Subsequence
    /// 594. 最长和谐子序列
    /// 
    /// We define a harmonious array as an array where the difference between its maximum value and its minimum value is exactly 1.
    /// 和谐数组是指一个数组里元素的最大值和最小值之间的差别 正好是 1 。
    /// 
    /// Given an integer array nums, return the length of its longest harmonious subsequence among all its possible subsequences.
    /// 给你一个整数数组 nums ，请你在所有可能的 子序列 中找到最长的和谐子序列的长度。
    /// 
    /// 数组的 子序列 是一个由数组派生出来的序列，它可以通过删除一些元素或不删除元素、且不改变其余元素的顺序而得到。
    /// 
    /// </summary>
    public class Longest_Harmonious_Subsequence
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindLHS(int[] nums)
        {
            Array.Sort(nums);
            int begin = 0;
            int res = 0;
            for (int end = 0; end < nums.Length; end++)
            {
                while (nums[end] - nums[begin] > 1)
                {
                    begin++;
                }
                if (nums[end] - nums[begin] == 1)
                {
                    res = Math.Max(res, end - begin + 1);
                }
            }
            return res;
        }

        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FindRHS2(int[] nums)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            int res = 0;
            foreach (int num in nums)
            {
                if (dictionary.ContainsKey(num))
                {
                    dictionary[num]++;
                }
                else
                {
                    dictionary.Add(num, 1);
                }
            }
            foreach (int key in dictionary.Keys)
            {
                if (dictionary.ContainsKey(key + 1))
                {
                    res = Math.Max(res, dictionary[key] + dictionary[key + 1]);
                }
            }
            return res;
        }
    }
}
