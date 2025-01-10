using Code;

namespace Test
{
    public class ValidSubstringCountIITest
    {
        public static TheoryData<string, string, long> TestData => new TheoryData<string, string, long>()
        {
            { "bcca", "abc", 1 },
            { "abcabc", "abc", 10 },
            { "abcabc", "aaabc", 0 },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string word1, string word2, long expected)
        {
            var validSubstringCountII = new ValidSubstringCountII();
            var actual = validSubstringCountII.Solution(word1, word2);

            Assert.Equal(expected, actual);
        }
    }
}
