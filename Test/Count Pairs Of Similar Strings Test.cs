using Code;

namespace Test
{
    public class Count_Pairs_Of_Similar_Strings_Test
    {
        public static TheoryData<string[], int> TestData => new TheoryData<string[], int>()
        {
            { ["aba","aabb","abcd","bac","aabc"],2},
            { ["aabb","ab","ba"],3},
            { ["nba","cba","dba"],0},
            { ["dcedceadceceaeddcedc","dddcebcedcdbaeaaaeab","eecbeddbddeadcbbbdbb","decbcbebbddceacdeadd","ccbddbaedcadedbcaaae","dddcaadaceaedcdceedd","bbeddbcbbccddcaceeea","bdabacbbdadabbbddaea"],16},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] words, int expected)
        {
            var count_Pairs_Of_Similar_Strings = new Count_Pairs_Of_Similar_Strings();
            var actual = count_Pairs_Of_Similar_Strings.SimilarPairs(words);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] words, int expected)
        {
            var count_Pairs_Of_Similar_Strings = new Count_Pairs_Of_Similar_Strings();
            var actual = count_Pairs_Of_Similar_Strings.SimilarPairs2(words);

            Assert.Equal(expected, actual);
        }
    }
}
