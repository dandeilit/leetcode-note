using Code;

namespace Test
{
    public class Adding_Spaces_to_a_String_Test
    {
        public static TheoryData<string, int[], string> TestData => new TheoryData<string, int[], string>()
        {
            { "LeetcodeHelpsMeLearn",[8,13,15],"Leetcode Helps Me Learn"},
            { "icodeinpython",[1,5,7,9],"i code in py thon"},
            { "spacing",[0,1,2,3,4,5,6]," s p a c i n g"},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int[] spaces, string expected)
        {
            var adding_Spaces_to_a_String = new Adding_Spaces_to_a_String();
            var actual = adding_Spaces_to_a_String.AddSpaces(s, spaces);
            Assert.Equal(expected, actual);
        }
    }
}
