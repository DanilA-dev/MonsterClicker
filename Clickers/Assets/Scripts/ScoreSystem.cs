using System;

public static class ScoreSystem
{
    private static int maxScore;
    private static int score;
    public static event Action<int> OnScoreChanged;


    public static void AddScore(int scoreForKill)
    {
        score += scoreForKill;
        OnScoreChanged?.Invoke(score);
        maxScore = score;
    }
   

    
}
