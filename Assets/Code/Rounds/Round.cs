using UnityEngine;

public class Round 
{
    public int pointsToWin;
    public int ballsQuantity;


    public int playerPoints;

    public Round(int points, int balls)
    {
        Utils.BingoDrum.OnBallEffectStart.AddListener(_ => BallRoll());
        Utils.BingoDrum.OnBallEffectEnd.AddListener(_ => CheckBallEnd());
        Utils.BingoCard.OnBingo.AddListener(_ => { playerPoints += 999999; RoundWin(); });

        this.pointsToWin = points;
        this.ballsQuantity = balls;
    }

    public void StartRound()
    {
        Utils.ScoreManager.ResetTotalScore();
        Utils.BingoCard.OnRoundStart.Invoke();
        Utils.BingoCard.ResetCard();

    }

    public void BallRoll()
    {
        ballsQuantity--;
    }
    public void CheckBallEnd()
    {
        Debug.Log($"BallEndPuntosTotales={Utils.ScoreManager.totalScore}/{pointsToWin}");
        if (Utils.ScoreManager.totalScore >= pointsToWin)
        {
            Debug.Log("Entering round win");
            RoundWin();
            return;
        }

        if (ballsQuantity <= 0)
        {
            RoundLost();
        }
    }

    private void RoundWin()
    {
        Utils.BingoDrum.gameObject.GetComponent<BingoDrumHelper>().RoundActive = false;

        Utils.Rewards.Open();

    }

    private void RoundLost()
    {
        Debug.Log("Lose");
    }
}
