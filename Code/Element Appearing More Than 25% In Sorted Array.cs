namespace Code
{
    /// <summary>
    /// 1287. Element Appearing More Than 25% In Sorted Array
    /// 
    /// Given an integer array sorted in non-decreasing order, there is exactly one integer in the array that occurs more than 25% of the time, return that integer.
    /// 给定一个按非减序排序的整数数组，数组中恰好有一个整数出现的次数超过 25%，返回该整数。
    /// 
    /// </summary>
    public class Element_Appearing_More_Than_25__In_Sorted_Array
    {
        public int FindSpecialInteger(int[] arr)
        {
            int ans = arr[0];
            int n = arr.Length;
            int special = n >> 2;
            IDictionary<int, int> map = new Dictionary<int, int>();
            foreach (int i in arr)
            {
                if (map.ContainsKey(i))
                {
                    map[i]++;
                    if (map[i] > special)
                    {
                        ans = i;
                    }
                }
                else
                {
                    map[i] = 1;
                }
            }
            return ans;
        }
    }
}
