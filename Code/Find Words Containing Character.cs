namespace Code
{
    /// <summary>
    /// 2942. Find Words Containing Character
    /// 2942. 查找包含给定字符的单词
    /// 
    /// You are given a 0-indexed array of strings words and a character x.
    /// 给你一个下标从 0 开始的字符串数组 words 和一个字符 x 。
    /// 
    /// Return an array of indices representing the words that contain the character x.
    /// 请你返回一个 下标数组 ，表示下标在数组中对应的单词包含字符 x 。
    /// 
    /// Note that the returned array may be in any order.
    /// 注意 ，返回的数组可以是 任意 顺序。
    /// 
    /// </summary>
    public class Find_Words_Containing_Character
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="words"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public IList<int> FindWordsContaining(string[] words, char x)
        {
            var ans = new List<int>();
            for (var i = 0; i < words.Length; i++)
            {
                foreach (var c in words[i])
                {
                    if (c == x)
                    {
                        ans.Add(i);
                        break;
                    }
                }
            }
            return ans;
        }
    }
}
