using Code;

namespace Test
{
    public class MaxCoinsTest
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [2,4,1,2,7,8], 9},
            { [2,4,5], 4},
            { [9,8,7,6,5,1,2,3,4], 18},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] piles, int expected)
        {
            var maxCoins = new MaxCoins();
            var actual = maxCoins.Solution(piles);

            Assert.Equal(expected, actual);
        }
    }
}
