namespace Code
{
    /// <summary>
    /// 1007. Minimum Domino Rotations For Equal Row
    /// 1007. 行相等的最少多米诺旋转
    /// 
    /// In a row of dominoes, tops[i] and bottoms[i] represent the top and bottom halves of the i-th domino. (A domino is a tile with two numbers from 1 to 6 - one on each half of the tile.)
    /// 在一排多米诺骨牌中，tops[i] 和 bottoms[i] 分别代表第 i 个多米诺骨牌的上半部分和下半部分。（一个多米诺是两个从 1 到 6 的数字同列平铺形成的 —— 该平铺的每一半上都有一个数字。）
    /// 
    /// We may rotate the i-th domino, so that tops[i] and bottoms[i] swap values.
    /// 我们可以旋转第 i 张多米诺，使得 tops[i] 和 bottoms[i] 的值交换。
    /// 
    /// Return the minimum number of rotations so that all the values in tops are the same, or all the values in bottoms are the same.
    /// 返回能使 tops 中所有值或者 bottoms 中所有值都相同的最小旋转次数。
    /// 
    /// If it cannot be done, return -1.
    /// 如果无法做到，返回 -1.
    /// 
    /// </summary>
    public class Minimum_Domino_Rotations_For_Equal_Row
    {
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            int n = tops.Length;
            int key = 0;
            int[] map = new int[6];
            for (var i = 0; i < n; i++)
            {
                if (tops[i] - 1 == bottoms[i] - 1)
                {
                    map[tops[i] - 1]++;
                }
                else
                {
                    map[tops[i] - 1]++;
                    map[bottoms[i] - 1]++;
                }

                if (map[tops[i] - 1] == n)
                {
                    key = tops[i];
                }

                if (map[bottoms[i] - 1] == n)
                {
                    key = bottoms[i];
                }
            }

            if (key == 0) return -1;

            int top = 0, bottom = 0;
            for (var i = 0; i < n; i++)
            {
                if (tops[i] == key) top++;
                if (bottoms[i] == key) bottom++;
            }

            return n - Math.Max(top, bottom);
        }
    }
}
