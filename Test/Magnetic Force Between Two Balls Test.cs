using Code;

namespace Test
{
    public class Magnetic_Force_Between_Two_Balls_Test
    {
        public static TheoryData<int[], int, int> TestData => new TheoryData<int[], int, int>()
        {
            { [1,2,3,4,7],3,3},
            { [5,4,3,2,1,1000000000],2,999999999},
            { [1,2,3,4,5,6,7,8,9,10],4,3},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] position, int m, int expected)
        {
            var magnetic_Force_Between_Two_Balls = new Magnetic_Force_Between_Two_Balls();
            var actual = magnetic_Force_Between_Two_Balls.MaxDistance(position, m);

            Assert.Equal(expected, actual);
        }
    }
}
