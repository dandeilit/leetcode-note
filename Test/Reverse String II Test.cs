using Code;

namespace Test
{
    public class Reverse_String_II_Test
    {
        public static TheoryData<string, int, string> TestData => new TheoryData<string, int, string>()
        {
            { "abcdefg",2,"bacdfeg"},
            { "abcd",2,"bacd"},
            { "abcdefg",1213,"gfedcba"},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int k, string expected)
        {
            var reverse_String_II = new Reverse_String_II();
            var actual = reverse_String_II.ReverseStr(s, k);

            Assert.Equal(expected, actual);
        }
    }
}
