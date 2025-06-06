﻿using Code;

namespace Test
{
    public class Minimum_Domino_Rotations_For_Equal_Row_Test
    {
        public static TheoryData<int[], int[], int> TestData => new TheoryData<int[], int[], int> {
            { [2,1,2,4,2,2],[5,2,6,2,3,2],2},
            { [3,5,1,2,3],[3,6,3,3,4],-1},
            { [1,2,1,1,1,2,2,2],[2,1,2,2,2,2,2,2],1},
            { [2,1,1,1,2,2,2,1,1,2],[1,1,2,1,1,1,1,2,1,1],2},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(int[] tops, int[] bottoms, int expected)
        {
            var minimum_Domino_Rotations_For_Equal_Row = new Minimum_Domino_Rotations_For_Equal_Row();
            var actual = minimum_Domino_Rotations_For_Equal_Row.MinDominoRotations(tops, bottoms);
            Assert.Equal(expected, actual);
        }
    }
}
