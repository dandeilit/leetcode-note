using Code;

namespace Test
{
    public class Maximum_Total_Beauty_of_the_Gardens_Test
    {
        public static TheoryData<int[], long, int, int, int, long> TestData => new TheoryData<int[], long, int, int, int, long>()
        {
            { [1,3,1,1],7,6,12,1,14},
            { [2,4,5,3],10,5,2,6,30},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] flowers, long newFlowers, int target, int full, int partial, long expected)
        {
            var maximum_Total_Beauty_of_the_Gardens = new Maximum_Total_Beauty_of_the_Gardens();
            var actual = maximum_Total_Beauty_of_the_Gardens.MaximumBeauty(flowers, newFlowers, target, full, partial);

            Assert.Equal(expected, actual);
        }
    }
}
