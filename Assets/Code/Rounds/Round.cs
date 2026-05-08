using UnityEngine;

public class Round 
{
    public int pointsToWin;
    public int ballsCuantity;

    public int playerPoints;

    public Round(int points, int balls)
    {
        Utils.BingoDrum.OnBallEffectStart.AddListener(_ => BallRoll());
        Utils.BingoDrum.OnBallEffectEnd.AddListener(_ => CheckBallEnd());
        
        StartRound();

        this.pointsToWin = points;
        this.ballsCuantity = balls;
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
        Debug.Log("Win");
    }

    private void RoundLost()
    {
        Debug.Log("Lose");
    }
}
