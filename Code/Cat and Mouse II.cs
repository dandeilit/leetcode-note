namespace Code
{
    /// <summary>
    /// 1728. Cat and Mouse II
    /// 
    /// A game is played by a cat and a mouse named Cat and Mouse.
    /// 一只猫和一只老鼠在玩一个游戏，名字叫猫和老鼠。
    /// 
    /// The environment is represented by a grid of size rows x cols, where each element is a wall, floor, player (Cat, Mouse), or food.
    /// 环境用一个大小为 行 x 列 的网格表示，其中每个元素是一堵墙、地板、玩家（猫、老鼠）或食物。
    /// 
    /// * Players are represented by the characters 'C'(Cat),'M'(Mouse).
    /// * 玩家用字符“C”（猫）、“M”（老鼠）表示。
    /// 
    /// * Floors are represented by the character '.' and can be walked on.
    /// * 地板用字符“。”表示，可以在上面行走。
    /// 
    /// * Walls are represented by the character '#' and cannot be walked on.
    /// * 墙壁用字符“#”表示，不能在上面行走。
    /// 
    /// * Food is represented by the character 'F' and can be walked on.
    /// * 食物用字符“F”表示，可以在上面行走。
    /// 
    /// * There is only one of each character 'C', 'M', and 'F' in grid.
    /// * 网格中每个字符“C”、“M”和“F”只有一个。
    /// 
    /// Mouse and Cat play according to the following rules:
    /// 老鼠和猫按照以下规则进行游戏：
    /// 
    /// * Mouse moves first, then they take turns to move.
    /// * 老鼠先移动，然后它们轮流移动。
    /// 
    /// * During each turn, Cat and Mouse can jump in one of the four directions (left, right, up, down). They cannot jump over the wall nor outside of the grid.
    /// * 在每个回合中，猫和老鼠可以向四个方向（左、右、上、下）之一跳跃。它们不能跳过墙，也不能跳出网格。
    /// 
    /// * catJump, mouseJump are the maximum lengths Cat and Mouse can jump at a time, respectively. Cat and Mouse can jump less than the maximum length.
    /// * catJump、mouseJump 分别是猫和老鼠一次可以跳跃的最大长度。猫和老鼠可以跳跃的长度小于最大长度。
    /// 
    /// * Staying in the same position is allowed.
    /// * 可以保持相同的位置。
    /// 
    /// * Mouse can jump over Cat.
    /// * 老鼠可以跳过猫。
    /// 
    /// The game can end in 4 ways:
    /// 游戏可以以 4 种方式结束：
    /// 
    /// * If Cat occupies the same position as Mouse, Cat wins.
    /// * 如果猫和老鼠占据相同的位置，猫获胜。
    /// 
    /// * If Cat reaches the food first, Cat wins.
    /// * 如果猫先到达食物，猫获胜。
    /// 
    /// * If Mouse reaches the food first, Mouse wins.
    /// * 如果老鼠先到达食物，老鼠获胜。
    /// 
    /// * If Mouse cannot get to the food within 1000 turns, Cat wins.
    /// * 如果老鼠在 1000 回合内无法到达食物，猫获胜。
    /// 
    /// Given a rows x cols matrix grid and two integers catJump and mouseJump, return true if Mouse can win the game if both Cat and Mouse play optimally, otherwise return false.
    /// 给定一个行 x 列矩阵网格和两个整数 catJump 和 mouseJump，如果在 Cat 和 Mouse 都发挥出最佳水平的情况下 Mouse 能够赢得游戏，则返回 true，否则返回 false。
    /// 
    /// </summary>
    public class Cat_and_Mouse_II
    {
        const int MOUSE_TURN = 0, CAT_TURN = 1;
        const int UNKNOWN = 0, MOUSE_WIN = 1, CAT_WIN = 2;
        const int MAX_MOVES = 1000;
        int[][] dirs = { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        int rows, cols;
        string[] grid;
        int catJump, mouseJump;
        int food;
        int[,,] degrees;
        int[,,,] results;

        /// <summary>
        /// 拓扑排序
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="catJump"></param>
        /// <param name="mouseJump"></param>
        /// <returns></returns>
        public bool CanMouseWin(string[] grid, int catJump, int mouseJump)
        {
            this.rows = grid.Length;
            this.cols = grid[0].Length;
            this.grid = grid;
            this.catJump = catJump;
            this.mouseJump = mouseJump;
            int startMouse = -1, startCat = -1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    char c = grid[i][j];
                    if (c == 'M')
                    {
                        startMouse = GetPos(i, j);
                    }
                    else if (c == 'C')
                    {
                        startCat = GetPos(i, j);
                    }
                    else if (c == 'F')
                    {
                        food = GetPos(i, j);
                    }
                }
            }
            int total = rows * cols;
            degrees = new int[total, total, 2];
            results = new int[total, total, 2, 2];
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
            // 计算每个状态的度
            for (int mouse = 0; mouse < total; mouse++)
            {
                int mouseRow = mouse / cols, mouseCol = mouse % cols;
                if (grid[mouseRow][mouseCol] == '#')
                {
                    continue;
                }
                for (int cat = 0; cat < total; cat++)
                {
                    int catRow = cat / cols, catCol = cat % cols;
                    if (grid[catRow][catCol] == '#')
                    {
                        continue;
                    }
                    degrees[mouse, cat, MOUSE_TURN]++;
                    degrees[mouse, cat, CAT_TURN]++;
                    foreach (int[] dir in dirs)
                    {
                        for (int row = mouseRow + dir[0], col = mouseCol + dir[1], jump = 1; row >= 0 && row < rows && col >= 0 && col < cols && grid[row][col] != '#' && jump <= mouseJump; row += dir[0], col += dir[1], jump++)
                        {
                            int nextMouse = GetPos(row, col), nextCat = GetPos(catRow, catCol);
                            degrees[nextMouse, nextCat, MOUSE_TURN]++;
                        }
                        for (int row = catRow + dir[0], col = catCol + dir[1], jump = 1; row >= 0 && row < rows && col >= 0 && col < cols && grid[row][col] != '#' && jump <= catJump; row += dir[0], col += dir[1], jump++)
                        {
                            int nextMouse = GetPos(mouseRow, mouseCol), nextCat = GetPos(row, col);
                            degrees[nextMouse, nextCat, CAT_TURN]++;
                        }
                    }
                }
            }
            // 猫和老鼠在同一个单元格，猫获胜
            for (int pos = 0; pos < total; pos++)
            {
                int row = pos / cols, col = pos % cols;
                if (grid[row][col] == '#')
                {
                    continue;
                }
                results[pos, pos, MOUSE_TURN, 0] = CAT_WIN;
                results[pos, pos, MOUSE_TURN, 1] = 0;
                results[pos, pos, CAT_TURN, 0] = CAT_WIN;
                results[pos, pos, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(pos, pos, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(pos, pos, CAT_TURN));
            }
            // 猫和食物在同一个单元格，猫获胜
            for (int mouse = 0; mouse < total; mouse++)
            {
                int mouseRow = mouse / cols, mouseCol = mouse % cols;
                if (grid[mouseRow][mouseCol] == '#' || mouse == food)
                {
                    continue;
                }
                results[mouse, food, MOUSE_TURN, 0] = CAT_WIN;
                results[mouse, food, MOUSE_TURN, 1] = 0;
                results[mouse, food, CAT_TURN, 0] = CAT_WIN;
                results[mouse, food, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(mouse, food, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(mouse, food, CAT_TURN));
            }
            // 老鼠和食物在同一个单元格且猫和食物不在同一个单元格，老鼠获胜
            for (int cat = 0; cat < total; cat++)
            {
                int catRow = cat / cols, catCol = cat % cols;
                if (grid[catRow][catCol] == '#' || cat == food)
                {
                    continue;
                }
                results[food, cat, MOUSE_TURN, 0] = MOUSE_WIN;
                results[food, cat, MOUSE_TURN, 1] = 0;
                results[food, cat, CAT_TURN, 0] = MOUSE_WIN;
                results[food, cat, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(food, cat, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(food, cat, CAT_TURN));
            }
            // 拓扑排序
            while (queue.Count > 0)
            {
                Tuple<int, int, int> state = queue.Dequeue();
                int mouse = state.Item1, cat = state.Item2, turn = state.Item3;
                int result = results[mouse, cat, turn, 0];
                int moves = results[mouse, cat, turn, 1];
                IList<Tuple<int, int, int>> prevStates = GetPrevStates(mouse, cat, turn);
                foreach (Tuple<int, int, int> prevState in prevStates)
                {
                    int prevMouse = prevState.Item1, prevCat = prevState.Item2, prevTurn = prevState.Item3;
                    if (results[prevMouse, prevCat, prevTurn, 0] == UNKNOWN)
                    {
                        bool canWin = (result == MOUSE_WIN && prevTurn == MOUSE_TURN) || (result == CAT_WIN && prevTurn == CAT_TURN);
                        if (canWin)
                        {
                            results[prevMouse, prevCat, prevTurn, 0] = result;
                            results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                            queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                        }
                        else
                        {
                            degrees[prevMouse, prevCat, prevTurn]--;
                            if (degrees[prevMouse, prevCat, prevTurn] == 0)
                            {
                                int loseResult = prevTurn == MOUSE_TURN ? CAT_WIN : MOUSE_WIN;
                                results[prevMouse, prevCat, prevTurn, 0] = loseResult;
                                results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                                queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                            }
                        }
                    }
                }
            }
            return results[startMouse, startCat, MOUSE_TURN, 0] == MOUSE_WIN && results[startMouse, startCat, MOUSE_TURN, 1] <= MAX_MOVES;
        }

        private IList<Tuple<int, int, int>> GetPrevStates(int mouse, int cat, int turn)
        {
            IList<Tuple<int, int, int>> prevStates = new List<Tuple<int, int, int>>();
            int mouseRow = mouse / cols, mouseCol = mouse % cols;
            int catRow = cat / cols, catCol = cat % cols;
            int prevTurn = turn == MOUSE_TURN ? CAT_TURN : MOUSE_TURN;
            int maxJump = prevTurn == MOUSE_TURN ? mouseJump : catJump;
            int startRow = prevTurn == MOUSE_TURN ? mouseRow : catRow;
            int startCol = prevTurn == MOUSE_TURN ? mouseCol : catCol;
            prevStates.Add(new Tuple<int, int, int>(mouse, cat, prevTurn));
            foreach (int[] dir in dirs)
            {
                for (int i = startRow + dir[0], j = startCol + dir[1], jump = 1; i >= 0 && i < rows && j >= 0 && j < cols && grid[i][j] != '#' && jump <= maxJump; i += dir[0], j += dir[1], jump++)
                {
                    int prevMouseRow = prevTurn == MOUSE_TURN ? i : mouseRow;
                    int prevMouseCol = prevTurn == MOUSE_TURN ? j : mouseCol;
                    int prevCatRow = prevTurn == MOUSE_TURN ? catRow : i;
                    int prevCatCol = prevTurn == MOUSE_TURN ? catCol : j;
                    int prevMouse = GetPos(prevMouseRow, prevMouseCol);
                    int prevCat = GetPos(prevCatRow, prevCatCol);
                    prevStates.Add(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                }
            }
            return prevStates;
        }

        private int GetPos(int row, int col)
        {
            return row * cols + col;
        }
    }
}
