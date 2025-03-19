using Code;

namespace Test
{
    public class Convert_an_Array_Into_a_2D_Array_With_Conditions_Test
    {
        public static TheoryData<int[], int[][]> TestData => new TheoryData<int[], int[][]>()
        {
            { [1,3,4,1,2,3,1],[[1,3,4,2],[1,3],[1]]},
            { [1,2,3,4],[[4,3,2,1]]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, int[][] expected)
        {
            var convert_an_Array_Into_a_2D_Array_With_Conditions = new Convert_an_Array_Into_a_2D_Array_With_Conditions();
            var actual = convert_an_Array_Into_a_2D_Array_With_Conditions.FindMatrix(nums);

            if (actual.Count() > expected.Length) Assert.Fail("row number is bigger");

            for (var i = 0; i < actual.Count(); i++)
            {
                if (actual[i].Distinct().Count() != actual[i].Count)
                {
                    Assert.Fail("contain same integers");
                    break;
                }

                for (var j = 0; j < actual[i].Count(); j++)
                {
                    if (!nums.Contains(actual[i][j]))
                    {
                        Assert.Fail("contain error elements");
                        break;
                    }
                }
            }
            Assert.True(true);
        }
    }
}
