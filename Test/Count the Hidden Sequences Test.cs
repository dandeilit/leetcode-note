using Code;

namespace Test
{
    public class Count_the_Hidden_Sequences_Test
    {
        public static TheoryData<int[], int, int, int> TestData => new TheoryData<int[], int, int, int> {
            { [1,-3,4],1,6,2},
            { [3,-4,5,1,-2],-4,5,4},
            { [4,-7,2],3,6,0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] differences, int lower, int upper, int expected)
        {
            var count_the_Hidden_Sequences = new Count_the_Hidden_Sequences();
            var actual = count_the_Hidden_Sequences.NumberOfArrays(differences, lower, upper);
            Assert.Equal(expected, actual);
        }
    }
}
