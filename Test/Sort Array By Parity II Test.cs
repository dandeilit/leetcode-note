using Code;

namespace Test
{
    public class Sort_Array_By_Parity_II_Test
    {
        public static TheoryData<int[], int[][]> TestData => new TheoryData<int[], int[][]>()
        {
            { [4,2,5,7],[[4,5,2,7],[4,7,2,5], [2,5,4,7], [2,7,4,5]]},
            { [2,3],[[2,3]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int[][] expected)
        {
            var sort_Array_By_Parity_II = new Sort_Array_By_Parity_II();
            var actual = sort_Array_By_Parity_II.SortArrayByParityII(nums);

            Assert.Contains(actual, expected);
        }
    }
}
