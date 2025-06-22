using Code;

namespace Test
{
    public class Divide_a_String_Into_Groups_of_Size_k_Test
    {
        public static TheoryData<string, int, char, string[]> TestData => new TheoryData<string, int, char, string[]> {
            { "abcdefghi",3,'x',["abc","def","ghi"]},
            { "abcdefghij",3,'x',["abc","def","ghi","jxx"]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, int k, char fill, string[] expected)
        {
            var divide_a_String_Into_Groups_of_Size_k = new Divide_a_String_Into_Groups_of_Size_k();
            var actual = divide_a_String_Into_Groups_of_Size_k.DivideString(s, k, fill);
            Assert.Equal(expected, actual);
        }
    }
}
