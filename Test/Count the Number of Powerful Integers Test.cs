using Code;

namespace Test
{
    public class Count_the_Number_of_Powerful_Integers_Test
    {
        public static TheoryData<long, long, int, string, long> TestData => new TheoryData<long, long, int, string, long> {
            { 1,6000,4,"124",5},
            { 15,215,6,"10",2},
            { 1000,2000,4,"3000",0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(long start, long finish, int limit, string s, long expected)
        {
            var count_the_Number_of_Powerful_Integers = new Count_the_Number_of_Powerful_Integers();
            var actual = count_the_Number_of_Powerful_Integers.NumberOfPowerfulInt(start, finish, limit, s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(long start, long finish, int limit, string s, long expected)
        {
            var count_the_Number_of_Powerful_Integers = new Count_the_Number_of_Powerful_Integers();
            var actual = count_the_Number_of_Powerful_Integers.NumberOfPowerfulInt2(start, finish, limit, s);
            Assert.Equal(expected, actual);
        }
    }
}
