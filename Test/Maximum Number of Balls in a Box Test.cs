using Code;

namespace Test
{
    public class Maximum_Number_of_Balls_in_a_Box_Test
    {
        public static TheoryData<int, int, int> TestData => new TheoryData<int, int, int>()
        {
            { 1,10,2},
            { 5,15,2},
            { 19,28,2},
            { 11,104,9},
            { 101,101,1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int lowLimit, int highLimit, int expected)
        {
            var maximum_Number_of_Balls_in_a_Box = new Maximum_Number_of_Balls_in_a_Box();
            var actual = maximum_Number_of_Balls_in_a_Box.CountBalls(lowLimit, highLimit);

            Assert.Equal(expected, actual);
        }
    }
}
