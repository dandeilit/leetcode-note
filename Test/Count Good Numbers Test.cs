using Code;

namespace Test
{
    public class Count_Good_Numbers_Test
    {
        public static TheoryData<long, int> TestData => new TheoryData<long, int> {
            { 1,5},
            { 4,400},
            { 50,564908303},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(long n, int expected)
        {
            var count_Good_Numbers = new Count_Good_Numbers();
            var actual = count_Good_Numbers.CountGoodNumbers(n);
            Assert.Equal(expected, actual);
        }
    }
}
