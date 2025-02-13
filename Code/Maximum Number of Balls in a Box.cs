namespace Code
{
    /// <summary>
    /// 1742. Maximum Number of Balls in a Box
    /// 
    /// You are working in a ball factory where you have n balls numbered from lowLimit up to highLimit inclusive (i.e., n == highLimit - lowLimit + 1), and an infinite number of boxes numbered from 1 to infinity.
    /// 您正在一家球厂工作，工厂中有 n 个球，编号从低限到高限（包括低限和高限）（即 n == 高限 - 低限 + 1），以及无数个盒子，编号从 1 到无穷大。
    /// 
    /// Your job at this factory is to put each ball in the box with a number equal to the sum of digits of the ball's number. For example, the ball number 321 will be put in the box number 3 + 2 + 1 = 6 and the ball number 10 will be put in the box number 1 + 0 = 1.
    /// 您在工厂的工作是将每个球放入盒子中，盒子的编号等于球编号的位数之和。例如，球号 321 将被放入盒子编号 3 + 2 + 1 = 6，球号 10 将被放入盒子编号 1 + 0 = 1。
    /// 
    /// Given two integers lowLimit and highLimit, return the number of balls in the box with the most balls.
    /// 给定两个整数低限和高限，返回球最多的盒子中的球数。
    /// 
    /// </summary>
    public class Maximum_Number_of_Balls_in_a_Box
    {
        /// <summary>
        /// 哈希表统计
        /// </summary>
        /// <param name="lowLimit"></param>
        /// <param name="highLimit"></param>
        /// <returns></returns>
        public int CountBalls(int lowLimit, int highLimit)
        {
            IDictionary<int, int> count = new Dictionary<int, int>();
            int res = 0;
            for (int i = lowLimit; i <= highLimit; i++)
            {
                int box = 0, x = i;
                while (x != 0)
                {
                    box += x % 10;
                    x /= 10;
                }
                count.TryAdd(box, 0);
                count[box]++;
                res = Math.Max(res, count[box]);
            }
            return res;
        }
    }
}
