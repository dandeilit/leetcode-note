using Code;

namespace Test
{
    public class Longest_Unequal_Adjacent_Groups_Subsequence_I_Test
    {
        public static TheoryData<string[], int[], string[]> TestData => new TheoryData<string[], int[], string[]> {
            { ["e","a","b"],[0,0,1],["e","b"]},
            { ["a","b","c","d"],[1,0,1,1],["a","b","c"]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] words, int[] groups, string[] expected)
        {
            var longest_Unequal_Adjacent_Groups_Subsequence_I = new Longest_Unequal_Adjacent_Groups_Subsequence_I();
            var actual = longest_Unequal_Adjacent_Groups_Subsequence_I.GetLongestSubsequence(words, groups).ToArray();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] words, int[] groups, string[] expected)
        {
            var longest_Unequal_Adjacent_Groups_Subsequence_I = new Longest_Unequal_Adjacent_Groups_Subsequence_I();
            var actual = longest_Unequal_Adjacent_Groups_Subsequence_I.GetLongestSubsequence(words, groups).ToArray();
            Assert.Equal(expected, actual);
        }
    }
}
