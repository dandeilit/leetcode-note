namespace Code
{
    /// <summary>
    /// 838. Push Dominoes
    /// 838. 推多米诺
    /// 
    /// There are n dominoes in a line, and we place each domino vertically upright. In the beginning, we simultaneously push some of the dominoes either to the left or to the right.
    /// n 张多米诺骨牌排成一行，将每张多米诺骨牌垂直竖立。在开始时，同时把一些多米诺骨牌向左或向右推。
    /// 
    /// After each second, each domino that is falling to the left pushes the adjacent domino on the left. Similarly, the dominoes falling to the right push their adjacent dominoes standing on the right.
    /// 每过一秒，倒向左边的多米诺骨牌会推动其左侧相邻的多米诺骨牌。同样地，倒向右边的多米诺骨牌也会推动竖立在其右侧的相邻多米诺骨牌。
    /// 
    /// When a vertical domino has dominoes falling on it from both sides, it stays still due to the balance of the forces.
    /// 如果一张垂直竖立的多米诺骨牌的两侧同时有多米诺骨牌倒下时，由于受力平衡， 该骨牌仍然保持不变。
    /// 
    /// For the purposes of this question, we will consider that a falling domino expends no additional force to a falling or already fallen domino.
    /// 就这个问题而言，我们会认为一张正在倒下的多米诺骨牌不会对其它正在倒下或已经倒下的多米诺骨牌施加额外的力。
    /// 
    /// You are given a string dominoes representing the initial state where:
    /// 给你一个字符串 dominoes 表示这一行多米诺骨牌的初始状态，其中：
    /// 
    /// * dominoes[i] = 'L', if the i-th domino has been pushed to the left,
    /// * dominoes[i] = 'L'，表示第 i 张多米诺骨牌被推向左侧，
    /// 
    /// * dominoes[i] = 'R', if the i-th domino has been pushed to the right, and
    /// * dominoes[i] = 'R'，表示第 i 张多米诺骨牌被推向右侧，
    /// 
    /// * dominoes[i] = '.', if the i-th domino has not been pushed.
    /// * dominoes[i] = '.'，表示没有推动第 i 张多米诺骨牌。
    /// 
    /// Return a string representing the final state.
    /// 返回表示最终状态的字符串。
    /// 
    /// </summary>
    public class Push_Dominoes
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="dominoes"></param>
        /// <returns></returns>
        public string PushDominoes(string dominoes)
        {
            char[] s = dominoes.ToCharArray();
            int n = s.Length, i = 0;
            char left = 'L';
            while (i < n)
            {
                int j = i;
                while (j < n && s[j] == '.')
                { // 找到一段连续的没有被推动的骨牌
                    j++;
                }
                char right = j < n ? s[j] : 'R';
                if (left == right)
                { // 方向相同，那么这些竖立骨牌也会倒向同一方向
                    while (i < j)
                    {
                        s[i++] = right;
                    }
                }
                else if (left == 'R' && right == 'L')
                { // 方向相对，那么就从两侧向中间倒
                    int k = j - 1;
                    while (i < k)
                    {
                        s[i++] = 'R';
                        s[k--] = 'L';
                    }
                }
                left = right;
                i = j + 1;
            }
            return new string(s);
        }
    }
}
