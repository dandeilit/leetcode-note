namespace Code
{
    /// <summary>
    /// 2274. Maximum Consecutive Floors Without Special Floors
    /// 
    /// Alice manages a company and has rented some floors of a building as office space. Alice has decided some of these floors should be special floors, used for relaxation only.
    /// 爱丽丝管理着一家公司，并租用了一栋大楼的一些楼层作为办公空间。爱丽丝决定其中一些楼层应该是特殊楼层，仅用于放松。
    /// 
    /// You are given two integers bottom and top, which denote that Alice has rented all the floors from bottom to top (inclusive). You are also given the integer array special, where special[i] denotes a special floor that Alice has designated for relaxation.
    /// 给定两个整数bottom和top ，这表示Alice已经租用了从bottom到top （含）的所有楼层。您还会获得整数数组special ，其中special[i]表示Alice指定用于放松的特殊楼层。
    /// 
    /// Return the maximum number of consecutive floors without a special floor.
    /// 返回没有特殊楼层的最大连续楼层数。
    /// 
    /// </summary>
    public class MaxConsecutive
    {

        /// <summary>
        /// 空间复杂度过高
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="special"></param>
        /// <returns></returns>
        public int Solution(int bottom, int top, int[] special)
        {
            int[] floors = new int[top - bottom + 1];

            foreach (var s in special)
            {
                floors[s - bottom] = -1;
            }

            int max = 0;
            int k = 0;
            foreach (var floor in floors)
            {
                if (floor != -1)
                {
                    k++;
                    if (k > max)
                    {
                        max = k;
                    }
                }
                else
                {
                    k = 0;
                }
            }
            return max;
        }

        /// <summary>
        /// 时间复杂度过高
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="special"></param>
        /// <returns></returns>
        public int Solution2(int bottom, int top, int[] special)
        {
            int max = 0;
            int k = 0;
            for (int i = bottom; i <= top; i++)
            {
                if (special.Contains(i))
                {
                    k = 0;
                }
                else
                {
                    k++;
                    if (k > max)
                    {
                        max = k;
                    }
                }
            }
            return max;
        }

        /// <summary>
        /// 排序后计算间断长度
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="top"></param>
        /// <param name="special"></param>
        /// <returns></returns>
        public int Solution3(int bottom, int top, int[] special)
        {
            int ans = 0;
            Array.Sort(special);

            // 先将头尾间断长度判定比较
            ans = Math.Max(special[0] - bottom, top - special[special.Length - 1]);

            for (int i = 0; i < special.Length - 1; i++)
            {
                if (special[i + 1] - special[i] - 1 > ans)
                {
                    ans = special[i + 1] - special[i] - 1;
                }
            }
            return ans;
        }
    }
}
