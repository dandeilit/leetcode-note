using Code;

namespace Test
{
    public class Palindrome_Partitioning_IV_Test
    {
        public static TheoryData<string, bool> TestData => new TheoryData<string, bool>()
        {
            { "abcbdd",true},
            { "bcbddxy",false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, bool expected)
        {
            var palindrome_Partitioning_IV = new Palindrome_Partitioning_IV();
            var actual = palindrome_Partitioning_IV.CheckPartitioning(s);

            Assert.Equal(expected, actual);
        }
    }
}
