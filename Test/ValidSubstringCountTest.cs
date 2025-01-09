using Code;

namespace Test
{
    public class ValidSubstringCountTest
    {
        public static TheoryData<string, string, long> TestData => new TheoryData<string, string, long>()
        {
            { "bcca", "abc", 1 },
            { "abcabc", "abc", 10 },
            { "abcabc", "aaabc", 0 },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string world1, string world2, long expected)
        {
            var validSubstringCount = new ValidSubstringCount();
            var actual = validSubstringCount.Solution(world1, world2);

            Assert.Equal(expected, actual);
        }
    }
}
