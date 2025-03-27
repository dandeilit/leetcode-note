using Code;

namespace Test
{
    public class Minimum_Cost_to_Make_All_Characters_Equal_Test
    {
        public static TheoryData<string, long> TestData => new TheoryData<string, long>()
        {
            { "0011",2},
            { "010101",9},
            { "00",0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string s, long expected)
        {
            var minimum_Cost_to_Make_All_Characters_Equal = new Minimum_Cost_to_Make_All_Characters_Equal();
            var actual = minimum_Cost_to_Make_All_Characters_Equal.MinimumCost(s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string s, long expected)
        {
            var minimum_Cost_to_Make_All_Characters_Equal = new Minimum_Cost_to_Make_All_Characters_Equal();
            var actual = minimum_Cost_to_Make_All_Characters_Equal.MinimumCost2(s);
            Assert.Equal(expected, actual);
        }
    }
}
