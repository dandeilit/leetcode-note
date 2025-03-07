namespace Code
{
    /// <summary>
    /// 2597. The Number of Beautiful Subsets
    /// 
    /// You are given an array nums of positive integers and a positive integer k.
    /// 给定一个正整数数组 nums 和一个正整数 k。
    /// 
    /// A subset of nums is beautiful if it does not contain two integers with an absolute difference equal to k.
    /// 如果 nums 的子集不包含两个绝对差等于 k 的整数，则该子集是美丽的。
    /// 
    /// Return the number of non-empty beautiful subsets of the array nums.
    /// 返回数组 nums 的非空美丽子集的数量。
    /// 
    /// A subset of nums is an array that can be obtained by deleting some (possibly none) elements from nums. Two subsets are different if and only if the chosen indices to delete are different.
    /// nums 的子集是通过从 nums 中删除一些（可能没有）元素获得的数组。当且仅当要删除的所选索引不同时，两个子集才是不同的。
    /// 
    /// </summary>
    public class The_Number_of_Beautiful_Subsets
    {
        private int ans = 0;
        private Dictionary<int, int> cnt = new Dictionary<int, int>();

        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int BeautifulSubsets(int[] nums, int k)
        {
            DFS(nums, k, 0);
            return ans - 1;
        }

        private void DFS(int[] nums, int k, int i)
        {
            if (i == nums.Length)
            {
                ans++;
                return;
            }
            DFS(nums, k, i + 1);
            if (cnt.GetValueOrDefault(nums[i] - k, 0) == 0 && cnt.GetValueOrDefault(nums[i] + k, 0) == 0)
            {
                cnt[nums[i]] = cnt.GetValueOrDefault(nums[i], 0) + 1;
                DFS(nums, k, i + 1);
                cnt[nums[i]] = cnt.GetValueOrDefault(nums[i], 0) - 1;
            }
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int BeautifulSubsets2(int[] nums, int k)
        {
            var groups = new Dictionary<int, SortedDictionary<int, int>>();
            foreach (int a in nums)
            {
                int mod = a % k;
                if (!groups.ContainsKey(mod))
                {
                    groups[mod] = new SortedDictionary<int, int>();
                }
                groups[mod][a] = groups[mod].GetValueOrDefault(a, 0) + 1;
            }
            int ans = 1;
            foreach (var g in groups.Values)
            {
                int m = g.Count;
                int[,] f = new int[m, 2];
                f[0, 0] = 1;
                f[0, 1] = (1 << g.First().Value) - 1;
                int i = 1;
                var prev = g.First();
                foreach (var curr in g.Skip(1))
                {
                    f[i, 0] = f[i - 1, 0] + f[i - 1, 1];
                    if (curr.Key - prev.Key == k)
                    {
                        f[i, 1] = f[i - 1, 0] * ((1 << curr.Value) - 1);
                    }
                    else
                    {
                        f[i, 1] = (f[i - 1, 0] + f[i - 1, 1]) * ((1 << curr.Value) - 1);
                    }
                    prev = curr;
                    i++;
                }
                ans *= f[m - 1, 0] + f[m - 1, 1];
            }
            return ans - 1;
        }

        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int BeautifulSubsets3(int[] nums, int k)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                CheckSet([], nums, i, k);
            }
            return ans;
        }


        private void CheckSet(int[] pre, int[] nums, int i, int k)
        {
            var preList = pre.ToList();
            if (i < nums.Length)
            {
                bool isBeautiful = true;
                preList.Add(nums[i]);
                foreach (var item in preList)
                {
                    if (Math.Abs(nums[i] - item) == k)
                    {
                        isBeautiful = false;
                        break;
                    }
                }

                if (isBeautiful)
                {
                    ans++;

                    for (var j = i + 1; j < nums.Length; j++)
                    {
                        CheckSet(preList.ToArray(), nums, j, k);
                    }
                }
            }
        }
    }
}
