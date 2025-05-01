using Code;

namespace Test
{
    public class Maximum_Number_of_Tasks_You_Can_Assign_Test
    {
        public static TheoryData<int[], int[], int, int, int> TestData => new TheoryData<int[], int[], int, int, int> {
            { [3,2,1],[0,3,3],1,1,3},
            { [5,4],[0,0,0],1,5,1},
            { [10,15,30],[0,10,10,10,10],3,10,2},
            { [5,9,8,5,9],[1,6,4,2,6],1,5,3},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] tasks, int[] workers, int pills, int strength, int expected)
        {
            var maximum_Number_of_Tasks_You_Can_Assign = new Maximum_Number_of_Tasks_You_Can_Assign();
            var actual = maximum_Number_of_Tasks_You_Can_Assign.MaxTaskAssign(tasks, workers, pills, strength);
            Assert.Equal(expected, actual);
        }
    }
}
