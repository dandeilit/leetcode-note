using Code;

namespace Test
{
    public class Minimum_White_Tiles_After_Covering_With_Carpets_Test
    {
        public static TheoryData<string, int, int, int> TestData => new TheoryData<string, int, int, int>()
        {
            { "10110101", 2, 2, 2},
            { "11111", 2, 3, 0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string floor, int numCarpets, int carpetLen, int expected)
        {
            var minimum_White_Tiles_After_Covering_With_Carpets = new Minimum_White_Tiles_After_Covering_With_Carpets();
            var actual = minimum_White_Tiles_After_Covering_With_Carpets.MinimumWhiteTiles(floor, numCarpets, carpetLen);

            Assert.Equal(expected, actual);
        }
    }
}
