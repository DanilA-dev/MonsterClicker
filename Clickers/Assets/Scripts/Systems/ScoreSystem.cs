using System;
using UnityEngine;
public static class ScoreSystem
{
    public static int maxScore { get; set; }

    public static int score { get; private set; }

    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnMaxScoreChanged;

    public static void AddScore(int scoreForKill)
    {
        score += scoreForKill;
        maxScore = score;
        OnScoreChanged?.Invoke(score);
        OnMaxScoreChanged?.Invoke(maxScore);
    }
    

    public static void ResetScore()
    {
        score = 0;
        OnScoreChanged?.Invoke(score);
    }


}
