using Code;

namespace Test
{
    public class Palindrome_Partitioning_Test
    {
        public static TheoryData<string, string[][]> TestData => new TheoryData<string, string[][]>()
        {
            { "aab",[["a","a","b"],["aa","b"]]},
            { "a",[["a"]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, string[][] expected)
        {
            var palindrome_Partitioning = new Palindrome_Partitioning();
            var actual = palindrome_Partitioning.Partition(s);

            Assert.Equal(expected, actual);
        }
    }
}
