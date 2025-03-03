using Code;

namespace Test
{
    public class Palindrome_Partitioning_III_Test
    {
        public static TheoryData<string, int, int> TestData => new TheoryData<string, int, int>()
        {
            { "abc",2,1},
            { "aabbc",3,0},
            { "leetcode",8,0}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int k, int expected)
        {
            var palindrome_Partitioning_III = new Palindrome_Partitioning_III();
            var actual = palindrome_Partitioning_III.PalindromePartition(s, k);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string s, int k, int expected)
        {
            var palindrome_Partitioning_III = new Palindrome_Partitioning_III();
            var actual = palindrome_Partitioning_III.PalindromePartition2(s, k);

            Assert.Equal(expected, actual);
        }
    }
}
