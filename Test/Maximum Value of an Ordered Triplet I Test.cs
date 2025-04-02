using Code;

namespace Test
{
    public class Maximum_Value_of_an_Ordered_Triplet_I_Test
    {
        public static TheoryData<int[], long> TestData => new TheoryData<int[], long>()
        {
            { [12,6,1,2,7],77},
            { [1,10,3,4,19],133},
            { [1,2,3],0},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, long expected)
        {
            var maximum_Value_of_an_Ordered_Triplet_I = new Maximum_Value_of_an_Ordered_Triplet_I();
            var actual = maximum_Value_of_an_Ordered_Triplet_I.MaximumTripletValue(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, long expected)
        {
            var maximum_Value_of_an_Ordered_Triplet_I = new Maximum_Value_of_an_Ordered_Triplet_I();
            var actual = maximum_Value_of_an_Ordered_Triplet_I.MaximumTripletValue(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(int[] nums, long expected)
        {
            var maximum_Value_of_an_Ordered_Triplet_I = new Maximum_Value_of_an_Ordered_Triplet_I();
            var actual = maximum_Value_of_an_Ordered_Triplet_I.MaximumTripletValue(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test4(int[] nums, long expected)
        {
            var maximum_Value_of_an_Ordered_Triplet_I = new Maximum_Value_of_an_Ordered_Triplet_I();
            var actual = maximum_Value_of_an_Ordered_Triplet_I.MaximumTripletValue(nums);
            Assert.Equal(expected, actual);
        }
    }
}
