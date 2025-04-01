using Code;

namespace Test
{
    public class Solving_Questions_With_Brainpower_Test
    {
        public static TheoryData<int[][], long> TestData => new TheoryData<int[][], long>()
        {
            { [[3,2],[4,3],[4,4],[2,5]],5},
            { [[1,1],[2,2],[3,3],[4,4],[5,5]],7},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] questions, long expected)
        {
            var solving_Questions_With_Brainpower = new Solving_Questions_With_Brainpower();
            var actual = solving_Questions_With_Brainpower.MostPoints(questions);
            Assert.Equal(expected, actual);
        }
    }
}
