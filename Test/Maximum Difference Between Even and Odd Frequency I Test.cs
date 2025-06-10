using Code;

namespace Test
{
    public class Maximum_Difference_Between_Even_and_Odd_Frequency_I_Test
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int> {
            { "aaaaabbc",3},
            { "abcabcab",1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int expected)
        {
            var maximum_Difference_Between_Even_and_Odd_Frequency_I = new Maximum_Difference_Between_Even_and_Odd_Frequency_I();
            var actual = maximum_Difference_Between_Even_and_Odd_Frequency_I.MaxDifference(s);
            Assert.Equal(expected, actual);
        }
    }
}
