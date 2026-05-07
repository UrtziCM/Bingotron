using UnityEngine;

public class ScoreManager : CustomService
{

    private int score;
    private float multiplier;
    public int Score { get { return score; } }
    public float Multiplier { get { return multiplier; } }

    public int totalScore;


    private void Start()
    {
        ServiceLocator.AddService<ScoreManager>(this);

        Utils.BingoDrum.OnBallEffectEnd.AddListener(_=>SumScore());
    }

    public void AddScore(int score = 1)
    {
        this.score += score;
    }

    public void AddMultiply(float mult = 0.01f)
    { 
        this.multiplier += mult;
    }

    public void SumScore()
    {
        totalScore += (int)(score * multiplier);

        ResetMultiplier();
        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
    }
    public void ResetMultiplier()
    {
        multiplier = 0;
    }
    public void ResetTotalScore()
    {
        totalScore = 0;
    }
}
