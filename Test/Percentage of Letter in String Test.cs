using Code;

namespace Test
{
    public class Percentage_of_Letter_in_String_Test
    {
        public static TheoryData<string, char, int> TestData => new TheoryData<string, char, int>()
        {
            { "foobar",'o',33},
            { "jjjj",'k',0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, char letter, int expected)
        {
            var percentage_of_Letter_in_String = new Percentage_of_Letter_in_String();
            var actual = percentage_of_Letter_in_String.PercentageLetter(s, letter);
            Assert.Equal(expected, actual);
        }
    }
}
