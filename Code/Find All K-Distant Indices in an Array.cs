namespace Code
{
    /// <summary>
    /// 2200. Find All K-Distant Indices in an Array
    /// 2200. 找出数组中的所有 K 近邻下标
    /// 
    /// You are given a 0-indexed integer array nums and two integers key and k. A k-distant index is an index i of nums for which there exists at least one index j such that |i - j| <= k and nums[j] == key.
    /// 给你一个下标从 0 开始的整数数组 nums 和两个整数 key 和 k 。K 近邻下标 是 nums 中的一个下标 i ，并满足至少存在一个下标 j 使得 |i - j| <= k 且 nums[j] == key 。
    /// 
    /// Return a list of all k-distant indices sorted in increasing order.
    /// 以列表形式返回按 递增顺序 排序的所有 K 近邻下标。
    /// 
    /// </summary>
    public class Find_All_K_Distant_Indices_in_an_Array
    {
        /// <summary>
        /// 一遍遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="key"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> FindKDistantIndices(int[] nums, int key, int k)
        {
            List<int> res = new List<int>();
            int r = 0; // 未被判断过的最小下标
            int n = nums.Length;
            for (int j = 0; j < n; ++j)
            {
                if (nums[j] == key)
                {
                    int l = Math.Max(r, j - k);
                    r = Math.Min(n - 1, j + k) + 1;
                    for (int i = l; i < r; ++i)
                    {
                        res.Add(i);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="key"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public IList<int> FindKDistantIndices2(int[] nums, int key, int k)
        {
            List<int> res = new List<int>();
            int n = nums.Length;
            // 遍历数对
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (nums[j] == key && Math.Abs(i - j) <= k)
                    {
                        res.Add(i);
                        break; // 提前结束以防止重复添加
                    }
                }
            }
            return res;
        }
    }
}
