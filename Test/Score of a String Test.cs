using Code;

namespace Test
{
    public class Score_of_a_String_Test
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int>()
        {
            { "hello",13},
            { "zaz",50},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int expected)
        {
            var score_of_a_String = new Score_of_a_String();
            var actual = score_of_a_String.ScoreOfString(s);

            Assert.Equal(expected, actual);
        }
    }
}
