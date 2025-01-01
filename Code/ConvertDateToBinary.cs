namespace Code
{
    /// <summary>
    /// 3280. Convert Date to Binary
    /// 
    /// You are given a string date representing a Gregorian calendar date in the yyyy-mm-dd format.
    /// 您将获得一个字符串date ，表示yyyy-mm-dd格式的公历日期。
    /// 
    /// date can be written in its binary representation obtained by converting year, month, and day to their binary representations without any leading zeroes and writing them down in year-month-day format.
    /// date可以用其二进制表示形式来编写，该二进制表示形式是通过将年、月和日转换为不带任何前导零的二进制表示形式并以year-month-day格式写下来而获得的。
    /// 
    /// Return the binary representation of date.
    /// 返回 date 的二进制表示形式。
    /// 
    /// </summary>
    public class ConvertDateToBinary
    {
        public string Solution(string date)
        {
            string[] ymd = date.Split('-');
            for (int i = 0; i < ymd.Length; i++)
            {
                ymd[i] = Convert.ToString(int.Parse(ymd[i]), 2);
            }
            string result = string.Join("-", ymd);
            return result;
        }

        /// <summary>
        /// 利用位运算转换
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string Solution2(string date)
        {
            int YY = 0, MM = 0, DD = 0;
            YY = (date[0] & 15) * 1000 + (date[1] & 15) * 100 + (date[2] & 15) * 10 + (date[3] & 15);
            MM = (date[5] & 15) * 10 + (date[6] & 15);
            DD = (date[8] & 15) * 10 + (date[9] & 15);

            return $"{Dec2Bin(YY)}-{Dec2Bin(MM)}-{Dec2Bin(DD)}";

            string Dec2Bin(int x)
            {
                List<char> chars = new List<char>();
                while (x > 0)
                {
                    chars.Add((char)((x & 1) | 48));
                    x >>= 1;
                }

                chars.Reverse();
                return new string(chars.ToArray());
            }
        }
    }
}
