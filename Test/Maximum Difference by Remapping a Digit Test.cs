using Code;

namespace Test
{
    public class Maximum_Difference_by_Remapping_a_Digit_Test
    {
        public static TheoryData<int, int> TestData => new TheoryData<int, int> {
            { 11891, 99009 },
            { 90, 99 },
            { 456,900}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int num, int expected)
        {
            var maximum_Difference_by_Remapping_a_Digit = new Maximum_Difference_by_Remapping_a_Digit();
            var actual = maximum_Difference_by_Remapping_a_Digit.MinMaxDifference(num);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int num, int expected)
        {
            var maximum_Difference_by_Remapping_a_Digit = new Maximum_Difference_by_Remapping_a_Digit();
            var actual = maximum_Difference_by_Remapping_a_Digit.MinMaxDifference2(num);
            Assert.Equal(expected, actual);
        }
    }
}
