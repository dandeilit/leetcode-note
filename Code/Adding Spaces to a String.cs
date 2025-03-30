namespace Code
{
    /// <summary>
    /// 2109. Adding Spaces to a String
    /// 2109. 向字符串添加空格
    /// 
    /// You are given a 0-indexed string s and a 0-indexed integer array spaces that describes the indices in the original string where spaces will be added. Each space should be inserted before the character at the given index.
    /// 给你一个下标从 0 开始的字符串 s ，以及一个下标从 0 开始的整数数组 spaces 。
    /// 数组 spaces 描述原字符串中需要添加空格的下标。每个空格都应该插入到给定索引处的字符值 之前 。
    /// 
    /// * For example, given s = "EnjoyYourCoffee" and spaces = [5, 9], we place spaces before 'Y' and 'C', which are at indices 5 and 9 respectively. Thus, we obtain "Enjoy Your Coffee".
    /// * 例如，s = "EnjoyYourCoffee" 且 spaces = [5, 9] ，那么我们需要在 'Y' 和 'C' 之前添加空格，这两个字符分别位于下标 5 和下标 9 。因此，最终得到 "Enjoy Your Coffee" 。
    /// 
    /// Return the modified string after the spaces have been added.
    /// 请你添加空格，并返回修改后的字符串。
    /// 
    /// </summary>
    public class Adding_Spaces_to_a_String
    {
        public string AddSpaces(string s, int[] spaces)
        {
            int n = s.Length + spaces.Length;
            char[] res = new char[n];
            int x = 0, y = 0;
            for (var i = 0; i < n; i++)
            {
                if (y < spaces.Length && spaces[y] + y == i)
                {
                    res[i] = ' ';
                    y++;
                }
                else
                {
                    res[i] = s[x];
                    x++;
                }
            }
            return new string(res);
        }
    }
}
