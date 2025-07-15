namespace Code
{
    /// <summary>
    /// 3136. Valid Word
    /// 3136. 有效单词
    /// 
    /// A word is considered valid if:
    /// 有效单词 需要满足以下几个条件：
    /// 
    /// * It contains a minimum of 3 characters.
    /// * 至少 包含 3 个字符。
    /// 
    /// * It contains only digits (0-9), and English letters (uppercase and lowercase).
    /// * 由数字 0-9 和英文大小写字母组成。（不必包含所有这类字符。）
    /// 
    /// * It includes at least one vowel.
    /// * 至少 包含一个 元音字母 。
    /// 
    /// * It includes at least one consonant.
    /// * 至少 包含一个 辅音字母 。
    /// 
    /// You are given a string word.
    /// Return true if word is valid, otherwise, return false.
    /// 给你一个字符串 word 。如果 word 是一个有效单词，则返回 true ，否则返回 false 。
    /// 
    /// Notes:
    /// 注意：
    /// 
    /// * 'a', 'e', 'i', 'o', 'u', and their uppercases are vowels.
    /// * 'a'、'e'、'i'、'o'、'u' 及其大写形式都属于 元音字母 。
    /// 
    /// * A consonant is an English letter that is not a vowel.
    /// * 英文中的 辅音字母 是指那些除元音字母之外的字母。
    /// 
    /// </summary>
    public class Valid_Word
    {
        public bool IsValid(string word)
        {
            if (word.Length < 3)
            {
                return false;
            }
            bool hasVowel = false;
            bool hasConsonant = false;
            foreach (char c in word)
            {
                if (char.IsLetter(c))
                {
                    char ch = char.ToLower(c);
                    if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                    {
                        hasVowel = true;
                    }
                    else
                    {
                        hasConsonant = true;
                    }
                }
                else if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return hasVowel && hasConsonant;
        }
    }
}
