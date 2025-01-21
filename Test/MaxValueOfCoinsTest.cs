using Code;

namespace Test
{
    public class MaxValueOfCoinsTest
    {
        public static TheoryData<IList<IList<int>>, int, int> TestData => new TheoryData<IList<IList<int>>, int, int>()
        {
            { [[1, 100, 3], [7, 8, 9]],2,101},
            { [[100],[100],[100],[100],[100],[100],[1,1,1,1,1,1,700]],7,706},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(IList<IList<int>> piles, int k, int expected)
        {
            var maxValueOfCoins = new MaxValueOfCoins();
            var actual = maxValueOfCoins.Solution(piles, k);

            Assert.Equal(expected, actual);
        }
    }
}
