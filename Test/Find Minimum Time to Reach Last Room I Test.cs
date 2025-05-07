using Code;

namespace Test
{
    public class Find_Minimum_Time_to_Reach_Last_Room_I_Test
    {
        public static TheoryData<int[][], int> TestData => new TheoryData<int[][], int> {
            { [[0,4],[4,4]],6},
            { [[0,0,0],[0,0,0]],3},
            { [[0,1],[1,2]],3},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[][] moveTime, int expected)
        {
            var find_Minimum_Time_to_Reach_Last_Room_I = new Find_Minimum_Time_to_Reach_Last_Room_I();
            var actual = find_Minimum_Time_to_Reach_Last_Room_I.MinTimeToReach(moveTime);
            Assert.Equal(expected, actual);
        }
    }
}
