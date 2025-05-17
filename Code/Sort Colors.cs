namespace Code
{
    /// <summary>
    /// 75. Sort Colors
    /// 75. 颜色分类
    /// 
    /// Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
    /// 给定一个包含红色、白色和蓝色、共 n 个元素的数组 nums ，原地 对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。
    /// 
    /// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
    /// 我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
    /// 
    /// You must solve this problem without using the library's sort function.
    /// 必须在不使用库内置的 sort 函数的情况下解决这个问题。
    /// 
    /// Follow up: Could you come up with a one-pass algorithm using only constant extra space?
    /// 进阶：你能想出一个仅使用常数空间的一趟扫描算法吗？
    /// 
    /// </summary>
    public class Sort_Colors
    {
        public void SortColors(int[] nums)
        {
            int n = nums.Length;
            int red = 0, white = 0;
            foreach (var num in nums)
            {
                if (num == 0) red++;
                if (num == 1) white++;
            }

            for (var i = 0; i < n; i++)
            {
                if (red > i)
                {
                    nums[i] = 0;
                }
                else if (red <= i && white + red > i)
                {
                    nums[i] = 1;
                }
                else
                {
                    nums[i] = 2;
                }
            }
        }
    }
}
