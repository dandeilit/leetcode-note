namespace Code
{
    /// <summary>
    /// 2140. Solving Questions With Brainpower
    /// 2140. 解决智力问题
    /// 
    /// You are given a 0-indexed 2D integer array questions where questions[i] = [points-i, brainpower-i].
    /// 给你一个下标从 0 开始的二维整数数组 questions ，其中 questions[i] = [points-i, brainpower-i] 。
    /// 
    /// The array describes the questions of an exam, where you have to process the questions in order (i.e., starting from question 0) and make a decision whether to solve or skip each question. Solving question i will earn you points-i points but you will be unable to solve each of the next brainpower-i questions. If you skip question i, you get to make the decision on the next question.
    /// 这个数组表示一场考试里的一系列题目，你需要 按顺序 （也就是从问题 0 开始依次解决），针对每个问题选择 解决 或者 跳过 操作。解决问题 i 将让你 获得  points-i 的分数，但是你将 无法 解决接下来的 brainpower-i 个问题（即只能跳过接下来的 brainpower-i 个问题）。如果你跳过问题 i ，你可以对下一个问题决定使用哪种操作。
    /// 
    /// For example, given questions = [[3, 2], [4, 3], [4, 4], [2, 5]]:
    /// 比方说，给你 questions = [[3, 2], [4, 3], [4, 4], [2, 5]] ：
    /// 
    /// * If question 0 is solved, you will earn 3 points but you will be unable to solve questions 1 and 2.
    /// * 如果问题 0 被解决了， 那么你可以获得 3 分，但你不能解决问题 1 和 2 。
    /// 
    /// * If instead, question 0 is skipped and question 1 is solved, you will earn 4 points but you will be unable to solve questions 2 and 3.
    /// * 如果你跳过问题 0 ，且解决问题 1 ，你将获得 4 分但是不能解决问题 2 和 3 。
    /// 
    /// Return the maximum points you can earn for the exam.
    /// 请你返回这场考试里你能获得的 最高 分数。
    /// 
    /// </summary>
    public class Solving_Questions_With_Brainpower
    {
        public long MostPoints(int[][] questions)
        {
            int n = questions.Length;
            var mostPoints = new long[n];
            mostPoints[n - 1] = questions[n - 1][0];
            for (var i = n - 2; i >= 0; i--)
            {
                int points = questions[i][0];
                int brainpower = questions[i][1];
                if (i + brainpower + 1 >= n)
                {
                    mostPoints[i] = Math.Max(points, mostPoints[i + 1]);
                }
                else
                {
                    mostPoints[i] = Math.Max(points + mostPoints[i + brainpower + 1], mostPoints[i + 1]);
                }
            }
            return mostPoints[0];
        }
    }
}
