using Code;

namespace Test
{
    public class Minimum_Reverse_Operations_Test
    {
        public static TheoryData<int, int, int[], int, int[]> TestData => new TheoryData<int, int, int[], int, int[]>()
        {
            { 4,0,[1,2],4,[0,-1,-1,1]},
            { 5,0,[2,4],3,[0,-1,-1,-1,-1]},
            { 4,2,[0,1,3],1,[-1,-1,0,-1]},
            { 5,0,[],2,[0,1,2,3,4]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int n, int p, int[] banned, int k, int[] expected)
        {
            var minimum_Reverse_Operations = new Minimum_Reverse_Operations();
            var actual = minimum_Reverse_Operations.MinReverseOperations(n, p, banned, k);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int n, int p, int[] banned, int k, int[] expected)
        {
            var minimum_Reverse_Operations = new Minimum_Reverse_Operations();
            var actual = minimum_Reverse_Operations.MinReverseOperations(n, p, banned, k);

            Assert.Equal(expected, actual);
        }
    }
}
