using Code;

namespace Test
{
    public class Substring_With_Largest_Variance_Test
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int>()
        {
            { "aababbb",3},
            { "abcde",0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int expected)
        {
            var substring_With_Largest_Variance = new Substring_With_Largest_Variance();
            var actual = substring_With_Largest_Variance.LargestVariance(s);

            Assert.Equal(expected, actual);
        }
    }
}
