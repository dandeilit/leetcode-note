using Code;

namespace Test
{
    public class Remove_Duplicates_from_Sorted_Array_II_Test
    {
        public static TheoryData<int[], int[]> TestData => new TheoryData<int[], int[]>()
        {
            { [1,1,1,2,2,3],[1,1,2,2,3]},
            { [0,0,1,1,1,1,2,3,3],[0,0,1,1,2,3,3]},
            { [1,1,1,1],[1,1]}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int[] expected)
        {
            var remove_Duplicates_from_Sorted_Array_II = new Remove_Duplicates_from_Sorted_Array_II();
            var actual = remove_Duplicates_from_Sorted_Array_II.RemoveDuplicates(nums);

            Assert.Equal(expected.Length, actual);
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], nums[i]);
            }
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int[] expected)
        {
            var remove_Duplicates_from_Sorted_Array_II = new Remove_Duplicates_from_Sorted_Array_II();
            var actual = remove_Duplicates_from_Sorted_Array_II.RemoveDuplicates2(nums);

            Assert.Equal(expected.Length, actual);
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], nums[i]);
            }
        }
    }
}
