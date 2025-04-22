using Code;

namespace Test
{
    public class Count_the_Number_of_Ideal_Arrays_Test
    {
        public static TheoryData<int, int, int> TestData => new TheoryData<int, int, int> {
            { 2,5,10},
            { 5,3,11},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int maxValue, int expected)
        {
            var count_the_Number_of_Ideal_Arrays = new Count_the_Number_of_Ideal_Arrays();
            var actual = count_the_Number_of_Ideal_Arrays.IdealArrays(n, maxValue);
            Assert.Equal(expected, actual);
        }
    }
}
