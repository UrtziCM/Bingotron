using UnityEngine;

public class ScoreManager : Service
{

    private int score;
    public int Score { get { return score; } }


    private void Start()
    {
        ServiceLocator.AddService(this);
    }

    public void AddScore(int score = 1)
    {
        this.score += score;
    }

    public void ResetScore()
    {
        score = 0;
    }

}
