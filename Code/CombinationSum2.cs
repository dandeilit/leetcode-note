namespace Code
{
    /// <summary>
    /// 40. Combination Sum II
    /// 
    /// Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.
    /// 给定一个候选数字集合（候选数）和一个目标数字（目标），找出候选数中所有唯一组合，使候选数之和等于目标。
    /// 
    /// Each number in candidates may only be used once in the combination.
    /// 候选数中的每个数字在组合中只能使用一次。
    /// 
    /// Note: The solution set must not contain duplicate combinations.
    /// 注意：解决方案集不能包含重复的组合。
    /// 
    /// </summary>
    public class CombinationSum2
    {
        /// <summary>
        /// 递归 + 回溯 + 剪枝
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> Solution(int[] candidates, int target)
        {
            Array.Sort(candidates);
            foreach (int num in candidates)
            {
                if (freq.Count == 0 || num != freq[freq.Count - 1].Key)
                {
                    freq.Add(new KeyValuePair<int, int>(num, 1));
                }
                else
                {
                    freq[freq.Count - 1] = new KeyValuePair<int, int>(num, freq[freq.Count - 1].Value + 1);
                }
            }
            Dfs(0, target);
            return ans;
        }

        private List<KeyValuePair<int, int>> freq = new List<KeyValuePair<int, int>>(); // 统计 candidates 中的数值和数值的出现次数
        private List<IList<int>> ans = new List<IList<int>>();
        private List<int> sequence = new List<int>();

        private void Dfs(int pos, int rest)
        {
            if (rest == 0)
            {
                ans.Add(new List<int>(sequence));
                return;
            }
            if (pos == freq.Count || rest < freq[pos].Key)
            {
                return;
            }

            Dfs(pos + 1, rest);

            int most = Math.Min(rest / freq[pos].Key, freq[pos].Value); // 所需数和现存数的最小值
            for (int i = 1; i <= most; ++i)
            {
                sequence.Add(freq[pos].Key);
                Dfs(pos + 1, rest - i * freq[pos].Key);
            }

            // 回溯
            for (int i = 1; i <= most; ++i)
            {
                sequence.RemoveAt(sequence.Count - 1);
            }
        }

        /// <summary>
        /// 递归 + 暴力去重
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> Solution2(int[] candidates, int target)
        {
            Array.Sort(candidates);

            return GetArray(candidates, target, 0);
        }

        private IList<IList<int>> GetArray(int[] candidates, int target, int start)
        {
            var ans = new List<IList<int>>();
            for (var i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                {
                    break;
                }

                if (candidates[i] < target)
                {
                    var sub = GetArray(candidates, target - candidates[i], i + 1);
                    foreach (var item in sub)
                    {
                        item.Insert(0, candidates[i]);
                        ans.Add(item);
                    }
                }

                if (candidates[i] == target)
                {
                    ans.Add(new List<int>() { candidates[i] });

                }
            }

            for (var i = ans.Count - 1; i > 0; i--)
            {
                for (var j = i - 1; j >= 0; j--)
                {
                    if (ans[i].SequenceEqual(ans[j]))
                    {
                        ans.RemoveAt(i);
                        break;
                    }
                }
            }

            return ans;
        }
    }
}
