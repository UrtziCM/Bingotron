using UnityEngine;

public class Round : CustomService
{
    public int pointsToWin;
    public int ballsCuantity;

    public int playerPoints;

    private void Awake()
    {
        ServiceLocator.AddService<Round>(this);
    }
    private void Start()
    {
        Utils.BingoDrum.OnBallEffectStart.AddListener(_ => BallRoll());
        Utils.BingoDrum.OnBallEffectEnd.AddListener(_ => CheckBallEnd());
        StartRound();
    }

    public void StartRound()
    {
        Utils.ScoreManager.ResetTotalScore();
        Utils.BingoCard.OnRoundStart.Invoke();
    }

    public void BallRoll()
    {
        ballsCuantity--;
    }
    public void CheckBallEnd()
    {
        if (Utils.ScoreManager.totalScore >= pointsToWin)
        {
            RoundWin();
            return;
        }

        if (ballsCuantity <= 0)
        {
            RoundLost();
        }
    }

    private void RoundWin()
    {
    }

    private void RoundLost()
    { 
    }
}
