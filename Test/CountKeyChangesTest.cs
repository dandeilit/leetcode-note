using Code;

namespace Test
{
    public class CountKeyChangesTest
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int>()
        {
            { "aAbBcC", 2 },
            { "AaAaAaaA", 0 },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int expected)
        {
            var countKeyChanges = new CountKeyChanges();
            var actual = countKeyChanges.Solution(s);

            Assert.Equal(expected, actual);
        }
    }
}
