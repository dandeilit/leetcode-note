namespace Code
{
    /// <summary>
    /// 1552. Magnetic Force Between Two Balls
    /// 
    /// In the universe Earth C-137, Rick discovered a special form of magnetic force between two balls if they are put in his new invented basket. Rick has n empty baskets, the i-th basket is at position[i], Morty has m balls and needs to distribute the balls into the baskets such that the minimum magnetic force between any two balls is maximum.
    /// 在 C-137 地球宇宙中，Rick 发现如果将两个球放入他新发明的篮子中，它们之间就会产生一种特殊形式的磁力。Rick 有 n 个空篮子，第 i 个篮子位于位置 [i]，Morty 有 m 个球，需要将球分配到篮子中，使得任意两个球之间的最小磁力最大。
    /// 
    /// Rick stated that magnetic force between two different balls at positions x and y is |x - y|.
    /// Rick 表示，位置 x 和 y 处的两个不同球之间的磁力为 |x - y|。
    /// 
    /// Given the integer array position and the integer m. Return the required force.
    /// 给定整数数组位置和整数 m。返回所需的力。
    /// 
    /// </summary>
    public class Magnetic_Force_Between_Two_Balls
    {
        /// <summary>
        /// 二分查找
        /// 提出答案，计算验证
        /// </summary>
        /// <param name="position"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int MaxDistance(int[] position, int m)
        {
            Array.Sort(position);
            int left = 1, right = position[position.Length - 1] - position[0], ans = -1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (Check(mid, position, m))
                {
                    ans = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return ans;
        }

        /// <summary>
        /// 验证当磁力为 x 时，合法间距分隔是否满足 m
        /// </summary>
        /// <param name="x"></param>
        /// <param name="position"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private bool Check(int x, int[] position, int m)
        {
            int pre = position[0], cnt = 1;
            for (int i = 1; i < position.Length; i++)
            {
                if (position[i] - pre >= x)
                {
                    pre = position[i];
                    cnt++;
                }
            }
            return cnt >= m;
        }
    }
}
