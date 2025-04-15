namespace Code
{
    /// <summary>
    /// 2179. Count Good Triplets in an Array
    /// 2179. 统计数组中好三元组数目
    /// 
    /// You are given two 0-indexed arrays nums1 and nums2 of length n, both of which are permutations of [0, 1, ..., n - 1].
    /// 给你两个下标从 0 开始且长度为 n 的整数数组 nums1 和 nums2 ，两者都是 [0, 1, ..., n - 1] 的 排列 。
    /// 
    /// A good triplet is a set of 3 distinct values which are present in increasing order by position both in nums1 and nums2. In other words, if we consider pos1v as the index of the value v in nums1 and pos2v as the index of the value v in nums2, then a good triplet will be a set (x, y, z) where 0 <= x, y, z <= n - 1, such that pos1x < pos1y < pos1z and pos2x < pos2y < pos2z.
    /// 好三元组 指的是 3 个 互不相同 的值，且它们在数组 nums1 和 nums2 中出现顺序保持一致。换句话说，如果我们将 pos1v 记为值 v 在 nums1 中出现的位置，pos2v 为值 v 在 nums2 中的位置，那么一个好三元组定义为 0 <= x, y, z <= n - 1 ，且 pos1x < pos1y < pos1z 和 pos2x < pos2y < pos2z 都成立的 (x, y, z) 。
    /// 
    /// Return the total number of good triplets.
    /// 请你返回好三元组的 总数目 。
    /// 
    /// </summary>
    public class Count_Good_Triplets_in_an_Array
    {
        public class FenwickTree
        {
            private int[] tree;

            public FenwickTree(int size)
            {
                tree = new int[size + 1];
            }

            public void Update(int index, int delta)
            {
                index++;
                while (index < tree.Length)
                {
                    tree[index] += delta;
                    index += index & -index;
                }
            }

            public int Query(int index)
            {
                index++;
                int res = 0;
                while (index > 0)
                {
                    res += tree[index];
                    index -= index & -index;
                }
                return res;
            }
        }

        /// <summary>
        /// 树状数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public long GoodTriplets(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int[] pos2 = new int[n], reversedIndexMapping = new int[n];
            for (int i = 0; i < n; i++)
            {
                pos2[nums2[i]] = i;
            }
            for (int i = 0; i < n; i++)
            {
                reversedIndexMapping[pos2[nums1[i]]] = i;
            }
            FenwickTree tree = new FenwickTree(n);
            long res = 0;
            for (int value = 0; value < n; value++)
            {
                int pos = reversedIndexMapping[value];
                int left = tree.Query(pos);
                tree.Update(pos, 1);
                int right = (n - 1 - pos) - (value - left);
                res += (long)left * right;
            }
            return res;
        }
    }
}
