using Code;

namespace Test
{
    public class Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II_Test
    {
        public static TheoryData<string, int, long> TestData => new TheoryData<string, int, long>()
        {
            { "aeioqq",1,0},
            { "aeiou",0,1},
            { "ieaouqqieaouqq",1,3},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string word, int k, long expected)
        {
            var count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II = new Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II();
            var actual = count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II.CountOfSubstrings(word, k);

            Assert.Equal(expected, actual);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string word, int k, long expected)
        {
            var count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II = new Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II();
            var actual = count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II.CountOfSubstrings2(word, k);

            Assert.Equal(expected, actual);
        }
    }
}
