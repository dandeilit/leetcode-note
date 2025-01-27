using Code;

namespace Test
{
    public class JumpTest
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [2,3,1,1,4],2},
            { [2,3,0,1,4],2},
            { [0],0},
            { [1,2,3],2},
            { [1,2],1},
            { [9,7,9,1,7,3,7,0,5,0,0,5,6,7,5,6,0,5,4,7,3,9,0,2,0,5,9,2,3,6,0,4,3,1,6,3,4,3,3,1,3,3,8,1,2,3,0,3,1,4,2,6,5,4,0,6,9,0,8,4,6,0,9,2,1,7,5],12}
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int expected)
        {
            var jump = new Jump();
            var actual = jump.Solution(nums);

            Assert.Equal(expected, actual);
        }
    }
}
