using Code;

namespace Test
{
    public class Divisible_and_Non_divisible_Sums_Difference_Test
    {
        public static TheoryData<int, int, int> TestData => new TheoryData<int, int, int> {
            { 10,3,19},
            { 5,6,15},
            { 5,1,-15},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int m, int expected)
        {
            var divisible_and_Non_divisible_Sums_Difference = new Divisible_and_Non_divisible_Sums_Difference();
            var actual = divisible_and_Non_divisible_Sums_Difference.DifferenceOfSums(n, m);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int n, int m, int expected)
        {
            var divisible_and_Non_divisible_Sums_Difference = new Divisible_and_Non_divisible_Sums_Difference();
            var actual = divisible_and_Non_divisible_Sums_Difference.DifferenceOfSums2(n, m);
            Assert.Equal(expected, actual);
        }
    }
}
