using Code;

namespace Test
{
    public class Sum_of_All_Subset_XOR_Totals_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [1,3],6},
            { [5,1,6],28},
            { [3,4,5,6,7,8],480},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var sum_of_All_Subset_XOR_Totals = new Sum_of_All_Subset_XOR_Totals();
            var actual = sum_of_All_Subset_XOR_Totals.SubsetXORSum(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int expected)
        {
            var sum_of_All_Subset_XOR_Totals = new Sum_of_All_Subset_XOR_Totals();
            var actual = sum_of_All_Subset_XOR_Totals.SubsetXORSum2(nums);
            Assert.Equal(expected, actual);
        }
    }
}
