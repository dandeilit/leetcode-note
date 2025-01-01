using Code;

namespace Test
{
    public class ConvertDateToBinaryTest
    {
        public static TheoryData<string, string> TestData => new TheoryData<string, string>()
        {
            {"2080-02-29","100000100000-10-11101" },
            {"1900-01-01","11101101100-1-1" },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string date, string expected)
        {
            var convertDateToBinary = new ConvertDateToBinary();
            var actual = convertDateToBinary.Solution(date);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string date, string expected)
        {
            var convertDateToBinary = new ConvertDateToBinary();
            var actual = convertDateToBinary.Solution2(date);
            Assert.Equal(expected, actual);
        }
    }
}
