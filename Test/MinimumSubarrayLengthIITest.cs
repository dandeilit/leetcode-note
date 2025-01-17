using Code;

namespace Test
{
    public class MinimumSubarrayLengthIITest
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [1,2,3], 2, 1},
            { [2,1,8], 10, 3},
            { [1,2], 0, 1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var minimumSubarrayLengthII = new MinimumSubarrayLengthII();
            var actual = minimumSubarrayLengthII.Solution(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
