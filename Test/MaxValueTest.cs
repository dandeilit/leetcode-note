using Code;

namespace Test
{
    public class MaxValueTest
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [2,6,7],1,5},
            { [4,2,5,6,7],2,2},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var maxValue = new MaxValue();
            var actual = maxValue.Solution(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
