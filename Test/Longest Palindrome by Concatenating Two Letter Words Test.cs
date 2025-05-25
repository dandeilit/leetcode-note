using Code;

namespace Test
{
    public class Longest_Palindrome_by_Concatenating_Two_Letter_Words_Test
    {
        public static TheoryData<string[], int> TestData => new TheoryData<string[], int> {
            { ["lc","cl","gg"],6},
            { ["ab","ty","yt","lc","cl","ab"],8},
            { ["cc","ll","xx"],2},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] words, int expected)
        {
            var longest_Palindrome_by_Concatenating_Two_Letter_Words = new Longest_Palindrome_by_Concatenating_Two_Letter_Words();
            var actual = longest_Palindrome_by_Concatenating_Two_Letter_Words.LongestPalindrome(words);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] words, int expected)
        {
            var longest_Palindrome_by_Concatenating_Two_Letter_Words = new Longest_Palindrome_by_Concatenating_Two_Letter_Words();
            var actual = longest_Palindrome_by_Concatenating_Two_Letter_Words.LongestPalindrome2(words);
            Assert.Equal(expected, actual);
        }
    }
}
