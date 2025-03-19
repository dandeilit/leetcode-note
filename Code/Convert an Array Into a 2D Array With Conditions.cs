namespace Code
{
    /// <summary>
    /// 2610. Convert an Array Into a 2D Array With Conditions
    /// 2610. 转换二维数组
    /// 
    /// You are given an integer array nums. You need to create a 2D array from nums satisfying the following conditions:
    /// 给你一个整数数组 nums 。请你创建一个满足以下条件的二维数组：
    /// 
    /// * The 2D array should contain only the elements of the array nums.
    /// * 二维数组应该 只 包含数组 nums 中的元素。
    /// 
    /// * Each row in the 2D array contains distinct integers.
    /// * 二维数组中的每一行都包含 不同 的整数。
    /// 
    /// * The number of rows in the 2D array should be minimal.
    /// * 二维数组的行数应尽可能 少 。
    /// 
    /// Return the resulting array. If there are multiple answers, return any of them.
    /// 返回结果数组。如果存在多种答案，则返回其中任何一种。
    /// 
    /// Note that the 2D array can have a different number of elements on each row.
    /// 请注意，二维数组的每一行上可以存在不同数量的元素。
    /// 
    /// </summary>
    public class Convert_an_Array_Into_a_2D_Array_With_Conditions
    {
        public IList<IList<int>> FindMatrix(int[] nums)
        {
            var ans = new List<IList<int>>();
            var dic = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                {
                    dic[num]++;
                }
                else
                {
                    dic.Add(num, 1);
                }

                if (ans.Count >= dic[num])
                {
                    ans[dic[num] - 1].Add(num);
                }
                else
                {
                    ans.Add(new List<int> { num });
                }
            }
            return ans;
        }
    }
}
