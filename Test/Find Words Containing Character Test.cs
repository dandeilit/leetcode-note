using Code;

namespace Test
{
    public class Find_Words_Containing_Character_Test
    {
        public static TheoryData<string[], char, int[]> TestData => new TheoryData<string[], char, int[]> {
            { ["leet","code"],'e',[0,1]},
            { ["abc","bcd","aaaa","cbc"],'a',[0,2]},
            { ["abc","bcd","aaaa","cbc"],'z',[]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] words, char x, int[] expected)
        {
            var find_Words_Containing_Character = new Find_Words_Containing_Character();
            var actual = find_Words_Containing_Character.FindWordsContaining(words, x);
            Assert.Equal(expected, actual);
        }
    }
}
