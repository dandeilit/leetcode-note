namespace Code
{
    /// <summary>
    /// 2353. Design a Food Rating System
    /// 
    /// Design a food rating system that can do the following:
    /// 设计一个食品评级系统，该系统可以执行以下操作：
    /// 
    /// * Modify the rating of a food item listed in the system.
    /// * 修改系统中列出的食品的评级。
    /// 
    /// * Return the highest-rated food item for a type of cuisine in the system.
    /// * 返回系统中某种菜系评级最高的食品。
    /// 
    /// Implement the FoodRatings class:
    /// 实现 FoodRatings 类：
    /// 
    /// * FoodRatings(String[] foods, String[] cuisines, int[] ratings) Initializes the system. The food items are described by foods, cuisines and ratings, all of which have a length of n.
    /// * FoodRatings(String[] foods, String[] cuisines, int[] ratings) 初始化系统。食品由 foods、cuisines 和 ratings 描述，它们的长度均为 n。
    /// 
    /// * foods[i] is the name of the i-th food,
    /// * foods[i] 是第 i 种食品的名称，
    /// 
    /// * cuisines[i] is the type of cuisine of the ith food,
    /// * cuisines[i] 是第 i 种食品的菜系类型，
    /// 
    /// * ratings[i] is the initial rating of the ith food.
    /// * ratings[i] 是第 i 种食品的初始评级。
    /// 
    /// * void changeRating(String food, int newRating) Changes the rating of the food item with the name food.
    /// * void changeRating(String food, int newRating) 更改名为 food 的食品的评级。
    /// 
    /// * String highestRated(String cuisine) Returns the name of the food item that has the highest rating for the given type of cuisine. If there is a tie, return the item with the lexicographically smaller name.
    /// * String highestRated(String cuisine) 返回在给定菜系中评级最高的食品名称。如果存在平局，则返回按字典顺序排列名称较小的食品。
    /// 
    /// Note that a string x is lexicographically smaller than string y if x comes before y in dictionary order, that is, either x is a prefix of y, or if i is the first position such that x[i] != y[i], then x[i] comes before y[i] in alphabetic order.
    /// 注意，如果 x 在字典顺序中位于 y 之前，即 x 是 y 的前缀，或者 i 是第一个位置，并且 x[i] != y[i]，则按字母顺序 x[i] 位于 y[i] 之前，则字符串 x 在字典顺序上小于字符串 y。
    /// 
    /// </summary>
    public class Design_a_Food_Rating_System
    {
        /// <summary>
        /// 超时
        /// </summary>
        public class FoodRatings
        {
            IDictionary<string, IList<string>> cuisineFoods;
            IDictionary<string, int> foodRatings;

            public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
            {
                cuisineFoods = new Dictionary<string, IList<string>>();
                foodRatings = new Dictionary<string, int>();

                for (var i = 0; i < foods.Length; i++)
                {
                    foodRatings[foods[i]] = ratings[i];

                    if (cuisineFoods.ContainsKey(cuisines[i]))
                    {
                        cuisineFoods[cuisines[i]].Add(foods[i]);
                    }
                    else
                    {
                        cuisineFoods[cuisines[i]] = new List<string>() { foods[i] };
                    }

                }
            }

            public void ChangeRating(string food, int newRating)
            {
                foodRatings[food] = newRating;
            }

            public string HighestRated(string cuisine)
            {
                List<string> foods = new List<string>() { cuisineFoods[cuisine][0] };
                int len = foods[0].Length;
                int maxRating = foodRatings[foods[0]];

                for (var i = 1; i < cuisineFoods[cuisine].Count; i++)
                {
                    string curFood = cuisineFoods[cuisine][i];
                    int curRating = foodRatings[cuisineFoods[cuisine][i]];
                    if (curRating > maxRating)
                    {
                        foods = new List<string>() { cuisineFoods[cuisine][i] };
                        len = foods[0].Length;
                        maxRating = curRating;
                    }
                    else if (curRating == maxRating)
                    {
                        foods.Add(curFood);
                        len = Math.Min(len, curFood.Length);
                    }
                }

                int index = 0;
                while (foods.Count > 1)
                {
                    char c = foods[0][index];
                    List<string> newFoods = new List<string>() { foods[0] };
                    for (var i = 1; i < foods.Count; i++)
                    {
                        if (foods[i][index] < c)
                        {
                            c = foods[i][index];
                            newFoods = new List<string>() { foods[i] };
                        }
                        else if (foods[i][index] == c)
                        {
                            newFoods.Add(foods[i]);
                        }
                    }
                    foods = newFoods;
                    index++;
                }
                return foods[0];
            }
        }

        /// <summary>
        /// 平衡树
        /// </summary>
        public class FoodRatings2
        {
            private Dictionary<string, Tuple<int, string>> foodMap;
            private Dictionary<string, SortedSet<Tuple<int, string>>> ratingMap;
            private int n;

            public FoodRatings2(string[] foods, string[] cuisines, int[] ratings)
            {
                n = foods.Length;
                foodMap = new Dictionary<string, Tuple<int, string>>();
                ratingMap = new Dictionary<string, SortedSet<Tuple<int, string>>>();

                for (int i = 0; i < n; i++)
                {
                    string food = foods[i];
                    string cuisine = cuisines[i];
                    int rating = ratings[i];
                    foodMap[food] = Tuple.Create(rating, cuisine);
                    if (!ratingMap.ContainsKey(cuisine))
                    {
                        ratingMap[cuisine] = new SortedSet<Tuple<int, string>>(Comparer<Tuple<int, string>>.Create((a, b) =>
                        {
                            if (a.Item1 != b.Item1)
                            {
                                return a.Item1.CompareTo(b.Item1);
                            }
                            return a.Item2.CompareTo(b.Item2);
                        }));
                    }
                    ratingMap[cuisine].Add(Tuple.Create(n - rating, food));
                }
            }

            public void ChangeRating(string food, int newRating)
            {
                var pair = foodMap[food];
                int oldRating = pair.Item1;
                string cuisine = pair.Item2;
                ratingMap[cuisine].Remove(Tuple.Create(n - oldRating, food));
                ratingMap[cuisine].Add(Tuple.Create(n - newRating, food));
                foodMap[food] = Tuple.Create(newRating, cuisine);
            }

            public string HighestRated(string cuisine)
            {
                return ratingMap[cuisine].Min.Item2;
            }
        }

        /// <summary>
        /// 懒删除堆
        /// </summary>
        public class FoodRatings3
        {
            private Dictionary<string, (int Rating, string Cuisine)> foodMap;
            private Dictionary<string, PriorityQueue<(string Food, int Rating), (int Rating, string Food)>> ratingMap;
            private int n;

            public FoodRatings3(string[] foods, string[] cuisines, int[] ratings)
            {
                n = foods.Length;
                foodMap = new Dictionary<string, (int Rating, string Cuisine)>();
                ratingMap = new Dictionary<string, PriorityQueue<(string Food, int Rating), (int Rating, string Food)>>();

                for (int i = 0; i < n; i++)
                {
                    string food = foods[i];
                    string cuisine = cuisines[i];
                    int rating = ratings[i];
                    foodMap[food] = (rating, cuisine);
                    if (!ratingMap.ContainsKey(cuisine))
                    {
                        ratingMap[cuisine] = new PriorityQueue<(string Food, int Rating), (int Rating, string Food)>(
                            Comparer<(int Rating, string Food)>.Create((a, b) =>
                            {
                                if (a.Rating != b.Rating)
                                {
                                    return b.Rating.CompareTo(a.Rating);
                                }
                                return a.Food.CompareTo(b.Food);
                            })
                        );
                    }
                    ratingMap[cuisine].Enqueue((food, rating), (rating, food));
                }
            }

            public void ChangeRating(string food, int newRating)
            {
                var (oldRating, cuisine) = foodMap[food];
                ratingMap[cuisine].Enqueue((food, newRating), (newRating, food));
                foodMap[food] = (newRating, cuisine);
            }

            public string HighestRated(string cuisine)
            {
                var q = ratingMap[cuisine];
                while (q.Count > 0)
                {
                    var top = q.Peek();
                    string food = top.Food;
                    int rating = top.Rating;
                    if (foodMap[food].Rating == rating)
                    {
                        return food;
                    }
                    q.Dequeue();
                }

                return "";
            }
        }
    }
}
