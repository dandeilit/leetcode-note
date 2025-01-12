using Code;

namespace Test
{
    public class LargestCombinationTest
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            {[16,17,71,62,12,24,14],4 },
            {[8,8],2 },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] candidates, int expected)
        {
            var largestCombination = new LargestCombination();
            var actual = largestCombination.Solution(candidates);

            Assert.Equal(expected, actual);
        }
    }
}
