using Code;

namespace Test
{
    public class Valid_Palindrome_II_Test
    {
        public static TheoryData<string, bool> TestData => new TheoryData<string, bool>()
        {
            { "aba",true},
            { "abca",true},
            { "abc",false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, bool expected)
        {
            var valid_Palindrome_II = new Valid_Palindrome_II();
            var actual = valid_Palindrome_II.ValidPalindrome(s);

            Assert.Equal(expected, actual);
        }
    }
}
