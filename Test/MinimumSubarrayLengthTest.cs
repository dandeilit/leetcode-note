using Code;

namespace Test
{
    public class MinimumSubarrayLengthTest
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
            var minimumSubarrayLength = new MinimumSubarrayLength();
            var actual = minimumSubarrayLength.Solution(nums, k);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, int k, int expected)
        {
            var minimumSubarrayLength = new MinimumSubarrayLength();
            var actual = minimumSubarrayLength.Solution2(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
