using Code;

namespace Test
{
    public class Total_Characters_in_String_After_Transformations_I_Test
    {
        public static TheoryData<string, int, int> TestData => new TheoryData<string, int, int> {
            { "abcyy",2,7},
            { "azbk",1,5},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int t, int expected)
        {
            var total_Characters_in_String_After_Transformations_I = new Total_Characters_in_String_After_Transformations_I();
            var actual = total_Characters_in_String_After_Transformations_I.LengthAfterTransformations(s, t);
            Assert.Equal(expected, actual);
        }
    }
}
