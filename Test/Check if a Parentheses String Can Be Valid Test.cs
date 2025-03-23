using Code;

namespace Test
{
    public class Check_if_a_Parentheses_String_Can_Be_Valid_Test
    {
        public static TheoryData<string, string, bool> TestData => new TheoryData<string, string, bool>()
        {
            { "))()))","010100",true},
            { "()()","0000",true},
            { ")","0",false},
            { "(((())(((())","111111010111",true},
            { "(((())","111111",false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, string locked, bool expected)
        {
            var check_if_a_Parentheses_String_Can_Be_Valid = new Check_if_a_Parentheses_String_Can_Be_Valid();
            var actual = check_if_a_Parentheses_String_Can_Be_Valid.CanBeValid(s, locked);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string s, string locked, bool expected)
        {
            var check_if_a_Parentheses_String_Can_Be_Valid = new Check_if_a_Parentheses_String_Can_Be_Valid();
            var actual = check_if_a_Parentheses_String_Can_Be_Valid.CanBeValid2(s, locked);
            Assert.Equal(expected, actual);
        }
    }
}
