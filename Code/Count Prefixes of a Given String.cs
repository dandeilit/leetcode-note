namespace Code
{
    /// <summary>
    /// 2255. Count Prefixes of a Given String
    /// 2255. 统计是给定字符串前缀的字符串数目
    /// 
    /// You are given a string array words and a string s, where words[i] and s comprise only of lowercase English letters.
    /// 给你一个字符串数组 words 和一个字符串 s ，其中 words[i] 和 s 只包含 小写英文字母 。
    /// 
    /// Return the number of strings in words that are a prefix of s.
    /// 请你返回 words 中是字符串 s 前缀 的 字符串数目 。
    /// 
    /// A prefix of a string is a substring that occurs at the beginning of the string. A substring is a contiguous sequence of characters within a string.
    /// 一个字符串的 前缀 是出现在字符串开头的子字符串。子字符串 是一个字符串中的连续一段字符序列。
    /// 
    /// </summary>
    public class Count_Prefixes_of_a_Given_String
    {
        public int CountPrefixes(string[] words, string s)
        {
            int num = 0;
            foreach (var word in words)
            {
                if (word.Length <= s.Length)
                    num += word.Equals(s.Substring(0, word.Length)) ? 1 : 0;
            }
            return num;
        }

        public int CountPrefixes2(string[] words, string s)
        {
            HashSet<string> prefixes = new HashSet<string>();
            for (var i = 1; i <= s.Length; i++)
            {
                prefixes.Add(s.Substring(0, i));
            }

            int num = 0;
            foreach (var word in words)
            {
                if (prefixes.Contains(word)) num++;
            }
            return num;
        }
    }
}
