namespace Code
{
    /// <summary>
    /// 2595. Number of Even and Odd Bits
    /// 
    /// You are given a positive integer n.
    /// 给定一个正整数 n。
    /// 
    /// Let even denote the number of even indices in the binary representation of n with value 1.
    /// even 为 n 的二进制表示形式中值为 1 的偶数索引的数量。
    /// 
    /// Let odd denote the number of odd indices in the binary representation of n with value 1.
    /// odd 为 n 的二进制表示形式中值为 1 的奇数索引的数量。
    /// 
    /// Note that bits are indexed from right to left in the binary representation of a number.
    /// 注意，在数字的二进制表示形式中，位是从右到左索引的。
    /// 
    /// Return the array [even, odd].
    /// 返回数组 [even, odd]。
    /// 
    /// </summary>
    public class Number_of_Even_and_Odd_Bits
    {
        public int[] EvenOddBit(int n)
        {
            int[] res = new int[2];
            int index = 0;

            while (n > 0)
            {
                res[index] += n & 1;
                n >>= 1;
                index ^= 1;
            }

            return res;
        }
    }
}
