namespace Code
{
    /// <summary>
    /// 47. Permutations II
    /// 
    /// Given a collection of numbers, nums, that might contain duplicates, return all possible unique permutations in any order.
    /// 给定一个可能包含重复项的数字集合 nums，以任意顺序返回所有可能的唯一排列。
    /// 
    /// </summary>
    public class Permutations_II
    {
        /// <summary>
        /// 搜索回溯
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var ans = new List<IList<int>>();
            var perm = new List<int>();
            vis = new List<bool>(new bool[nums.Length]);
            Array.Sort(nums);
            Backtrack(nums, ans, 0, perm);
            return ans;
        }

        // 标记数字是否已经使用
        private List<bool> vis;

        private void Backtrack(IList<int> nums, IList<IList<int>> ans, int idx, IList<int> perm)
        {
            // 索引与数组长度相同，代表数组内数字已排列完成，可加入答案返回
            if (idx == nums.Count)
            {
                ans.Add(new List<int>(perm));
                return;
            }

            for (int i = 0; i < nums.Count; ++i)
            {
                // 当前数已使用
                if (vis[i])
                {
                    continue;
                }

                // 去除重复排列
                if (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1])
                {
                    continue;
                }

                perm.Add(nums[i]);
                vis[i] = true;
                Backtrack(nums, ans, idx + 1, perm);
                vis[i] = false;
                perm.RemoveAt(perm.Count - 1);
            }
        }
    }
}
