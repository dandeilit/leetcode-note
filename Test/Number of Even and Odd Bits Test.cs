using Code;

namespace Test
{
    public class Number_of_Even_and_Odd_Bits_Test
    {
        public static TheoryData<int, int[]> TestData => new TheoryData<int, int[]>()
        {
            { 50,[1,2]},
            { 2,[0,1]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int[] expected)
        {
            var number_of_Even_and_Odd_Bits = new Number_of_Even_and_Odd_Bits();
            var actual = number_of_Even_and_Odd_Bits.EvenOddBit(n);

            Assert.Equal(expected, actual);
        }
    }
}
