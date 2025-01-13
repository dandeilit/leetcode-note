using Code;

namespace Test
{
    public class WaysToSplitArrayTest
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [10,4,-8,7], 2 },
            { [2,3,1,0], 2 },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var waysToSplitArray = new WaysToSplitArray();
            var actual = waysToSplitArray.Solution(nums);

            Assert.Equal(expected, actual);
        }
    }
}
