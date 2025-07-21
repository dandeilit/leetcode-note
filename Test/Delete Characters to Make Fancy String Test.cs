using Code;

namespace Test
{
    public class Delete_Characters_to_Make_Fancy_String_Test
    {
        public static TheoryData<string, string> TestData => new TheoryData<string, string> {
            { "leeetcode","leetcode"},
            { "aaabaaaa","aabaa"},
            { "aab","aab"},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, string expected)
        {
            var delete_Characters_to_Make_Fancy_String = new Delete_Characters_to_Make_Fancy_String();
            var actual = delete_Characters_to_Make_Fancy_String.MakeFancyString(s);
            Assert.Equal(expected, actual);
        }
    }
}
