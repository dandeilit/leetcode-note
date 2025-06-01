using Code;

namespace Test
{
    public class Distribute_Candies_Among_Children_II_Test
    {
        public static TheoryData<int, int, long> TestData => new TheoryData<int, int, long> {
            { 5,2,3},
            { 3,3,10},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int limit, long expected)
        {
            var distribute_Candies_Among_Children_II = new Distribute_Candies_Among_Children_II();
            var actual = distribute_Candies_Among_Children_II.DistributeCandies(n, limit);
            Assert.Equal(expected, actual);
        }
    }
}
