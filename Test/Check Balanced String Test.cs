using Code;

namespace Test
{
    public class Check_Balanced_String_Test
    {
        public static TheoryData<string, bool> TestData => new TheoryData<string, bool>()
        {
            { "1234",false},
            { "24123",true},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string num, bool expected)
        {
            var check_Balanced_String = new Check_Balanced_String();
            var actual = check_Balanced_String.IsBalanced(num);

            Assert.Equal(expected, actual);
        }
    }
}
