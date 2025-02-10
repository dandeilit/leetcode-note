using Code;

namespace Test
{
    public class Cat_and_Mouse_Test
    {
        public static TheoryData<int[][], int> TestData => new TheoryData<int[][], int>()
        {
            { [[2,5],[3],[0,4,5],[1,4,5],[2,3],[0,2,3]],0},
            { [[1,3],[0],[3],[0,2]],1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] graph, int expected)
        {
            var cat_and_Mouse = new Cat_and_Mouse();
            var actual = cat_and_Mouse.CatMouseGame(graph);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[][] graph, int expected)
        {
            var cat_and_Mouse = new Cat_and_Mouse();
            var actual = cat_and_Mouse.CatMouseGame2(graph);

            Assert.Equal(expected, actual);
        }
    }
}
