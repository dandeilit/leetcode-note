namespace Code
{
    /// <summary>
    /// 3298. Count Substrings That Can Be Rearranged to Contain a String II
    /// 
    /// You are given two strings word1 and word2.
    /// 给定两个字符串 word1 和 word2。
    /// 
    /// A string x is called valid if x can be rearranged to have word2 as a prefix.
    /// 如果字符串 x 可以重新排列为以 word2 作为前缀，则称其为有效字符串。
    /// 
    /// Return the total number of valid substrings of word1.
    /// 返回 word1 的有效子字符串总数。
    /// 
    /// Note that the memory limits in this problem are smaller than usual, so you must implement a solution with a linear runtime complexity.
    /// 请注意，此问题的内存限制比平常要小，因此您必须实现具有线性运行时复杂度的解决方案。
    /// 
    /// </summary>
    public class ValidSubstringCountII
    {

        /// <summary>
        /// 滑动窗口
        /// 具体注释可见 ValidSubstringCount.cs
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public long Solution(string word1, string word2)
        {
            int[] diff = new int[26];
            int l = 0, r = 0;

            foreach (var word in word2)
            {
                diff[word - 'a']++;
            }

            long res = 0;
            int cnt = diff.Count(x => x > 0);

            while (l < word1.Length)
            {
                while (r < word1.Length && cnt > 0)
                {
                    diff[word1[r] - 'a']--;
                    if (diff[word1[r] - 'a'] == 0)
                    {
                        cnt--;
                    }
                    r++;
                }

                if (cnt == 0)
                {
                    res += word1.Length - r + 1;
                }

                diff[word1[l] - 'a']++;
                if (diff[word1[l] - 'a'] == 1)
                {
                    cnt++;
                }
                l++;
            }
            return res;
        }
    }
}
