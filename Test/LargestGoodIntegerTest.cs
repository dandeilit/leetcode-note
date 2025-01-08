using Code;

namespace Test
{
    public class LargestGoodIntegerTest
    {
        public static TheoryData<string, string> TestData => new TheoryData<string, string>()
        {
            { "6777133339", "777" },
            { "2300019", "000" },
            { "42352338", ""},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string num, string expected)
        {
            var largestGoodInteger = new LargestGoodInteger();
            var actual = largestGoodInteger.Solution(num);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string num, string expected)
        {
            var largestGoodInteger = new LargestGoodInteger();
            var actual = largestGoodInteger.Solution2(num);

            Assert.Equal(expected, actual);
        }
    }
}
