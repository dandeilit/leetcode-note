using Code;

namespace Test
{
    public class MinimumCoinsTest
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [3,1,2],4},
            { [1,10,1,1],2},
            { [26,18,6,12,49,7,45,45],39},
            { [14,37,37,38,24,15,12],63},
            { [38,23,27,32,47,45,48,24,39,26,37,42,24,45,27,26,15,16,26,6],132},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] prices, int expected)
        {
            var minimumCoins = new MinimumCoins();
            var actual = minimumCoins.Solution(prices);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] prices, int expected)
        {
            var minimumCoins = new MinimumCoins();
            var actual = minimumCoins.Solution2(prices);

            Assert.Equal(expected, actual);
        }
    }
}
