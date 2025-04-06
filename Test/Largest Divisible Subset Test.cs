using Code;

namespace Test
{
    public class Largest_Divisible_Subset_Test
    {
        public static TheoryData<int[], int[]> TestData => new TheoryData<int[], int[]>()
        {
            { [1,2,3],[1,2]},
            { [1,2,4,8],[1,2,4,8]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int[] expected)
        {
            var largest_Divisible_Subset = new Largest_Divisible_Subset();
            var actual = largest_Divisible_Subset.LargestDivisibleSubset(nums);
            Assert.Equal(expected, actual.Order());
        }
    }
}
