using Code;

namespace Test
{
    public class MinOperationsIITest
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [2,11,10,1,3], 10, 2 },
            { [1,1,2,4,9], 20, 4},
            { [999999999,999999999,999999999], 1000000000, 2}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int k, int expected)
        {
            var minOperationsII = new MinOperationsII();
            var actual = minOperationsII.Solution(nums, k);

            Assert.Equal(expected, actual);
        }
    }
}
