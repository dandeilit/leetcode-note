using Code;

namespace Test
{
    public class Minimum_Number_of_Swaps_to_Make_the_String_Balanced_Test
    {
        public static TheoryData<string, int> TestData => new TheoryData<string, int>()
        {
            { "][][",1},
            { "]]][[[",2},
            { "[]",0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int expected)
        {
            var minimum_Number_of_Swaps_to_Make_the_String_Balanced = new Minimum_Number_of_Swaps_to_Make_the_String_Balanced();
            var actual = minimum_Number_of_Swaps_to_Make_the_String_Balanced.MinSwaps(s);

            Assert.Equal(expected, actual);
        }
    }
}
