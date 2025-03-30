using Code;

namespace Test
{
    public class Longest_Cycle_in_a_Graph_Test
    {
        public static TheoryData<int[], int> TestData => new TheoryData<int[], int>()
        {
            { [3,3,4,2,3],3},
            { [2,-1,3,1],-1},
            { [-1,4,-1,2,0,4],-1},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] edges, int expected)
        {
            var longest_Cycle_in_a_Graph = new Longest_Cycle_in_a_Graph();
            var actual = longest_Cycle_in_a_Graph.LongestCycle(edges);
            Assert.Equal(expected, actual);
        }
    }
}
