using Code;

namespace Test
{
    public class Lexicographically_Smallest_Equivalent_String_Test
    {
        public static TheoryData<string, string, string, string> TestData => new TheoryData<string, string, string, string> {
            { "parker","morris","parser","makkek"},
            { "hello","world","hold","hdld"},
            { "leetcode","programs","sourcecode","aauaaaaada"},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s1, string s2, string baseStr, string expected)
        {
            var lexicographically_Smallest_Equivalent_String = new Lexicographically_Smallest_Equivalent_String();
            var actual = lexicographically_Smallest_Equivalent_String.SmallestEquivalentString(s1, s2, baseStr);
            Assert.Equal(expected, actual);
        }
    }
}
