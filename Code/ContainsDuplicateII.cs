namespace Code
{
    /// <summary>
    /// 219. Contains Duplicate II
    /// 
    /// Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
    /// 给定一个整数数组 nums 和一个整数 k，如果数组中有两个不同的索引 i 和 j，使得 nums[i] == nums[j] 且 abs(i - j) <= k，则返回 true。
    /// 
    /// </summary>
    public class ContainsDuplicateII
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]) && Math.Abs(i - dict[nums[i]]) <= k)
                {
                    return true;
                }
                dict[nums[i]] = i;
            }

            return false;
        }


        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool ContainsNearbyDuplicate2(int[] nums, int k)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > k) set.Remove(nums[i - k - 1]);
                if (!set.Add(nums[i])) return true;
            }
            return false;
        }
    }
}
