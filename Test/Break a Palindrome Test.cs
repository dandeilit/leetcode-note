using Code;

namespace Test
{
    public class Break_a_Palindrome_Test
    {
        public static TheoryData<string, string> TestData => new TheoryData<string, string>
        {
            { "abccba","aaccba"},
            { "a",""},
            { "aba","abb"},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string palindrome, string expected)
        {
            var break_a_Palindrome = new Break_a_Palindrome();
            var actual = break_a_Palindrome.BreakPalindrome(palindrome);

            Assert.Equal(expected, actual);
        }
    }
}
