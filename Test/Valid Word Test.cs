using Code;

namespace Test
{
    public class Valid_Word_Test
    {
        public static TheoryData<string, bool> TestData => new TheoryData<string, bool>
        {
            { "234Adas",true},
            { "b3",false},
            { "a3$e",false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string word, bool expected)
        {
            var valid_Word = new Valid_Word();
            var actual = valid_Word.IsValid(word);
            Assert.Equal(expected, actual);
        }
    }
}
