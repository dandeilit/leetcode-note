namespace Code
{
    /// <summary>
    /// 2234. Maximum Total Beauty of the Gardens
    /// 
    /// Alice is a caretaker of n gardens and she wants to plant flowers to maximize the total beauty of all her gardens.
    /// Alice 是 n 个花园的看护人，她想种植鲜花，以最大限度地提升所有花园的整体美感。
    /// 
    /// You are given a 0-indexed integer array flowers of size n, where flowers[i] is the number of flowers already planted in the ith garden. Flowers that are already planted cannot be removed. You are then given another integer newFlowers, which is the maximum number of flowers that Alice can additionally plant. You are also given the integers target, full, and partial.
    /// 您将获得一个大小为 n 的 0 索引整数数组 flowers，其中 flowers[i] 是第 i 个花园中已种植的鲜花数量。已种植的鲜花不能被移除。然后您将获得另一个整数 newFlowers，这是 Alice 可以额外种植的最大鲜花数量。您还将获得整数 target、full 和 partial。
    /// 
    /// A garden is considered complete if it has at least target flowers. The total beauty of the gardens is then determined as the sum of the following:
    /// 如果花园至少有 target 朵鲜花，则该花园被认为是完整的。然后，花园的整体美感由以下各项之和确定：
    /// 
    /// * The number of complete gardens multiplied by full.
    /// * 完整花园的数量乘以完整花园的数量。
    /// 
    /// * The minimum number of flowers in any of the incomplete gardens multiplied by partial. If there are no incomplete gardens, then this value will be 0.
    /// * 任何不完整花园中的最小鲜花数量乘以部分花园的数量。如果没有未完成的花园，则该值将为 0。
    /// 
    /// Return the maximum total beauty that Alice can obtain after planting at most newFlowers flowers.
    /// 返回 Alice 种植最多 newFlowers 朵花后可以获得的最大总美丽值。
    /// 
    /// </summary>
    public class Maximum_Total_Beauty_of_the_Gardens
    {
        /// <summary>
        /// 枚举「完善」和「不完善」的分界线
        /// </summary>
        /// <param name="flowers"></param>
        /// <param name="newFlowers"></param>
        /// <param name="target"></param>
        /// <param name="full"></param>
        /// <param name="partial"></param>
        /// <returns></returns>
        public long MaximumBeauty(int[] flowers, long newFlowers, int target, int full, int partial)
        {
            int n = flowers.Length;
            for (int i = 0; i < n; i++)
            {
                flowers[i] = Math.Min(flowers[i], target);
            }
            Array.Sort(flowers, (a, b) => b.CompareTo(a));
            long sum = flowers.Sum(x => (long)x);
            long ans = 0;
            if ((long)target * n - sum <= newFlowers)
            {
                ans = (long)full * n;
            }
            long pre = 0;
            int ptr = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != 0)
                {
                    pre += flowers[i - 1];
                }
                if (flowers[i] == target)
                {
                    continue;
                }
                long rest = newFlowers - ((long)target * i - pre);
                if (rest < 0)
                {
                    break;
                }
                while (!(ptr >= i && (long)flowers[ptr] * (n - ptr) - sum <= rest))
                {
                    sum -= flowers[ptr];
                    ptr++;
                }
                rest -= (long)flowers[ptr] * (n - ptr) - sum;
                ans = Math.Max(ans, (long)full * i + (long)partial * Math.Min(flowers[ptr] + rest / (n - ptr), (long)target - 1));
            }

            return ans;
        }
    }
}
