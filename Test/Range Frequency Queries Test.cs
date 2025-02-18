using Code;

namespace Test
{
    public class Range_Frequency_Queries_Test
    {
        public static TheoryData<int[], int[][], int?[]> TestData => new TheoryData<int[], int[][], int?[]>()
        {
            { [12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56], [[1, 2, 4], [0, 11, 33]], [null, 1, 2]},
            { [8,4,2,5,4,5,8,6,2,3], [[0,3,5],[5,6,2],[6,8,4],[2,8,3],[4,5,1],[2,4,2]], [null,1,0,0,0,0,1]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] arr, int[][] parameters, int?[] expected)
        {
            var actual = new int?[parameters.Length + 1];
            var rangeFreqQuery = new Range_Frequency_Queries.RangeFreqQuery(arr);
            actual[0] = null;
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                actual[i + 1] = rangeFreqQuery.Query(parameter[0], parameter[1], parameter[2]);
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] arr, int[][] parameters, int?[] expected)
        {
            var actual = new int?[parameters.Length + 1];
            var rangeFreqQuery = new Range_Frequency_Queries.RangeFreqQuery2(arr);
            actual[0] = null;
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                actual[i + 1] = rangeFreqQuery.Query(parameter[0], parameter[1], parameter[2]);
            }

            Assert.Equal(expected, actual);
        }
    }
}
