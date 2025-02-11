using Code;

namespace Test
{
    public class Cat_and_Mouse_II_Test
    {
        public static TheoryData<string[], int, int, bool> TestData => new TheoryData<string[], int, int, bool>()
        {
            { ["####F","#C...","M...."],1,2,true},
            { ["M.C...F"],1,4,true},
            { ["M.C...F"],1,3,false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] grid, int catJump, int mouseJump, bool expected)
        {
            var cat_and_Mouse_II = new Cat_and_Mouse_II();
            var actual = cat_and_Mouse_II.CanMouseWin(grid, catJump, mouseJump);

            Assert.Equal(expected, actual);
        }
    }
}
