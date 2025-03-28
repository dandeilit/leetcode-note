using Code;

namespace Test
{
    public class Minimize_String_Length_Test
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int>()
        {
            { "aaabc",3},
            { "cbbd",3},
            { "dddaaa",2},
            { "baadccab",4},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int expected)
        {
            var minimize_String_Length = new Minimize_String_Length();
            var actual = minimize_String_Length.MinimizedStringLength(s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string s, int expected)
        {
            var minimize_String_Length = new Minimize_String_Length();
            var actual = minimize_String_Length.MinimizedStringLength2(s);
            Assert.Equal(expected, actual);
        }
    }
}
