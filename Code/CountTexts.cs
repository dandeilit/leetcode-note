namespace Code
{
    /// <summary>
    /// 2266. Count Number of Texts
    /// 
    /// Alice is texting Bob using her phone. The mapping of digits to letters is shown in the figure below.
    /// Alice 正在用手机给 Bob 发短信。下图显示了数字到字母的映射。
    /// 
    /// | 1       | 2(abc) | 3(def)  |
    /// | 4(ghi)  | 5(jkl) | 6(mno)  |
    /// | 7(pqrs) | 8(tuv) | 9(wxyz) |
    /// | *       | 0      | #       |
    /// 
    /// In order to add a letter, Alice has to press the key of the corresponding digit i times, where i is the position of the letter in the key.
    /// 为了添加字母，Alice 必须按相应数字的键 i 次，其中 i 是字母在键中的位置。
    /// 
    /// * For example, to add the letter 's', Alice has to press '7' four times. Similarly, to add the letter 'k', Alice has to press '5' twice.
    /// * 例如，要添加字母“s”，Alice 必须按“7”四次。同样，要添加字母“k”，Alice 必须按“5”两次。
    /// 
    /// * Note that the digits '0' and '1' do not map to any letters, so Alice does not use them.
    /// * 请注意，数字“0”和“1”不映射到任何字母，因此 Alice 不使用它们。
    /// 
    /// However, due to an error in transmission, Bob did not receive Alice's text message but received a string of pressed keys instead.
    /// 但是，由于传输错误，Bob 没有收到 Alice 的短信，而是收到了一串按下的键。
    /// 
    /// * For example, when Alice sent the message "bob", Bob received the string "2266622".
    /// * 例如，当 Alice 发送消息“bob”时，Bob 收到了字符串“2266622”。
    /// 
    /// Given a string pressedKeys representing the string received by Bob, return the total number of possible text messages Alice could have sent.
    /// 给定一个表示 Bob 收到的字符串按下的键，返回 Alice 可能发送的短信总数。
    /// 
    /// Since the answer may be very large, return it modulo 1000000007.
    /// 由于答案可能非常大，因此返回它对 1000000007 取模的结果。
    /// 
    /// </summary>
    public class CountTexts
    {
        /// <summary>
        /// 动态规划
        /// 后一位方案数为前几位方案数相加
        /// </summary>
        /// <param name="pressedKeys"></param>
        /// <returns></returns>
        public int Solution(string pressedKeys)
        {
            int m = 1000000007;
            int n = pressedKeys.Length;
            List<long> dp3 = new List<long> { 1, 1, 2, 4 };   // 连续按多次 3 个字母按键对应的方案数
            List<long> dp4 = new List<long> { 1, 1, 2, 4 };   // 连续按多次 4 个字母按键对应的方案数
            for (int i = 4; i <= n; ++i)
            {
                dp3.Add((dp3[i - 1] + dp3[i - 2] + dp3[i - 3]) % m);
                dp4.Add((dp4[i - 1] + dp4[i - 2] + dp4[i - 3] + dp4[i - 4]) % m);
            }

            long res = 1;   // 总方案数
            int cnt = 1;   // 当前字符连续出现的次数
            for (int i = 1; i < n; ++i)
            {
                if (pressedKeys[i] == pressedKeys[i - 1])
                {
                    ++cnt;
                }
                else
                {
                    // 对按键对应字符数量讨论并更新总方案数
                    if (pressedKeys[i - 1] == '7' || pressedKeys[i - 1] == '9')
                    {
                        res = (res * dp4[cnt]) % m;
                    }
                    else
                    {
                        res = (res * dp3[cnt]) % m;
                    }
                    cnt = 1;
                }
            }

            // 更新最后一段连续字符子串对应的方案数
            if (pressedKeys[n - 1] == '7' || pressedKeys[n - 1] == '9')
            {
                res = (res * dp4[cnt]) % m;
            }
            else
            {
                res = (res * dp3[cnt]) % m;
            }
            return (int)res;
        }
    }
}
