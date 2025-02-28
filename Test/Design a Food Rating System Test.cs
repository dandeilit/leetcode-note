using static Code.Design_a_Food_Rating_System;

namespace Test
{
    public class Design_a_Food_Rating_System_Test
    {
        public static TheoryData<string[], string[], int[], string[], object[][], string[]> TestData => new TheoryData<string[], string[], int[], string[], object[][], string[]>()
        {
            { ["kimchi", "miso", "sushi", "moussaka", "ramen", "bulgogi"], ["korean", "japanese", "japanese", "greek", "japanese", "korean"], [9, 12, 8, 15, 14, 7],["FoodRatings", "highestRated", "highestRated", "changeRating", "highestRated", "changeRating", "highestRated"], [[],["korean"], ["japanese"], ["sushi", 16], ["japanese"], ["ramen", 16], ["japanese"]],[null, "kimchi", "ramen", null, "sushi", null, "ramen"]},
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test(string[] foods, string[] cuisines, int[] ratings, string[] commands, object[][] paramters, string[] expected)
        {
            var actual = new string[commands.Length];

            FoodRatings foodRatings = new FoodRatings(foods, cuisines, ratings);
            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "changeRating":
                        foodRatings.ChangeRating((string)paramters[i][0], (int)paramters[i][1]);
                        actual[i] = null;
                        break;
                    case "highestRated":
                        actual[i] = foodRatings.HighestRated((string)paramters[i][0]);
                        break;
                    default:
                        actual[i] = null;
                        break;
                }
            }
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Test2(string[] foods, string[] cuisines, int[] ratings, string[] commands, object[][] paramters, string[] expected)
        {
            var actual = new string[commands.Length];

            FoodRatings2 foodRatings = new FoodRatings2(foods, cuisines, ratings);
            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "changeRating":
                        foodRatings.ChangeRating((string)paramters[i][0], (int)paramters[i][1]);
                        actual[i] = null;
                        break;
                    case "highestRated":
                        actual[i] = foodRatings.HighestRated((string)paramters[i][0]);
                        break;
                    default:
                        actual[i] = null;
                        break;
                }
            }
            Assert.Equal(expected, actual);
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void Test3(string[] foods, string[] cuisines, int[] ratings, string[] commands, object[][] paramters, string[] expected)
        {
            var actual = new string[commands.Length];

            FoodRatings3 foodRatings = new FoodRatings3(foods, cuisines, ratings);
            for (var i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "changeRating":
                        foodRatings.ChangeRating((string)paramters[i][0], (int)paramters[i][1]);
                        actual[i] = null;
                        break;
                    case "highestRated":
                        actual[i] = foodRatings.HighestRated((string)paramters[i][0]);
                        break;
                    default:
                        actual[i] = null;
                        break;
                }
            }
            Assert.Equal(expected, actual);
        }
    }
}
