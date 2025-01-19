using Code;

namespace Test
{
    public class CountTextsTest
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int>()
        {
            { "22233", 8 },
            { "222222222222222222222222222222222222", 82876089},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string pressedKeys, int expected)
        {
            var countTexts = new CountTexts();
            var actual = countTexts.Solution(pressedKeys);

            Assert.Equal(expected, actual);
        }
    }
}
