using Code;

namespace Test
{
    public class Count_Prefixes_of_a_Given_String_Test
    {
        public static TheoryData<string[], string, int> TestData => new TheoryData<string[], string, int>()
        {
            { ["a","b","c","ab","bc","abc"],"abc",3},
            { ["a","a"],"aa",2},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] words, string s, int expected)
        {
            var count_Prefixes_of_a_Given_String = new Count_Prefixes_of_a_Given_String();
            var actual = count_Prefixes_of_a_Given_String.CountPrefixes(words, s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] words, string s, int expected)
        {
            var count_Prefixes_of_a_Given_String = new Count_Prefixes_of_a_Given_String();
            var actual = count_Prefixes_of_a_Given_String.CountPrefixes2(words, s);
            Assert.Equal(expected, actual);
        }
    }
}
