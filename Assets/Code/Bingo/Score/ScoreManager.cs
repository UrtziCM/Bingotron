using UnityEngine;

public class ScoreManager : CustomService
{

    private int score;
    private float multiplier = 1.0f;
    public int Score { get { return score; } }
    public float Multiplier { get { return multiplier; } }

    public int totalScore;

    private void Awake()
    {
        ServiceLocator.AddService<ScoreManager>(this);
    }
    private void Start()
    {
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
        Debug.Log(totalScore);

        ResetMultiplier();
        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
    }
    public void ResetMultiplier()
    {
        multiplier = 1;
    }
    public void ResetTotalScore()
    {
        totalScore = 0;
    }
}
