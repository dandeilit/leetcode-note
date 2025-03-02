using Code;

namespace Test
{
    public class Palindrome_Partitioning_II_Test
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int>()
        {
            { "aab",1},
            { "a",0},
            { "ab",1},
            { "cdd",1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int expected)
        {
            var palindrome_Partitioning_II = new Palindrome_Partitioning_II();
            var actual = palindrome_Partitioning_II.MinCut(s);

            Assert.Equal(expected, actual);
        }

    }
}
