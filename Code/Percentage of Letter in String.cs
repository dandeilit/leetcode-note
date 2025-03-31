namespace Code
{
    /// <summary>
    /// 2278. Percentage of Letter in String
    /// 2278. 字母在字符串中的百分比
    /// 
    /// Given a string s and a character letter, return the percentage of characters in s that equal letter rounded down to the nearest whole percent.
    /// 给你一个字符串 s 和一个字符 letter ，返回在 s 中等于 letter 字符所占的 百分比 ，向下取整到最接近的百分比。
    /// 
    /// </summary>
    public class Percentage_of_Letter_in_String
    {
        public int PercentageLetter(string s, char letter)
        {
            int num = 0;
            foreach (var c in s)
            {
                if (c == letter) num++;
            }
            return num * 100 / s.Length;
        }
    }
}
