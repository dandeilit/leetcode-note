using Code;

namespace Test
{
    public class Count_Good_Triplets_Test
    {
        public static TheoryData<int[], int, int, int, int> TestData => new TheoryData<int[], int, int, int, int> {
            { [3,0,1,1,9,7],7,2,3,4},
            { [1,1,2,2,3],0,0,1,0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] arr, int a, int b, int c, int expected)
        {
            var count_Good_Triplets = new Count_Good_Triplets();
            var actual = count_Good_Triplets.CountGoodTriplets(arr, a, b, c);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] arr, int a, int b, int c, int expected)
        {
            var count_Good_Triplets = new Count_Good_Triplets();
            var actual = count_Good_Triplets.CountGoodTriplets2(arr, a, b, c);
            Assert.Equal(expected, actual);
        }
    }
}
