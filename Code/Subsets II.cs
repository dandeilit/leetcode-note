namespace Code
{
    /// <summary>
    /// 90. Subsets II
    /// 
    /// Given an integer array nums that may contain duplicates, return all possible subsets (the power set).
    /// 给定一个可能包含重复项的整数数组 nums，返回所有可能的子集（幂集）。
    /// 
    /// The solution set must not contain duplicate subsets. Return the solution in any order.
    /// 解决方案集不得包含重复的子集。以任意顺序返回解决方案。
    /// 
    /// </summary>
    public class Subsets_II
    {
        /// <summary>
        /// 迭代
        /// 若发现没有选择上一个数，且当前数字与上一个数相同，则可以跳过当前生成的子集
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> ans = new List<IList<int>>();
            int n = nums.Length;

            // 二进制位运算表示选与不选
            for (int mask = 0; mask < (1 << n); ++mask)
            {
                List<int> t = new List<int>();
                bool flag = true;
                for (int i = 0; i < n; ++i)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        if (i > 0 && (mask & (1 << (i - 1))) == 0 && nums[i] == nums[i - 1])
                        {
                            flag = false;
                            break;
                        }
                        t.Add(nums[i]);
                    }
                }
                if (flag)
                {
                    ans.Add(t);
                }
            }
            return ans;
        }

        /// <summary>
        /// 递归
        /// 若发现没有选择上一个数，且当前数字与上一个数相同，则可以跳过当前生成的子集
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup2(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> ans = new List<IList<int>>();
            List<int> t = new List<int>();
            Dfs(false, 0, nums, t, ans);
            return ans;
        }

        private void Dfs(bool choosePre, int cur, int[] nums, List<int> t, IList<IList<int>> ans)
        {
            if (cur == nums.Length)
            {
                ans.Add(new List<int>(t));
                return;
            }
            Dfs(false, cur + 1, nums, t, ans);
            if (!choosePre && cur > 0 && nums[cur - 1] == nums[cur])
            {
                return;
            }
            t.Add(nums[cur]);
            Dfs(true, cur + 1, nums, t, ans);
            t.RemoveAt(t.Count - 1);
        }
    }
}
