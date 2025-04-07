using Code;

namespace Test
{
    public class Partition_Equal_Subset_Sum_Test
    {
        public static TheoryData<int[], bool> TestData => new TheoryData<int[], bool>()
        {
            { [1,5,11,5],true},
            { [1,2,3,5],false},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] nums, bool expected)
        {
            var partition_Equal_Subset_Sum = new Partition_Equal_Subset_Sum();
            var actual = partition_Equal_Subset_Sum.CanPartition(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(int[] nums, bool expected)
        {
            var partition_Equal_Subset_Sum = new Partition_Equal_Subset_Sum();
            var actual = partition_Equal_Subset_Sum.CanPartition2(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(int[] nums, bool expected)
        {
            var partition_Equal_Subset_Sum = new Partition_Equal_Subset_Sum();
            var actual = partition_Equal_Subset_Sum.CanPartition3(nums);
            Assert.Equal(expected, actual);
        }
    }
}
