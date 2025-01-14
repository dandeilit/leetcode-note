using Code;

namespace Test
{
    public class MinOperationsTest
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [2,11,10,1,3], 10, 3 },
            { [1,1,2,4,9], 1, 0},
            { [1,1,2,4,9], 9, 4},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var minOperations = new MinOperations();
            var actual = minOperations.Solution(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
