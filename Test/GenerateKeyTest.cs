using Code;

namespace Test
{
    public class GenerateKeyTest
    {
        public static TheoryData<int, int, int, int> TestData => new TheoryData<int, int, int, int>()
        {
            { 1,10,1000,0 },
            { 987,879,798,777},
            { 1,2,3,1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int num1, int num2, int num3, int expected)
        {
            var generateKey = new GenerateKey();
            var actual = generateKey.Solution(num1, num2, num3);

            Assert.Equal(expected, actual);
        }
    }
}
